using PicListExp.Models;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicListExp
{
    public partial class App : Application
    {
        static LandmarkDB landmarkDB;
        public static LandmarkDB LandmarkDB
        {
            get
            {
                if (landmarkDB == null)
                {
                    var connectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LandmarkDatabase.db3");
                    landmarkDB = new LandmarkDB(connectionString);
                }
                return landmarkDB;
            }
            
        }
        public App()
        {
            InitializeComponent();
           
            MainPage = new NavigationPage( new MainPage());
        }
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
