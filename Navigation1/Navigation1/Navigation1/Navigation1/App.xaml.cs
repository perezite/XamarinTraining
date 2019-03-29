using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Navigation1.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Navigation1
{
    public partial class App : Application
    {

        public MainPage RootPage { get; set; }

        public App()
        {
            InitializeComponent();

            RootPage = new MainPage();
            MainPage = new Login();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
