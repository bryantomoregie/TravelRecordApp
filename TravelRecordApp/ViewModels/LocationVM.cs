using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using TravelRecordApp.ViewModels.Commands;
using Xamarin.Essentials;

namespace TravelRecordApp.ViewModels
{
    public class LocationVM : INotifyPropertyChanged

    {
        public LocationCommand LocationCommand { get; set; }

        public LocationVM()
        {
            LocationCommand = new LocationCommand(this);
        }

        private string location_;

        public string Location
        {
            get { return location_; }
            set
            {
                location_ = value;
                OnPropertyChanged("Location");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
                    location_ = "No GPS";
                    this.Location = location_;
                }
                else
                {
                    location_ = $"Latitude: {location.Latitude} Longitude: {location.Longitude}";
                    this.Location = location_;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Something is wrong: {ex}");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
