using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        HomeVM viewModel;
        public HomePage()
        {
            InitializeComponent();
            viewModel = new HomeVM();
            BindingContext = viewModel; //Here I have bound the homepage view to the homepage view model. 
        }

    
    }
}