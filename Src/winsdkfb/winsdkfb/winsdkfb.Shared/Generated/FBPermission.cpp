

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
#include "FBPermission.h"

using namespace winsdkfb;
using namespace winsdkfb::Graph;
using namespace Platform;
using namespace Windows::Data::Json;
using namespace Windows::Foundation::Collections;

FBPermission::FBPermission(
    ) :
    _permission(nullptr),
    _status(nullptr)

{
    ;
}


String^ FBPermission::Permission::get()
{
    return _permission;
}
void FBPermission::Permission::set(String^ value)
{
    _permission = value;

}


String^ FBPermission::Status::get()
{
    return _status;
}
void FBPermission::Status::set(String^ value)
{
    _status = value;

}


Object^ FBPermission::FromJson(
    String^ JsonText 
    )
{
    FBPermission^ result = ref new FBPermission;
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

                if  (!String::CompareOrdinal(key, L"permission"))
                {

                    found++;
                    result->Permission = it->Current->Value->GetString();

                }

                else if (!String::CompareOrdinal(key, L"status"))
                {

                    found++;
                    result->Status = it->Current->Value->GetString();

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





