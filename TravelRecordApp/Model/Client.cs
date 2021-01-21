using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecordApp.Model
{
   public class Client : INotifyPropertyChanged 
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


        public event PropertyChangedEventHandler PropertyChanged;

        public static void Insert(Client client)
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Client>();
                int rows = conn.Insert(client);

                //if (rows > 0)
                //{
                //    DisplayAlert("Success", "Client successfully added", "Ok");
                //}
                //else
                //    DisplayAlert("Failure", "Failed to add client", "Ok");
            }

        }

        public static List<Client> Read()
        {
            List<Client> clients;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Client>();
                clients = conn.Table<Client>().ToList();
               
            }
            return clients;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
