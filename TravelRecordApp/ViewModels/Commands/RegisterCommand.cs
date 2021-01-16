using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModels.Commands
{
    class RegisterCommand : ICommand
    {
        public RegisterVM ViewModel { get; set; }
        
        public event EventHandler CanExecuteChanged;

        public RegisterCommand(RegisterVM viewModel )
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.Register();
        }
    }
}
