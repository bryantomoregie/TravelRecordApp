using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModels.Commands;
using TravelRecordApp.Views;
using Xamarin.Essentials;

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
        public Model.Location _location { get; set; }

        public LoginVM()
        {
            User = new User();
            _location = new Model.Location();
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

        public async void GetLocation()
        {
            try
            {

                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });

                if (location == null)
                {
                   App.Current.MainPage.DisplayAlert("Error", "Please set location", "Ok");
                }
                else
                {
                    _location.Latitude = location.Latitude;
                    _location.Longitude = location.Longitude;
                    _location.DateTime = location.Timestamp;
                    Model.Location.Insert(_location);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Something is wrong: {ex}");
            }
        }

        public void Login()
        {
            string canLogin = User.Login(User.Email, User.Password);

            if (canLogin == "login")
                GetLocation();
            App.Current.MainPage.Navigation.PushAsync(new HomePage());
            if(canLogin == "nonExistent")
                App.Current.MainPage.DisplayAlert("Error", "User does not exist. Please Sign up.", "Ok");
            if(canLogin == "wrongPassword")
                App.Current.MainPage.DisplayAlert("Error", "Wrong Password", "Ok");
        }

        public void Register()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
