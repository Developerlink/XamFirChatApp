using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamFirChatApp.ViewModel.Helpers;
using Firebase.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamFirChatApp.Droid.Dependencies.Auth))]
namespace XamFirChatApp.Droid.Dependencies
{
    internal class Auth : IAuth
    {
        public async Task<bool> AuthenticateUser(string email, string password)
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password); 
               
                return true;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                throw new Exception(e.Message);
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception)
            {
                throw new Exception("An unknown error occured.");
            }
        }

        public string GetCurrentUserId()
        {
            return Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
            return Firebase.Auth.FirebaseAuth.Instance.CurrentUser != null;
        }

        public async Task<bool> RegisterUser(string name, string email, string password)
        {
            try
            {
            await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            
            var profileUpdater = new Firebase.Auth.UserProfileChangeRequest.Builder();
            profileUpdater.SetDisplayName(name);
            var build = profileUpdater.Build();
            var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
            await user.UpdateProfileAsync(build);

            return true;
            }
            catch (FirebaseAuthWeakPasswordException e)
            {
                throw new Exception(e.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                throw new Exception(e.Message);
            }
            catch (FirebaseAuthUserCollisionException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception)
            {
                throw new Exception("An unknown error occured.");
            }
        }
    }
}