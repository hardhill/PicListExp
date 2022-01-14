using System;
using System.Collections.Generic;
using System.IO;
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
        
        public NewPlace()
        {
           InitializeComponent();
           
        }

        protected override void OnAppearing()
        {
           base.OnAppearing();
           placeController = new PlaceControll();
           placeController.OnLocation += PlaceController_OnLocation;
           
        }

        private void PlaceController_OnLocation(LocationResult result)
        {
            if (!result.isError)
            {
                lblLocation.TextColor = Color.Blue;
                lblLocation.Text = $"lat:{result.Location.Latitude}\nlon:{result.Location.Longitude}";
            }
            else
            {
                lblLocation.TextColor = Color.Red;
                lblLocation.Text = "no location";
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
           var stream  = await placeController.SetImage(true);
           imgPhoto.Source = ImageSource.FromStream(() => stream);
            //TODO save image to file

        }

        private async void btnPickImage_Clicked(object sender, EventArgs e)
        {
            var stream = await placeController.SetImage(false);
            imgPhoto.Source = ImageSource.FromStream(() => stream);
        }

        private async void btnSaveData_Clicked(object sender, EventArgs e)
        {
            var n =placeController.SaveData();
            if(n!=0)
                await Navigation.PopToRootAsync();
        }

        private async void btnGPS_Clicked(object sender, EventArgs e)
        {
            await placeController.GetLocationAsync();
           
        }

        private void WriteToFile(Stream stream, string destinationFile, int bufferSize = 4096, FileMode mode = FileMode.OpenOrCreate, FileAccess access = FileAccess.ReadWrite, FileShare share = FileShare.ReadWrite)
        {
            using (var destinationFileStream = new FileStream(destinationFile, mode, access, share))
            {
                while (stream.Position < stream.Length)
                {
                    destinationFileStream.WriteByte((byte)stream.ReadByte());
                }
            }
        }
    }
}