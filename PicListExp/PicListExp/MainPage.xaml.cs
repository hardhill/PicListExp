using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PicListExp
{
    public partial class MainPage : ContentPage
    {
        public IList<Place> PlaceList { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            PlaceList = new List<Place>();
            PlaceList.Add(new Place() { Name = "Королев", Description = "Город где живет Сережа", Image = "https://projects.bielecki.ru/images/points/korolev.jpg" });
            PlaceList.Add(new Place() { Name = "Кострома", Description = "Наверно очень древний город", Image = "https://projects.bielecki.ru/images/points/kostroma.jpg" });
            PlaceList.Add(new Place() { Name = "Владимир", Description = "Русский город", Image = "https://projects.bielecki.ru/images/points/vladimir.jpg" });
            PlaceList.Add(new Place() { Name = "Пермь", Description = "Казарбин там работает", Image = "https://projects.bielecki.ru/images/points/perm.jpg" });
            PlaceList.Add(new Place() { Name = "Казань", Description = "Жил в этом городе целую неделю", Image = "https://projects.bielecki.ru/images/points/kazan.jpg" });
            PlaceList.Add(new Place() { Name = "Екатеринбург", Description = "Бывший Свердловск", Image = "https://projects.bielecki.ru/images/points/ekaterinburg.jpg" });
            PlaceList.Add(new Place() { Name = "Омск", Description = "Был там только на вокзале", Image = "https://projects.bielecki.ru/images/points/omsk.jpg" });
            PlaceList.Add(new Place() { Name = "Новосибирск", Description = "Метро тоже есть", Image = "https://projects.bielecki.ru/images/points/novosibirsk.jpg" });
            PlaceList.Add(new Place() { Name = "Красноярск", Description = "Нечем дышать", Image = "https://projects.bielecki.ru/images/points/krasnoyarsk.jpg" });
            PlaceList.Add(new Place() { Name = "Иркутск", Description = "Соседний город", Image = "https://projects.bielecki.ru/images/points/irkutsk.jpg" });
            PlaceList.Add(new Place() { Name = "Улан-Удэ", Description = "Родина моя", Image = "https://projects.bielecki.ru/images/points/ulan-ude.jpg" });
            BindingContext = this;
            
            base.OnAppearing();
        }

        private async void cvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Place selectedPlace = (Place)e.CurrentSelection[0];
            await DisplayAlert(selectedPlace.Name, selectedPlace.Description, "OK");
        }

        private async void bFoto_Clicked(object sender, EventArgs e)
        {
            // Open window
            await Navigation.PushAsync(new NewPlace() { });
        }
    }
}
