

//------------------------------------------------------------------------------
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
//------------------------------------------------------------------------------
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//------------------------------------------------------------------------------




#pragma once
//------------------------------------------------------------------------------
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//------------------------------------------------------------------------------

#include "JsonClassFactory.h"

#include "FBProfilePicture.h"


namespace winsdkfb
{
    namespace Graph
    {

        public ref class FBProfilePictureData sealed 
        {
            public:

                static Object^ FromJson(
                    Platform::String^ JsonText 
                    );


                property winsdkfb::Graph::FBProfilePicture^ Data
                {
                    winsdkfb::Graph::FBProfilePicture^ get();
                    void set(winsdkfb::Graph::FBProfilePicture^ value);
                }


            private:
                FBProfilePictureData(
                    );


                winsdkfb::Graph::FBProfilePicture^ _data;

        };
    }
}




