using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cappuccino.Core.Network;
using Xamarin.Forms;

namespace Cappuccino.App
{

	public partial class ContactsPage : ContentPage
	{
		public ContactsPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await new ApiMethod<Core.Network.Methods.Friends.Get.Response>("friends.get")
				.AddParam("count", 3)
				.AddParam("fields", RequestConstants.UserDefaults())
				.OnSuccess(response => test.Text = response.Inner!.Items![0].FirstName)
				.OnError(error => test.Text = error.Message)
				.GetAsync(/*CancellationToken.None*/default);
		}
	}
}