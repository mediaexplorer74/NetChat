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
// App.xaml.cpp
// Implementation of the App class.
//

#include "pch.h"
#include "MainPage.xaml.h"
#include "UserInfo.xaml.h"

using namespace LoginCpp;

using namespace concurrency;
using namespace Platform;
using namespace Windows::ApplicationModel;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::ApplicationModel::Core;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Core;
using namespace Windows::UI::Xaml::Media::Animation;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Interop;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace winsdkfb;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

/// <summary>
/// Initializes the singleton application object. This is the first line of authored code
/// executed, and as such is the logical equivalent of main() or WinMain().
/// </summary>
App::App()
{
	InitializeComponent();
	Suspending += ref new SuspendingEventHandler(this, &App::OnSuspending);
}

Frame^ App::CreateRootFrame()
{
	Frame^ rootFrame = dynamic_cast<Frame^>(Window::Current->Content);

	if (rootFrame == nullptr)
	{
		// Create a Frame to act as the navigation context 
		rootFrame = ref new Frame();

		// Set the default language
		rootFrame->Language = Windows::Globalization::ApplicationLanguages::Languages->GetAt(0);

		// Place the frame in the current Window
		Window::Current->Content = rootFrame;
	}

	return rootFrame;
}

/// <summary>
/// Invoked when the application is launched normally by the end user. Other entry points
/// will be used when the application is launched to open a specific file, to display
/// search results, and so forth.
/// </summary>
/// <param name="e">Details about the launch request and process.</param>
void App::OnLaunched(LaunchActivatedEventArgs^ e)
{
#if _DEBUG
	if (IsDebuggerPresent())
	{
		DebugSettings->EnableFrameRateCounter = true;
	}
#endif

	auto rootFrame = dynamic_cast<Frame^>(Window::Current->Content);

	// Do not repeat app initialization when the Window already has content,
	// just ensure that the window is active.
	if (rootFrame == nullptr)
	{
		// Create a Frame to act as the navigation context and associate it with
		// a SuspensionManager key
		rootFrame = ref new Frame();

		// TODO: Change this value to a cache size that is appropriate for your application.
		rootFrame->CacheSize = 1;

		if (e->PreviousExecutionState == ApplicationExecutionState::Terminated)
		{
			// TODO: Restore the saved session state only when appropriate, scheduling the
			// final launch steps after the restore is complete.
		}

		// Place the frame in the current Window
		Window::Current->Content = rootFrame;

        SystemNavigationManager::GetForCurrentView()->BackRequested += ref new Windows::Foundation::EventHandler<Windows::UI::Core::BackRequestedEventArgs ^>(this, &LoginCpp::App::OnBackRequested);
        rootFrame->Navigated += ref new Windows::UI::Xaml::Navigation::NavigatedEventHandler(this, &LoginCpp::App::OnNavigated);
	}

	if (rootFrame->Content == nullptr)
	{
#if WINAPI_FAMILY==WINAPI_FAMILY_PHONE_APP
		// Removes the turnstile navigation for startup.
		if (rootFrame->ContentTransitions != nullptr)
		{
			_transitions = ref new TransitionCollection();
			for (auto transition : rootFrame->ContentTransitions)
			{
				_transitions->Append(transition);
			}
		}

		rootFrame->ContentTransitions = nullptr;
		_firstNavigatedToken = rootFrame->Navigated += ref new NavigatedEventHandler(this, &App::RootFrame_FirstNavigated);
#endif

		// When the navigation stack isn't restored navigate to the first page,
		// configuring the new page by passing required information as a navigation
		// parameter.
		if (!rootFrame->Navigate(MainPage::typeid, e->Arguments))
		{
			throw ref new FailureException("Failed to create initial page");
		}
	}

	// Ensure the current window is active
	Window::Current->Activate();
}

