//******************************************************************************
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

#pragma once

namespace winsdkfb
{
    public interface class IHttpClient
    {
    public:
        Windows::Foundation::IAsyncOperation<Platform::String^>^ GetTaskAsync(
            Platform::String^ path,
            Windows::Foundation::Collections::IMapView<Platform::String^, Platform::Object^>^ parameters
            );

         Windows::Foundation::IAsyncOperation<Platform::String^>^ PostTaskAsync(
            Platform::String^ path,
            Windows::Foundation::Collections::IMapView<Platform::String^, Platform::Object^>^ parameters
            );

         Windows::Foundation::IAsyncOperation<Platform::String^>^ DeleteTaskAsync(
            Platform::String^ path,
            Windows::Foundation::Collections::IMapView<Platform::String^, Platform::Object^>^ parameters
            );

        Platform::String^ ParametersToQueryString(
            Windows::Foundation::Collections::IMapView<Platform::String^, Platform::Object^>^ parameters
            );
    };
}
