using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Einkaufsliste
{
	public partial class TodayShoppingList : ContentPage
	{
        ShoppingListService _shoppingListService = new ShoppingListService();

		public TodayShoppingList()
		{
			InitializeComponent();
            RefreshShoppingList();
            _shoppingListService.ShoppingItems.CollectionChanged += ShoppingItems_CollectionChanged;
		}

        private void ShoppingItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RefreshShoppingList();
        }

        private void RefreshShoppingList()
        {
            shoppingList.ItemsSource = _shoppingListService.ShoppingItems.Where(x => x.ShoppingTime?.Date == DateTime.Today.Date);
        }
    }
}