using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModels.Commands
{
    public class LocationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public LocationVM LocationVM { get; set; }
        public LocationCommand(LocationVM locationVM)
        {
            LocationVM = locationVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LocationVM.GetLocation();
        }
    }
}
