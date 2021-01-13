using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.ViewModels.Commands;
using TravelRecordApp.Views;

namespace TravelRecordApp.ViewModels
{
    public class HomeVM
    {
        public NavigationCommand NavCommand { get; set; }

        public HomeVM() //Constructed with the NavigationCommand object and access to all the navigation methods.
        {
            NavCommand = new NavigationCommand(this);
        }

        public void Navigate()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewClientPage());
        }
    }
}
