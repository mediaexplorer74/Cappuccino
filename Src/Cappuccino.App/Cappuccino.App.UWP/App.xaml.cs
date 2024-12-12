using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Cappuccino.Core.Network.Config;
using Cappuccino.Core.Network.Handlers;
using Cappuccino.Core.Network.Models;
using System.Globalization;
using Scope = Cappuccino.Core.Network.Auth.Permissions;

namespace Cappuccino.App.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {

        private const int APP_ID = 7317599;
        private const int LONGPOLL_VERSION = 12;
        private const string API_VERSION = "5.131";


        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
               // this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            
            //*************************************

            CredentialsManager.ApplyConfiguration(new ApiConfiguration.Builder()
            .WithApiLanguage(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
            .WithAppId(APP_ID)
            .WithApiVersion(API_VERSION)
            .WithLongPollVersion(LONGPOLL_VERSION)
            .WithTokenStorageHandler(new TokenStorageProvider())
#if DEBUG
            .WithPermissions(new[] { Scope.Friends, Scope.Messages })
#else
            .WithPermissions(new[] { Scope.Friends, Scope.Messages, Scope.Offline })
#endif
            .Build()
        );


            // ************************************

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;
                
                Xamarin.Forms.Forms.Init(e);

                // The actual style switching
                //((Style)this.Resources["TabbedPageStyle"]).Setters[0] = ((Style)this.Resources["TabbedPageStyle2"]).Setters[0];

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
              
                //TODO
                //TokenExpiredHandler.Expired += TokenExpired;

                
                if (CredentialsManager.IsInternalTokenValid())
                {
                    //MainPage = new RootPage();

                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                else
                {
                    //MainPage = new AuthPage();

                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                                
                //rootFrame.Navigate(typeof(MainPage), e.Arguments);

            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private /*override*/ void CleanUp()
        {
            TokenExpiredHandler.Expired -= TokenExpired;
            //base.CleanUp();
        }

        private void TokenExpired(ErrorResponse response)
        {
            //TODO
            //MainPage = new AuthPage();
        }
    }
}
