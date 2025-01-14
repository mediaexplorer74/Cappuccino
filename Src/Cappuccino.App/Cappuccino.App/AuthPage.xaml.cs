﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cappuccino.Core.Network.Auth;
using Xamarin.Forms;

namespace Cappuccino.App
{

	public partial class AuthPage : ContentPage
	{
		private ImplicitAuthentificator authentificator;

		public AuthPage()
		{
			this.authentificator = new ImplicitAuthentificator();

			InitializeComponent();
			BindingContext = this.authentificator.BuildAuthorizationUri();
			this.authentificator.Authorized += Authorized;
		}

		protected override void OnDisappearing()
		{
			this.authentificator.Authorized -= Authorized;
			base.OnDisappearing();
		}

		private void Authorized(object? sender, EventArgs e)
		{
			if (Application.Current != null)
				Application.Current.MainPage = new RootPage();
		}

		private void WebViewNavigating(object sender, WebNavigatingEventArgs e)
		{
			var uri = e.Url?.ToString() ?? string.Empty;
			this.authentificator.TryAuthorizeFromUri(uri);
		}
	}
}