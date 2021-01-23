using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModels.Commands;
using TravelRecordApp.Views;

namespace TravelRecordApp.ViewModels
{
    class RegisterVM : INotifyPropertyChanged
    {
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,                  
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                };
                OnPropertyChanged("Password");
            }
        }

        private User user;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterCommand RegisterCommand { get; set; }

        public RegisterVM()
        {
            RegisterCommand = new RegisterCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Register()
        {
            User.Insert(user);
            App.Current.MainPage.DisplayAlert("Success", "Account has been created!", "Ok");
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}
