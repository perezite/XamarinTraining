using Navigation1.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Red, Title="Rote Page" },
                new HomeMenuItem {Id = MenuItemType.Green, Title="Grüne Page" },
                new HomeMenuItem {Id = MenuItemType.Blue, Title="Blaue Page" },
                // new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await ((App)Application.Current).RootPage.NavigateFromMenu(id);
                // await Navigation.PushModalAsync(new RedPage());
            };
        }

        private void RedButton_Clicked(object sender, EventArgs e)
        {
            RootPage.NavigateTo(new RedPage());
        }
    }
}