using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamFirChatApp.ViewModel.Helpers
{
    public interface IAuth
    {
        Task<bool> RegisterUser(string name, string email, string password);
        Task<bool> AuthenticateUser(string email, string password);
        bool IsAuthenticated();
        string GetCurrentUserId();
    }

    public class AuthHelper
    {
        private static readonly IAuth _auth = DependencyService.Get<IAuth>();
        public static async Task<bool> RegisterUser(string name, string email, string password)
        {
            try
            {
                return await _auth.RegisterUser(name, email, password);

            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");
                return false;
            }
        }

        public static async Task<bool> AuthenticateUser(string email, string password)
        {
            try
            {
                bool isAuthenticated = await _auth.AuthenticateUser(email, password);
                return isAuthenticated;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");
                return false;
            }
        }

        public bool IsAuthenticated()
        {
            return _auth.IsAuthenticated();
        }

        public string GetCurrentUserId()
        {
            return _auth.GetCurrentUserId(); 
        }
    }
}
