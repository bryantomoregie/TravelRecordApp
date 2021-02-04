using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using TravelRecordApp.ViewModels.Commands;
using Xamarin.Essentials;
using TravelRecordApp.Model;
using System.Runtime.CompilerServices;

namespace TravelRecordApp.ViewModels
{
    public class LocationVM : INotifyPropertyChanged

    {
        //public List<Model.Location> Locations;
        public LocationCommand LocationCommand { get; set; }
        public Model.Location Location { get; set; }
        public LocationVM()
        {
            LocationCommand = new LocationCommand(this);
            Location = new Model.Location();
            
        }

        
        private double longitude { get; set; }

        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        private double latitude { get; set; }

        public double Latitude
        {
            get { return latitude; }
            set 
            { latitude = value;
              OnPropertyChanged("Latitude");
                OnPropertyChanged("CurrentLocation");
            }
        }


        private DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged("DateTime");
                OnPropertyChanged("CurrentLocation");
            }
        }

        private string currentLocation;

        public string CurrentLocation 
        {
            get { return $"Current Longitude: {Longitude} Current Latitude: {Latitude}"; }
            set
            {
                CurrentLocation = value;
                OnPropertyChanged("CurrentLocation");
            }
        }

      

        //public string YourLocation
        //{
        //    get
        //    {
        //        return $"Current Longitude: {longitude} Current Latitude: {latitude}";
        //    }
        //    set
        //    {
        //        longitude = longitude;
        //        latitude = latitude;
        //        OnPropertyChanged("YourLocation");
        //    }

        //}


        //public string YourLocation
        //{
        //    get
        //    {
        //        if (Locations != null && Locations.Count > 0)
        //        {
        //            return
        //            $"Longitude: {Locations[Locations.Count - 1].Longitude}" +
        //            $" Latitude: {Locations[Locations.Count - 1].Latitude}";
        //        }
        //        else
        //        {

        //            return "Placeholder";
        //        }
        //    }
        //}

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
                    latitude = location.Latitude;
                    longitude = location.Longitude;
                    dateTime = DateTime.Now;
                    Model.Location.Insert(Location);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Something is wrong: {ex}");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;



        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
