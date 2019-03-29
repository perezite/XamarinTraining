using System;
using System.Collections.Generic;
using System.Text;

namespace Navigation1.Models
{
    public enum MenuItemType
    {
        Browse,
        Red,
        Green,
        Blue
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