#if WINAPI_FAMILY==WINAPI_FAMILY_PHONE_APP
/// <summary>
/// Restores the content transitions after the app has launched.
/// </summary>
void App::RootFrame_FirstNavigated(Object^ sender, NavigationEventArgs^ e)
{
	auto rootFrame = safe_cast<Frame^>(sender);

	TransitionCollection^ newTransitions;
	if (_transitions == nullptr)
	{
		newTransitions = ref new TransitionCollection();
		newTransitions->Append(ref new NavigationThemeTransition());
	}
	else
	{
		newTransitions = _transitions;
	}

	rootFrame->ContentTransitions = newTransitions;

	rootFrame->Navigated -= _firstNavigatedToken;
}

void App::OnActivated(IActivatedEventArgs^ e)
{
	// Check for activation via protocol.  This code assumes the only protocol
	// supported by our app is the Facebook redirect protocol (msft-<GUID>).
	// If your app supports multiple protocols, you'll have to filter here.
	if (e->Kind == Windows::ApplicationModel::Activation::ActivationKind::Protocol)
	{
		ProtocolActivatedEventArgs^ p = safe_cast<ProtocolActivatedEventArgs^>(e);
		FBSession^ sess = FBSession::ActiveSession;

		// FinishOpenViaFBApp retrieves basic user info via Facebook graph API,
		// storing it in the Session::User property.  After this async
		// action completes, the user info will be valid (assuming login 
		// success).
		create_task(sess->ContinueAction(p))
			.then([this](task<FBResult^> resultTask)
		{
			try
			{
				FBResult^ result = resultTask.get();
				if (result)
				{
					if (result->Succeeded)
					{
						// We're redirecting to a page that shows simple user info, so 
						// have to dispatch back to the UI thread.
						CoreWindow^ wind = CoreApplication::MainView->CoreWindow;

						if (wind)
						{
							CoreDispatcher^ disp = wind->Dispatcher;
							if (disp)
							{
								disp->RunAsync(
									Windows::UI::Core::CoreDispatcherPriority::Normal,
									ref new Windows::UI::Core::DispatchedHandler([this]()
								{
									this->CreateRootFrame()->Navigate(UserInfo::typeid);
								}));
							}
						}
					}
					else
					{
						String^ msg = "ERROR: code " +
							result->ErrorInfo->Code.ToString() + ", Reason '" +
							result->ErrorInfo->Type + "', Message '" +
							result->ErrorInfo->Message + "'";
						OutputDebugString(msg->Data());
					}
				}
			}
			catch (COMException^ ex)
			{
				//TODO: Handle errors here
				OutputDebugString(L"Exception in continuation of login");
			}
		});
	}
}
#endif

/// <summary>
/// Invoked when application execution is being suspended. Application state is saved
/// without knowing whether the application will be terminated or resumed with the contents
/// of memory still intact.
/// </summary>
void App::OnSuspending(Object^ sender, SuspendingEventArgs^ e)
{
	(void)sender;	// Unused parameter
	(void)e;		// Unused parameter

					// TODO: Save application state and stop any background activity
}


void LoginCpp::App::OnBackRequested(Platform::Object^ sender, Windows::UI::Core::BackRequestedEventArgs ^args)
{
    Frame^ rootFrame = dynamic_cast<Frame^>(Window::Current->Content);
    if (rootFrame->CanGoBack)
    {
        args->Handled = true;
        rootFrame->GoBack();
    }
}

void LoginCpp::App::OnNavigated(Platform::Object^ sender, Windows::UI::Xaml::Navigation::NavigationEventArgs^ args)
{

    Frame^ rootFrame = dynamic_cast<Frame^>(Window::Current->Content);
    if (rootFrame->CanGoBack) 
    {
        SystemNavigationManager::GetForCurrentView()->AppViewBackButtonVisibility = AppViewBackButtonVisibility::Visible;
    }
    else
    {
        SystemNavigationManager::GetForCurrentView()->AppViewBackButtonVisibility = AppViewBackButtonVisibility::Collapsed;
    }
}
