using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicListExp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPlace : ContentPage
    {
        PlaceControll placeController;
        LocationResult placeLocation;
        public NewPlace()
        {
           InitializeComponent();
           
        }

        protected override void OnAppearing()
        {
           base.OnAppearing();
           placeController = new PlaceControll();
            placeLocation = new LocationResult();
            placeController.OnLocation += PlaceController_OnLocation;
        }

        private void PlaceController_OnLocation(LocationResult result)
        {
            if (!result.isError)
            {
                btnSaveData.IsEnabled = true;
            }
            else
            {
                btnSaveData.IsEnabled = false;
            }
        }

        protected override void OnDisappearing()
        {
            placeController.Destroy();
            base.OnDisappearing();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            btnFotoCreate_Clicked(sender, e);
        }

        private async void btnFotoCreate_Clicked(object sender, EventArgs e)
        {
           imgPhoto.Source = await placeController.SetImage(true);
            
        }

        private async void btnPickImage_Clicked(object sender, EventArgs e)
        {
            imgPhoto.Source = await placeController.SetImage(false);
        }

        private async void btnSaveData_Clicked(object sender, EventArgs e)
        {
            placeController.SaveData();
            await Navigation.PopToRootAsync();
        }

        private async void btnGPS_Clicked(object sender, EventArgs e)
        {
            placeLocation = await placeController.GetLocationAsync();
            if (!placeLocation.isError)
            {
                lblLocation.TextColor = Color.Blue;
                lblLocation.Text = $"lat:{placeLocation.Location.Latitude} lon:{placeLocation.Location.Longitude}";
            }
        }
    }
}