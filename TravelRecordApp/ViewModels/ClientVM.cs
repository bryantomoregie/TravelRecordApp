using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModels.Commands;
using TravelRecordApp.Views;

namespace TravelRecordApp.ViewModels
{
    public class ClientVM : INotifyPropertyChanged 
    {

        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public ObservableCollection<Client> Clients { get; set; }
        public ClientViewCommand ClientViewCommand { get; set; }

        private Client client;

        public event PropertyChangedEventHandler PropertyChanged;

        public ClientVM()
        {
            client = new Client();
            Clients = new ObservableCollection<Client>();
            ClientViewCommand = new ClientViewCommand(this);
        }


        public bool ClientList()
        {
            try
            {
                var clients = Client.Read();
                if (clients != null)
                {
                    Clients.Clear();
                    foreach (var client in clients)
                        Clients.Add(client);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClientDetails()
        {
            App.Current.MainPage.Navigation.PushAsync(new ClientDetailPage(client));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
