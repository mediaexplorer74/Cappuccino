using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Cappuccino.Core.Network;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cappuccino.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
				.OnSuccess(response => contacts_test.Text = response.Inner!.Items![0].FirstName)
				.OnError(error => contacts_test.Text = error.Message)
				.GetAsync(CancellationToken.None);
		}
	}
}