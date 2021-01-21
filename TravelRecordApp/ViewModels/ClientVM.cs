using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModels
{
    public class ClientVM
    {

        public ObservableCollection<Client> Clients { get; set; }
        public ClientVM()
        {
            Clients = new ObservableCollection<Client>();
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
    }
}
