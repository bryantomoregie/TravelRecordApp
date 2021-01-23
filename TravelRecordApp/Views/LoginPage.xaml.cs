using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.ViewModels;
using TravelRecordApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginVM viewModel;
        public LoginPage()
        {
            InitializeComponent();
            viewModel = new LoginVM();
            BindingContext = viewModel;
        }

    }
}