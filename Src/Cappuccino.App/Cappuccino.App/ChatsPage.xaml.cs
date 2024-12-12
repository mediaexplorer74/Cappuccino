using Cappuccino.Core.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cappuccino.App
{

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ChatsPage : ContentPage
    {
        public ChatsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await new ApiMethod<Core.Network.Methods.Users.Get.Response>("users.get")
                .AddParam("count", 3)
                .AddParam("fields", RequestConstants.UserDefaults())
                .OnSuccess(response => chats_test.Text = response.Inner!.Items![0].FirstName)
                .OnError(error => chats_test.Text = error.Message)
                .GetAsync(CancellationToken.None);
        }
    }
}