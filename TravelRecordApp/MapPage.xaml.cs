//using Plugin.Permissions;
//using Plugin.Permissions.Abstractions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

//namespace TravelRecordApp
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class MapPage : ContentPage
//    {
//        public MapPage()
//        {
//            InitializeComponent();
//            GetPermissions();
//        }

//        private async void GetPermissions()
//        {
//            try
//            {
//                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
//                if (status != PermissionStatus.Granted)
//                {
//                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
//                    {
//                        await DisplayAlert("Need your location", "We need to access your location", "ok");
//                    }
//                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
//                    if (results.ContainsKey(Permission.LocationWhenInUse))
//                    {
//                        status = results[Permission.LocationWhenInUse];
//                    }

//                    if (status == PermissionStatus.Granted)
//                    {
//                        locationsMap.IsShowingUser = true;
//                    }
//                    else
//                    {
//                        await DisplayAlert("Location denied", "You didn't give us permission to access location, so we can't show you.", "Ok");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                await DisplayAlert("Error", ex.Message, "Ok");
//            }
//        }
//    }
//}

using System;

using Xamarin.Essentials;

using Xamarin.Forms;



namespace TravelRecordApp

{

    public partial class MapPage : ContentPage

    {

        public MapPage()

        {

            InitializeComponent();

            GetPermissions();

        }



        private async void GetPermissions()

        {

            try

            {

                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (status != PermissionStatus.Granted)

                {

                    var results = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                    if (results.HasFlag(PermissionStatus.Granted))

                    {

                        status = results;

                    }

                }

                if (status == PermissionStatus.Granted)

                    locationsMap.IsShowingUser = true;

                else

                    await DisplayAlert("Location denied", "You didn't give us permission to access location, so we can't show you on the map", "Ok");

            }

            catch (Exception e)

            {

                await DisplayAlert("Error", e.Message, "Ok");

            }

        }

    }

}