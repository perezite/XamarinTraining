using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LayoutContainer
{
    public partial class MainPage : ContentPage
    {
        private bool toggled = false;

        public MainPage()
        {
            InitializeComponent();
            //MyLayout.Resources["CurrentButtonStyle"] = MyLayout.Resources["LightButtonStyle"];
            //MyLayout.Resources["CurrentLayoutStyle"] = MyLayout.Resources["LightLayoutStyle"];
        }

        private void Button0_Clicked(object sender, EventArgs e)
        {
            // LabelDialed.Text += Button0.Text;
        }

        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            // LabelDialed.Text += ((Button)sender).Text;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            //if (toggled)
            //{
            //    MyLayout.Resources["CurrentButtonStyle"] = MyLayout.Resources["LightButtonStyle"];
            //    MyLayout.Resources["CurrentLayoutStyle"] = MyLayout.Resources["LightLayoutStyle"];
            //}
            //else
            //{
            //    MyLayout.Resources["CurrentButtonStyle"] = MyLayout.Resources["DarkButtonStyle"];
            //    MyLayout.Resources["CurrentLayoutStyle"] = MyLayout.Resources["DarkLayoutStyle"];
            //}

            //toggled = !toggled;
        }
    }
}
