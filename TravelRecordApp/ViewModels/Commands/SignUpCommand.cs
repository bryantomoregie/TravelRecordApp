using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModels.Commands
{
    public class SignUpCommand : ICommand
    {

        public LoginVM ViewModel { get; set; }
        
        public event EventHandler CanExecuteChanged;
        public SignUpCommand(LoginVM viewModel)
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
