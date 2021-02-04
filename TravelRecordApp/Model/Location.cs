using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TravelRecordApp.Model
{
    public class Location : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set 
            {
                longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set 
            { 
                latitude = value;
                OnPropertyChanged("Latitude");
            }
        }


        private DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
            set 
            {
                dateTime = value; 
            }
        }

        //public DateTimeOffset DateTime1 { get => dateTime; set => dateTime = value; }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static void Insert(Location location)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Location>();
                int rows = conn.Insert(location);
            }
        }


    }
}
