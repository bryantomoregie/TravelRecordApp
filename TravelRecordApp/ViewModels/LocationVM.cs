using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using TravelRecordApp.ViewModels.Commands;
using Xamarin.Essentials;

namespace TravelRecordApp.ViewModels
{
    public class LocationVM : INotifyPropertyChanged

    {
        public List<Location> Locations { get; set; }

        public LocationVM()
        {
             
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                 Locations =  conn.Table<Location>().ToList();
            }
            
        }


 

        public string YourLocation
        {
            get { return $"Longitude: {Locations[Locations.Count - 1].Longitude} Latitude: {Locations[Locations.Count - 1].Latitude}"; }
        }

       

        




        public event PropertyChangedEventHandler PropertyChanged;

     

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
