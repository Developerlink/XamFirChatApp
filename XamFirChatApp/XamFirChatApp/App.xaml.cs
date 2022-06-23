using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamFirChatApp.View;

namespace XamFirChatApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ChatNavigationPage());
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
