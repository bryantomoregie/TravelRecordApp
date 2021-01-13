using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecordApp.ViewModels.Commands;
using TravelRecordApp.Views;

namespace TravelRecordApp.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        public LoginCommand LoginCommand { get; set; }
        public SignUpCommand SignUpCommand { get; set; }

        public LoginVM()
        {
            LoginCommand = new LoginCommand(this);
            SignUpCommand = new SignUpCommand(this);
        }

        private string email = string.Empty;

        public string Email
        {
            get { return email; }
            set 
            { 
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Login()
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                App.Current.MainPage.DisplayAlert("Error", "Try Again", "Ok");
            }
            else
            {
                App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
        }

        public void Register()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
