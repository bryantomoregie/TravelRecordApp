using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModels.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginVM ViewModel { get; set; }

        public LoginCommand(LoginVM viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //var user = (User)parameter;

            //if(user == null)
            //{
            //    return false;
            //}
            //if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            //{
            //    return false;
            //}
            return true; //105 7:27
        }

        public void Execute(object parameter)
        {
            ViewModel.Login();
        }
    }
}
