﻿//******************************************************************************
//
// Copyright (c) 2015 Microsoft Corporation. All rights reserved.
//
// This code is licensed under the MIT License (MIT).
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//******************************************************************************

//
// ProfilePictureControl.xaml.cpp
// Implementation of the ProfilePictureControl class
//

#include "pch.h"
#include "FacebookProfilePictureControl.xaml.h"
#include "FBSingleValue.h"
#include <string>

using namespace concurrency;
using namespace winsdkfb;
using namespace winsdkfb::Graph;
using namespace Platform;
using namespace Windows::ApplicationModel::Core;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::Storage;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Core;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace Windows::UI::Xaml::Media::Imaging;
using namespace Windows::UI::Xaml::Interop;

// At least enough characters to hold a string representation of 32-bit int,
// in decimal.  Used for width and height of profile picture.
#define INT_STRING_LENGTH 16


#define ProfilePictureSillhouetteImage \
    "ms-appx:///winsdkfb/Images/fb_blank_profile_portrait.png"

DependencyProperty^ ProfilePictureControl::_userIdProperty = DependencyProperty::Register(
    L"UserId",
    TypeName(String::typeid),
    TypeName(ProfilePictureControl::typeid),
    ref new PropertyMetadata(
        nullptr,
        ref new PropertyChangedCallback(&ProfilePictureControl::UserIdPropertyChanged)));

ProfilePictureControl::ProfilePictureControl() :
    _CropMode(CroppingType::Square)
{
	InitializeComponent();
    Update();
}

void ProfilePictureControl::UserIdPropertyChanged(DependencyObject^ d, DependencyPropertyChangedEventArgs^ e)
{
    ProfilePictureControl^ instance = static_cast<ProfilePictureControl^>(d);
    instance->UserId = static_cast<String^>(e->NewValue);
}

String^ ProfilePictureControl::UserId::get()
{
    return safe_cast<String^>(GetValue(_userIdProperty));
}

void ProfilePictureControl::UserId::set(String^ value)
{
    SetValue(_userIdProperty, value);
    Update();
}

CroppingType ProfilePictureControl::CropMode::get()
{
    return _CropMode;
}

void ProfilePictureControl::CropMode::set(CroppingType value)
{
    if (_CropMode != value)
    {
        _CropMode = value;
        Update();
    }
}

void ProfilePictureControl::SetImageSourceFromUserId()
{
    int height = -1;

    // specify height == width for square.  If user wants original aspect ratio,
    // only specify width, and FB graph API will scale and preserve ratio.
    if (CropMode == CroppingType::Square)
    {
        height = (int)this->Width;
    }

    create_task(GetProfilePictureInfo((int)this->Width, height))
        .then([=](FBResult^ result)
    {
        FBProfilePicture^ info = nullptr;

        if (result && (result->Succeeded))
        {
            info = static_cast<FBProfilePicture^>(result->Object);
        }

        return info;
    })
        .then([=](FBProfilePicture^ info)
    {
        Windows::UI::Core::CoreWindow^ wnd =
            CoreApplication::MainView->CoreWindow;
        if (wnd)
        {
            wnd->Dispatcher->RunAsync(CoreDispatcherPriority::Low,
                ref new DispatchedHandler([info, this]()
            {
                if (info)
                {
                    ProfilePic->Stretch = Stretch::Uniform;
                    ProfilePic->Source = ref new BitmapImage(ref new Uri(info->Url));
                }
            }));
        }
    });
}

void ProfilePictureControl::SetImageSourceFromResource()
{
    Windows::UI::Core::CoreWindow^ wnd =
        CoreApplication::MainView->CoreWindow;
    if (wnd)
    {
        wnd->Dispatcher->RunAsync(CoreDispatcherPriority::Low,
            ref new DispatchedHandler([=]()
        {
            Uri^ u = ref new Uri(ProfilePictureSillhouetteImage);
            ProfilePic->Stretch = Stretch::Uniform;
            ProfilePic->Source = ref new BitmapImage(u);
        }));
    }
}

void ProfilePictureControl::Update()
{
    if (UserId)
    {
        SetImageSourceFromUserId();
    }
    else
    {
        SetImageSourceFromResource();
    }
}

task<FBResult^> 
ProfilePictureControl::GetProfilePictureInfo(
    int width,
    int height
    )
{
    PropertySet^ parameters = ref new PropertySet();
    wchar_t whBuffer[INT_STRING_LENGTH];
    task<FBResult^> result;

    parameters->Insert(L"redirect", L"false");

    if (width > -1)
    {
        if (!_itow_s(width, whBuffer, INT_STRING_LENGTH, 10))
        {
            String^ Value = ref new String(whBuffer);
            parameters->Insert(L"width", Value);
        }
    }
    if (height > -1)
    {
        if (!_itow_s(height, whBuffer, INT_STRING_LENGTH, 10))
        {
            String^ Value = ref new String(whBuffer);
            parameters->Insert(L"height", Value);
        }
    }
    if (UserId)
    {
        String^ path = UserId + L"/picture";

        FBSingleValue^ value = ref new FBSingleValue(
            path,
            parameters,
            ref new FBJsonClassFactory([](String^ JsonText) -> Object^
        {
            return FBProfilePicture::FromJson(JsonText);
        }));

        result = create_task(value->GetAsync());
    }

    return result;
}
