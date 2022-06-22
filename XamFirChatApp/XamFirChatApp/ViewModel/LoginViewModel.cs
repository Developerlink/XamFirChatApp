using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamFirChatApp.ViewModel.Helpers;

namespace XamFirChatApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
                NotifyPropertyChanged("CanRegister");
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyPropertyChanged("Email");
                NotifyPropertyChanged("CanLogin");
                NotifyPropertyChanged("CanRegister");
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged("Password");
                NotifyPropertyChanged("CanLogin");
                NotifyPropertyChanged("CanRegister");
            }
        }

        private string _confirmedPassword;

        public string ConfirmedPassword
        {
            get { return _confirmedPassword; }
            set
            {
                _confirmedPassword = value;
                NotifyPropertyChanged(nameof(ConfirmedPassword));
                NotifyPropertyChanged("CanRegister");
            }
        }

        public bool CanLogin
        {
            get
            {
                return !string.IsNullOrEmpty(Email) 
                    && !string.IsNullOrEmpty(Password);
            }
        }

        public bool CanRegister
        {
            get
            {
                return !string.IsNullOrEmpty(Name)
                    && !string.IsNullOrEmpty(Email)
                    && !string.IsNullOrEmpty(Password)
                    && !string.IsNullOrEmpty(ConfirmedPassword);
            }
        }


        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }


        public LoginViewModel()
        {
            LoginCommand = new Command(Login, LoginCanExecute);
            RegisterCommand = new Command(Register, RegisterCanExecute);
        }

        private bool LoginCanExecute(object parameter)
        {
            return CanLogin;
        }

        private async void Login(object parameter)
        {
            await AuthHelper.AuthenticateUser(Email, Password);
        } 

        private bool RegisterCanExecute(object parameter)
        {
            return CanRegister;
        }

        private async void Register(object parameter)
        {
            if (Password != ConfirmedPassword)
            {
                App.Current.MainPage.DisplayAlert("Error", "Passwords do not match.", "Ok");
            }
            await AuthHelper.RegisterUser(Name, Email, Password);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
