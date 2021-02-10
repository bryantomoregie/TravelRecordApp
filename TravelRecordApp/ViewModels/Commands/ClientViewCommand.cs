using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecordApp.Views;

namespace TravelRecordApp.ViewModels.Commands
{
    public class ClientViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ClientVM ViewModel { get; set; }

        public ClientViewCommand(ClientVM viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.ClientDetails();
        }
    }
}
