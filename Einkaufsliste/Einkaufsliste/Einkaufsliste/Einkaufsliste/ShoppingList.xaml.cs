using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Einkaufsliste
{
    public partial class ShoppingList : ContentPage, INotifyPropertyChanged
    {
        private ShoppingListService _shoppingListService = new ShoppingListService();

        public ShoppingList()
        {
            InitializeComponent();
            newProductDate.Text = DateTime.Today.ToString("dd MM yyyy");
            shoppingList.ItemsSource = _shoppingListService.ShoppingItems;
        }

        private void DeleteAction_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var shoppingItem = menuItem.BindingContext as ShoppingItem;
            _shoppingListService.ShoppingItems.Remove(shoppingItem);
            _shoppingListService.OrderShoppingList();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newProductName.Text))
            {
                var hasShoppingTime = DateTime.TryParse(newProductDate.Text, out DateTime shoppingTime);
                _shoppingListService.ShoppingItems.Add(new ShoppingItem { Description = newProductName.Text, ShoppingTime = hasShoppingTime ? shoppingTime : (DateTime?)null });
                _shoppingListService.OrderShoppingList();
                newProductName.Text = string.Empty;
                newProductDate.Text = string.Empty;
            }
        }
    }
}
