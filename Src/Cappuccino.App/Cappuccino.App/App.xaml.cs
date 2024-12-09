using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Globalization;

using Cappuccino.Core.Network.Config;
//using DotNet.Meteor.HotReload.Plugin;
using Cappuccino.Core.Network.Handlers;
using Cappuccino.Core.Network.Models;

using Scope = Cappuccino.Core.Network.Auth.Permissions;

namespace Cappuccino.App
{
    public partial class App : Application
    {
        //private const int APP_ID = 7317599;
        //private const int LONGPOLL_VERSION = 12;
        //private const string API_VERSION = "5.131";


        public App()
        {
            InitializeComponent();

            //*************************************
/*
            CredentialsManager.ApplyConfiguration(new ApiConfiguration.Builder()
            .WithApiLanguage(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
            .WithAppId(APP_ID)
            .WithApiVersion(API_VERSION)
            .WithLongPollVersion(LONGPOLL_VERSION)
            .WithTokenStorageHandler(new TokenStorageProvider())
//#if DEBUG
            .WithPermissions(new[] { Scope.Friends, Scope.Messages })
//#else
//            .WithPermissions(new[] { Scope.Friends, Scope.Messages, Scope.Offline })
//#endif
            .Build()
        );
            */


            // ************************************

            //MainPage = new MainPage();

            
            if (CredentialsManager.IsInternalTokenValid())
            {
                MainPage = new RootPage();
            }
            else
            {
                MainPage = new AuthPage();
                //MainPage = new RootPage();
            }
            
            
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
