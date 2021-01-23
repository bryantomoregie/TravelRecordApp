using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewClientPage : ContentPage
    {
        Client client;
        public NewClientPage()
        {
            InitializeComponent();
            client = new Client();
            containerStackLayout.BindingContext = client; //this will take input from ui and create a new client. I have bound the ui to the client object I instantiated
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
           
            Client.Insert(client);
            DisplayAlert("Success", "Client successfully added", "Ok");
            App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

    }
}
