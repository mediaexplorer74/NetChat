

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




#include "pch.h"
#include "FBProfilePicture.h"

using namespace winsdkfb;
using namespace winsdkfb::Graph;
using namespace Platform;
using namespace Windows::Data::Json;
using namespace Windows::Foundation::Collections;

FBProfilePicture::FBProfilePicture(
    ) :
    _height(-1),
    _is_silhouette(false),
    _url(nullptr),
    _width(-1)

{
    ;
}


int FBProfilePicture::Height::get()
{
    return _height;
}
void FBProfilePicture::Height::set(int value)
{
    _height = value;

}


bool FBProfilePicture::IsSilhouette::get()
{
    return _is_silhouette;
}
void FBProfilePicture::IsSilhouette::set(bool value)
{
    _is_silhouette = value;

}


String^ FBProfilePicture::Url::get()
{
    return _url;
}
void FBProfilePicture::Url::set(String^ value)
{
    _url = value;

}


int FBProfilePicture::Width::get()
{
    return _width;
}
void FBProfilePicture::Width::set(int value)
{
    _width = value;

}


Object^ FBProfilePicture::FromJson(
    String^ JsonText 
    )
{
    FBProfilePicture^ result = ref new FBProfilePicture;
    int found = 0;
    JsonValue^ val = nullptr;

    if (JsonValue::TryParse(JsonText, &val))
    {
        if (val->ValueType == JsonValueType::Object)
        {
            JsonObject^ obj = val->GetObject();
            IIterator<IKeyValuePair<String^, IJsonValue^>^>^ it = nullptr;
            for (it = obj->First(); it->HasCurrent; it->MoveNext())
            {
                String^ key = it->Current->Key;

                if  (!String::CompareOrdinal(key, L"height"))
                {

                    found++;
                    result->Height = static_cast<int>(it->Current->Value->GetNumber());

                }

                else if (!String::CompareOrdinal(key, L"is_silhouette"))
                {

                    found++;
                    result->IsSilhouette = it->Current->Value->GetBoolean();

                }

                else if (!String::CompareOrdinal(key, L"url"))
                {

                    found++;
                    result->Url = it->Current->Value->GetString();

                }

                else if (!String::CompareOrdinal(key, L"width"))
                {

                    found++;
                    result->Width = static_cast<int>(it->Current->Value->GetNumber());

                }

            }

            if (!found)
            {
                // No field names matched any known properties for this class.  
                // Even if it *is* an object of our type, it's not useful.
                result = nullptr;
            }
        }
    }
    return result;
}




