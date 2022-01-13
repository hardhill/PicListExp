using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicListExp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCat : ContentView
    {
        public event EventHandler Clicked;
        public static readonly BindableProperty SelectLabelProperty = BindableProperty.Create("Text",typeof(string), typeof(SelectCat), default(string));
        public string Text { get { return (string)GetValue(SelectLabelProperty); } set { SetValue(SelectLabelProperty, value); } }

        public SelectCat()
        {
            InitializeComponent();
            innerLabel.SetBinding(Label.TextProperty, new Binding("Text", source: this));
        }
    }
}