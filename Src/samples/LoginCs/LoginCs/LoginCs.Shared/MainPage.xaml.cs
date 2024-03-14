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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using winsdkfb;
using Windows.Globalization;
using Windows.ApplicationModel.Resources;
using System.Threading.Tasks;
using Windows.Globalization.DateTimeFormatting;
using Windows.ApplicationModel.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LoginCs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SetSessionAppIds();
        }

        private const string FBAppIDName       = "FBApplicationId";
        private const string FBPhoneAppIDName  = "FBWinPhoneAppId";
        private const string PermissionGranted = "granted";

        private readonly string[] requested_permissions =
        {
            "public_profile",
            "email",
            "user_friends",
            "publish_actions"
        };

        void SetSessionAppIds(
            )
        {
            FBSession s = FBSession.ActiveSession;

            // Assumes the Facebook App ID and Windows Phone Store ID have been saved
            // in the default resource file.
            ResourceLoader rl = ResourceLoader.GetForCurrentView();

            String appId = rl.GetString(FBAppIDName);
            String winAppId = rl.GetString(FBPhoneAppIDName);

            // IDs are both sent to FB app, so it can validate us.
            s.FBAppId = appId;
            s.WinAppId = winAppId;
        }

        FBPermissions BuildPermissions(
            )
        {
            FBPermissions result = null; 
            List<string> perms = new List<string>();

            for (uint i = 0; i < requested_permissions.Length; i++)
            {
                perms.Add(requested_permissions[i]);
            }

            result = new FBPermissions(perms);

            return result;
        }

        bool DidGetAllRequestedPermissions(
            )
        {
            bool success = false;
            FBAccessTokenData data = FBSession.ActiveSession.AccessTokenData;

            if (data != null)
            {
                success = (data.DeclinedPermissions.Values.Count == 0);
            }

            return success;
        }

        bool WasAppPermissionRemovedByUser(
            FBResult Result
            )
        {
            return ((Result != null) &&
                (!Result.Succeeded) &&
                (Result.ErrorInfo.Code == (int)winsdkfb.ErrorCode.ErrorCodeOauthException));
        }

        bool ShouldRerequest(
            FBResult Result
            )
        {
            return ((Result != null) &&
                Result.Succeeded &&
                !DidGetAllRequestedPermissions());
        }

        async Task TryRerequest(
            bool Retry
            )
        {
            // If we're logged out, the session has cleared the FB and Windows app IDs,
            // so they need to be set again.  We load these IDs via the ResourceLoader
            // class, which must be accessed on the UI thread, which is why this call
            // is outside the task context.
            SetSessionAppIds();

            FBResult result = await FBSession.ActiveSession.LoginAsync(BuildPermissions(), GetLoginBehavior());

            if (result.Succeeded)
            {
                if (Retry && (!DidGetAllRequestedPermissions()))
                {
                    await TryRerequest(false);
                }
                else
                {
                    UpdateXamlControls();
                }
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that 
            // you are handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
            FBSession sess = FBSession.ActiveSession;

            if (sess.LoggedIn)
            {
                LoginButton.Content = "Logout";
                Calendar cal = new Calendar();
                cal.SetDateTime(sess.AccessTokenData.ExpirationDate);

                AccessTokenText.Text = sess.AccessTokenData.AccessToken;

                ExpirationDateText.Text = cal.DayOfWeekAsString() + "," +
                    cal.YearAsString() + "/" + cal.MonthAsNumericString() +
                    "/" + cal.DayAsString() + ", " + cal.HourAsPaddedString(2) +
                    ":" + cal.MinuteAsPaddedString(2) + ":" +
                    cal.SecondAsPaddedString(2);
            }
            else
            {
                App.InitializeFBSession();
            }
        }

        private async void login_OnClicked(object sender, RoutedEventArgs e)
        {
            FBSession sess = FBSession.ActiveSession;
            if (sess.LoggedIn)
            {
                LoginButton.Content = "Login";
                await sess.LogoutAsync();
                //Navigate back to same page, to clear out logged in info.
                App.RootFrame.Navigate(typeof(MainPage));
            }
            else
            {
                LoginButton.Content = "Logout";
                FBResult result = await sess.LoginAsync(BuildPermissions(), GetLoginBehavior());

                // There may be other cases where an a failed login request should
                // prompt the app to retry login, but this one is common enough that
                // it's helpful to demonstrate handling it here.  If the predicate
                // returns TRUE, the user has gone to facebook.com in the browser,
                // and removed our app from their list off allowed apps in Settings.
                if (WasAppPermissionRemovedByUser(result))
                {
                    await sess.LogoutAsync();
                    await TryRerequest(true);
                }
                else if (ShouldRerequest(result))
                {
                    await TryRerequest(false);
                }
                else if (result.Succeeded)
                {
                    UpdateXamlControls();
                }
            }
        }

        private void LayoutRoot_Loaded(Object sender, Windows.UI.Xaml.RoutedEventArgs args)
        {
            UpdateXamlControls();
        }
        private void UpdateXamlControls()
        {
            FBSession sess = FBSession.ActiveSession;
            if (sess.LoggedIn)
            {
                LoginButton.Content = "Logout";
                AccessTokenText.Text = sess.AccessTokenData.AccessToken;
                DateTimeFormatter dateFormatter = new DateTimeFormatter(
                     "{year.full(4)}-{month.integer(2)}-{day.integer(2)} " +
                     "{hour.integer(2)}:{minute.integer(2)}:{second.integer(2)}");
                ExpirationDateText.Text = dateFormatter.Format(sess.AccessTokenData.ExpirationDate);
                UserInfoButton.IsEnabled = true;
                DialogsPageButton.IsEnabled = true;
            }
            else
            {
                LoginButton.Content = "Login To FB";
                AccessTokenText.Text = "";
                ExpirationDateText.Text = "";
                UserInfoButton.IsEnabled = false;
                DialogsPageButton.IsEnabled = false;
            }

        }


        async void UserInfoButton_Click(Object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
            {
                Frame.Navigate(typeof(UserInfo));
            });
        }


        async void DialogsPageButton_Click(Object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
            {
                Frame.Navigate(typeof(Dialogs));
            });
        }
        SessionLoginBehavior GetLoginBehavior()
        {
            ComboBoxItem selectedLoginMethod = (ComboBoxItem)LoginMethodComboBox.SelectedItem;
            String text = (String)selectedLoginMethod.Content;
            if (String.CompareOrdinal(text, "WebView") == 0)
            {
                return SessionLoginBehavior.WebView;
            }
            if (String.CompareOrdinal(text, "WebAuth") == 0)
            {
                return SessionLoginBehavior.WebAuth;
            }
            if (String.CompareOrdinal(text, "WebAccountProvider") == 0)
            {
                return SessionLoginBehavior.WebAccountProvider;
            }
            if (String.CompareOrdinal(text, "DefaultOrdering") == 0)
            {
                return SessionLoginBehavior.DefaultOrdering;
            }
            if (String.CompareOrdinal(text, "Silent") == 0)
            {
                return SessionLoginBehavior.Silent;
            }
            throw new ArgumentException();
        }


    }
}
