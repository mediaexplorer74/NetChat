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
// MainPage.xaml.h
// Declaration of the MainPage class.
//

#pragma once

#include "MainPage.g.h"

namespace LoginCpp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public ref class MainPage sealed
    {
    public:
        MainPage();

    private:
        void MainPage::SetSessionAppIds(
            );

        winsdkfb::FBPermissions^ BuildPermissions(
            );

        BOOL DidGetAllRequestedPermissions(
            );

        BOOL MainPage::WasAppPermissionRemovedByUser(
            winsdkfb::FBResult^ result
            );

        BOOL ShouldRerequest(
            winsdkfb::FBResult^ result
            );

        void MainPage::TryRerequest(
            BOOL retry
            );

        void MainPage::LogoutAndRetry(
            );

        void login_OnClicked(
            Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e
            );

        void LoginButton_Click(
            Platform::Object^ sender,
            Windows::UI::Xaml::RoutedEventArgs^ e
            );

        void UserInfoButton_Click(
            Platform::Object^ sender,
            Windows::UI::Xaml::RoutedEventArgs^ e
            );

        void DialogsPageButton_Click(
            Platform::Object^ sender,
            Windows::UI::Xaml::RoutedEventArgs^ e
            );

        winsdkfb::SessionLoginBehavior GetLoginBehavior(
            );

        void MainPage::UpdateXamlControls(
            );

        void LayoutRoot_Loaded(
            Platform::Object^ sender,
            Windows::UI::Xaml::RoutedEventArgs^ e
            );
    };
}
