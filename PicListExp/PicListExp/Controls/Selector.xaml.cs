using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComponentExp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Selector : ContentView
    {
        public delegate void SelectorDelegate(object sender,  int index);
        public delegate void IsPrivateDelegate(object sender, bool share);
        public Selector()
        {
            InitializeComponent();
        }

        private const string HexSelectColor = "#82CCFF";
        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex),
            typeof(int), 
            typeof(Selector),defaultBindingMode:BindingMode.TwoWay,propertyChanged: TapOnFramePropertyChanged ,defaultValue:0);

        private static void TapOnFramePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Selector)bindable;
            if (control != null)
            {
                switch ((int)newValue)
                {
                    case  1  :
                        control.PicCampingTapped(control, null);
                        break;
                    case 2:
                        control.PicBeautyTapped(control, null);
                        break;
                    case 3:
                        control.PicPointTapped(control, null);
                        break;
                    case 4:
                        control.PicTrashTapped(control, null);
                        break;
                    case 5:
                        control.PicSportTapped(control, null);
                        break;
                        default:
                        control.PicLandmarkTapped(control,null);
                        break;
                }
            }
        }

        public int SelectedIndex 
        { get{
                return (int)GetValue(SelectedIndexProperty);
            }
          set {
                SetValue(SelectedIndexProperty, value);       
            } 
        }
        
        public event SelectorDelegate SelectedChanged;



        //=========================================================================
        public static readonly BindableProperty IsPrivateProperty = BindableProperty.Create(nameof(IsPrivate), typeof(bool), typeof(Selector),defaultBindingMode:BindingMode.TwoWay, defaultValue: false,propertyChanged:IsSwitchPropertyChanged);

        private static void IsSwitchPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Selector)bindable;
            control.swPrivate.IsToggled = (bool)newValue;
        }

        public bool IsPrivate { 
            get { 
                return (bool)GetValue(IsPrivateProperty); 
            } 
            set { 
                SetValue(IsPrivateProperty, value); 
            } 
        }
        
        public event IsPrivateDelegate IsPrivateChanged;

        private void PicLandmarkTapped(object sender, EventArgs e)
        {
            ResetColorBackground();
            picLandmark.BackgroundColor = Color.FromHex(HexSelectColor);
            picLandmark.HasShadow = false;
            txtInfo.Text = "Landmark";
            SelectedIndex = 0;
            SelectedChanged?.Invoke(this, SelectedIndex);
        }
        private void PicCampingTapped(object sender, EventArgs e)
        {
            ResetColorBackground();
            picCamping.BackgroundColor = Color.FromHex(HexSelectColor);
            picCamping.HasShadow = false;
            txtInfo.Text = "Camping";
            SelectedIndex = 1;
            SelectedChanged?.Invoke(this, SelectedIndex);
        }
        private void PicBeautyTapped(object sender, EventArgs e)
        {
            ResetColorBackground();
            picBeauty.BackgroundColor = Color.FromHex(HexSelectColor);
            picBeauty.HasShadow = false;
            txtInfo.Text = "Beauty Place";
            SelectedIndex = 2;
            SelectedChanged?.Invoke(this, SelectedIndex);
        }
        private void PicPointTapped(object sender, EventArgs e)
        {
            ResetColorBackground();
            picPoint.BackgroundColor = Color.FromHex(HexSelectColor);
            picPoint.HasShadow = false;
            txtInfo.Text = "Point of Interest";
            SelectedIndex = 3;
            SelectedChanged?.Invoke(this, SelectedIndex);
        }
        private void PicTrashTapped(object sender, EventArgs e)
        {
            ResetColorBackground();
            picTrash.BackgroundColor = Color.FromHex(HexSelectColor);
            picTrash.HasShadow = false;
            txtInfo.Text = "Pollution";
            SelectedIndex = 4;
            SelectedChanged?.Invoke(this, SelectedIndex);
        }
        private void PicSportTapped(object sender, EventArgs e)
        {
            ResetColorBackground();
            picSport.BackgroundColor = Color.FromHex(HexSelectColor);
            picSport.HasShadow = false;
            txtInfo.Text = "Sport place";
            SelectedIndex = 5;
            SelectedChanged?.Invoke(this, SelectedIndex);
        }

        private void ResetColorBackground()
        {
            picLandmark.BackgroundColor = Color.White;
            picCamping.BackgroundColor = Color.White;
            picBeauty.BackgroundColor = Color.White;
            picPoint.BackgroundColor = Color.White;
            picTrash.BackgroundColor = Color.White;
            picSport.BackgroundColor = Color.White;
            picLandmark.HasShadow = true;
            picCamping.HasShadow = true;
            picBeauty.HasShadow = true;
            picPoint.HasShadow = true;
            picTrash.HasShadow = true;
            picSport.HasShadow = true;
        }

        private void Switch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsToggled")
            {
                IsPrivateChanged?.Invoke(this, swPrivate.IsToggled);
            }
        }
    }
}