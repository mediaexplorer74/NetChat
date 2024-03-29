

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
#include "FBGroup.h"

using namespace winsdkfb;
using namespace winsdkfb::Graph;
using namespace Platform;
using namespace Windows::Data::Json;
using namespace Windows::Foundation::Collections;

FBGroup::FBGroup(
    ) :
    _id(nullptr),
    _description(nullptr),
    _email(nullptr),
    _icon(nullptr),
    _link(nullptr),
    _name(nullptr),
    _privacy(nullptr)

{
    ;
}


String^ FBGroup::Id::get()
{
    return _id;
}
void FBGroup::Id::set(String^ value)
{
    _id = value;

}


String^ FBGroup::Description::get()
{
    return _description;
}
void FBGroup::Description::set(String^ value)
{
    _description = value;

}


String^ FBGroup::Email::get()
{
    return _email;
}
void FBGroup::Email::set(String^ value)
{
    _email = value;

}


String^ FBGroup::Icon::get()
{
    return _icon;
}
void FBGroup::Icon::set(String^ value)
{
    _icon = value;

}


String^ FBGroup::Link::get()
{
    return _link;
}
void FBGroup::Link::set(String^ value)
{
    _link = value;

}


String^ FBGroup::Name::get()
{
    return _name;
}
void FBGroup::Name::set(String^ value)
{
    _name = value;

}


String^ FBGroup::Privacy::get()
{
    return _privacy;
}
void FBGroup::Privacy::set(String^ value)
{
    _privacy = value;

}


Object^ FBGroup::FromJson(
    String^ JsonText 
    )
{
    FBGroup^ result = ref new FBGroup;
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

                if  (!String::CompareOrdinal(key, L"id"))
                {

                    found++;
                    result->Id = it->Current->Value->GetString();

                }

                else if (!String::CompareOrdinal(key, L"description"))
                {

                    found++;
                    result->Description = it->Current->Value->GetString();

                }

                else if (!String::CompareOrdinal(key, L"email"))
                {

                    found++;
                    result->Email = it->Current->Value->GetString();

                }

                else if (!String::CompareOrdinal(key, L"icon"))
                {

                    found++;
                    result->Icon = it->Current->Value->GetString();

                }

                else if (!String::CompareOrdinal(key, L"link"))
                {

                    found++;
                    result->Link = it->Current->Value->GetString();

                }

                else if (!String::CompareOrdinal(key, L"name"))
                {

                    found++;
                    result->Name = it->Current->Value->GetString();

                }

                else if (!String::CompareOrdinal(key, L"privacy"))
                {

                    found++;
                    result->Privacy = it->Current->Value->GetString();

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





