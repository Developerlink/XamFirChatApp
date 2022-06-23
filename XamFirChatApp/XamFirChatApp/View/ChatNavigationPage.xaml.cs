using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamFirChatApp.ViewModel.Helpers;

namespace XamFirChatApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatNavigationPage : ContentPage
    {
        public ChatNavigationPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if(!AuthHelper.IsAuthenticated())
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}