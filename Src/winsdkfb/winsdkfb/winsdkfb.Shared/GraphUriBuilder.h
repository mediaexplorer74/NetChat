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

#include <ppltasks.h>

namespace winsdkfb
{
    public ref class GraphUriBuilder sealed
    {
    public:
        GraphUriBuilder(Platform::String^ path);

        Windows::Foundation::Uri^ MakeUri();
        void AddQueryParam(Platform::String^ query, Platform::String^ param);

    private:
        void BuildApiVersionString();
        void FixPathDelimiters();
        void DecodeQueryParams(Windows::Foundation::Uri^ uri);

        Platform::String^ _host;
        Platform::String^ _path;
        Platform::String^ _scheme;
        Platform::String^ _apiVersion;
        Windows::Foundation::Collections::PropertySet^ _queryParams;
    };
}
