﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModels.Commands;
using TravelRecordApp.Views;

namespace TravelRecordApp.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {

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

        public LoginCommand LoginCommand { get; set; }
        public SignUpCommand SignUpCommand { get; set; }

        public LoginVM()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
            SignUpCommand = new SignUpCommand(this);
        }

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
                    Password = this.Password
                };
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
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Login()
        {
            bool canLogin = User.Login(User.Email, User.Password);

            if (canLogin)
                App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
                App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");
        }

        public void Register()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
