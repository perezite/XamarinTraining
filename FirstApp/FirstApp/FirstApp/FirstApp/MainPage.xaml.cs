using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            myLabel.Text = "My new Text";
            myLabel.HeightRequest = 100;    
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // await DisplayAlert("Mein Titel", "Nachricht", "Abbrechen");
            // var result = await DisplayAlert("Titel", "Nachricht", "Ja", "Nein");

            var result = await DisplayActionSheet("Wähle deine Farbe", null, null, "Rot", "Grün", "Blau");
            await DisplayAlert("", $"Deine Antwort {result}", "Abbrechen");
        }
    }
}
