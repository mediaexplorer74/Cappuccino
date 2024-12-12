using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Cappuccino.Core.Network;
using Xamarin.Forms.Xaml;

namespace Cappuccino.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
	{
		public ProfilePage()
		{
			InitializeComponent();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await new ApiMethod<Core.Network.Methods.Account.GetCounters>("account.get")
                .AddParam("count", 1)
                .AddParam("fields", RequestConstants.UserDefaults())
                .OnSuccess(response => profile_test.Text = response.ToString())//.Inner!.Items![0].FirstName)
                .OnError(error => profile_test.Text = error.Message)
                .GetAsync(/*CancellationToken.None*/default);
        }
    }
}