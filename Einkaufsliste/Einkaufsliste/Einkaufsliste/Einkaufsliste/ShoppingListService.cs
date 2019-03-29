using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Einkaufsliste
{
    public class ShoppingListService
    {
        private static ObservableCollection<ShoppingItem> _shoppingItems = new ObservableCollection<ShoppingItem>();

        private static bool _isInitialized = false;

        public ObservableCollection<ShoppingItem> ShoppingItems
        {
            get
            {
                if (!_isInitialized)
                    InitializeShoppingList();
                return _shoppingItems;
            }
        }

        public ShoppingListService()
        {
            if (!_isInitialized)
                InitializeShoppingList();
        }

        public void OrderShoppingList()
        {
            var orderedItems = _shoppingItems.OrderByDescending(x => x.ShoppingTime ?? DateTime.MinValue).ToList();
            _shoppingItems.Clear();
            orderedItems.ForEach(x => _shoppingItems.Add(x));
        }

        private void InitializeShoppingList()
        {
            _shoppingItems = new ObservableCollection<ShoppingItem>
            {
                new ShoppingItem { Description = "Milch" },
                new ShoppingItem { Description = "Joghurt", ShoppingTime = DateTime.Now.AddHours(-2) },
                new ShoppingItem { Description = "Brot", ShoppingTime = DateTime.Now.AddDays(-1) }
            };

            _isInitialized = true;
        }
    }
}
