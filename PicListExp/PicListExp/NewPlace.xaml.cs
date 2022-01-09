using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicListExp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPlace : ContentPage
    {
        public NewPlace()
        {
            InitializeComponent();
            

        }

        protected override void OnAppearing()
        {
           
            base.OnAppearing();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}