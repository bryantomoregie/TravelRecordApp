using SQLite;
using System;
using System.IO;
using TravelRecordApp.Views;
using Windows.Storage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
       
        public App()
        {
            InitializeComponent();
            string documentPath = ApplicationData.Current.LocalFolder.Path;
            string path = Path.Combine(documentPath, "travel_db.sqlite");
            DatabaseLocation = path;
            MainPage = new NavigationPage(new LoginPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            DatabaseLocation = databaseLocation;

            MainPage = new NavigationPage(new LoginPage());

            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
