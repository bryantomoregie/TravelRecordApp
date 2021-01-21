﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Views;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TravelRecordApp.ViewModels;

namespace TravelRecordApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientsPage : ContentPage
    {
        ClientVM viewModel;
        public ClientsPage()
        {
            InitializeComponent();
            viewModel = new ClientVM();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.ClientList();

            //List<Client> clients = Client.Read();

            //clientListView.ItemsSource = clients;


        }

        //private void clientListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var selectedClient = clientListView.SelectedItem as Client;

        //    if (selectedClient != null)
        //    {
        //        Navigation.PushAsync(new ClientDetailPage(selectedClient));
        //    }
        //}
    }
}