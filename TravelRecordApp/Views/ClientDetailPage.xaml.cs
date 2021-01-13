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
    public partial class ClientDetailPage : ContentPage
    {
        Client selectedClient;

        public ClientDetailPage(Client selectedClient)
        {
            InitializeComponent();
            this.selectedClient = selectedClient;

            nameEntry.Text = selectedClient.Name;
            emailEntry.Text = selectedClient.Email;
            phoneEntry.Text = selectedClient.Phone;
            addressEntry.Text = selectedClient.Address;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            selectedClient.Name = nameEntry.Text;
            selectedClient.Email = emailEntry.Text;
            selectedClient.Phone = phoneEntry.Text;
            selectedClient.Address = addressEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedClient);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Client succesfully updated", "Ok");
                }
                else
                    DisplayAlert("Failure", "Client failed to be updated", "Ok");
            }
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedClient);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Client succesfully deleted", "Ok");
                }
                else
                    DisplayAlert("Failure", "Client failed to be deleted", "Ok");
            }
        }
    }
}