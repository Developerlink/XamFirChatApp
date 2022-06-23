using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamFirChatApp.ViewModel.Helpers;

namespace XamFirChatApp.ViewModel
{
    public class ChatRoomViewModel : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; 
            NotifyPropertyChanged("Name");
            }
        }

        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; 
            NotifyPropertyChanged(nameof(IsActive));
            }
        }

        public ICommand SaveSupscriptionCommand { get; set; }


        public ChatRoomViewModel()
        {
            SaveSupscriptionCommand = new Command(SaveSupscription, SaveSupscriptionCanExecute);
        }

        private bool SaveSupscriptionCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void SaveSupscription(object parameter)
        {
            FirestoreHelper.InsertSubscription(new Model.Subscription
            {
                IsActive = IsActive,
                Name = Name,
                UserId = AuthHelper.GetCurrentUserId(),
                SupscriptionDate = DateTime.Now
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
