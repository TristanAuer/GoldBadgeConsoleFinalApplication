using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFE_Komodo
{


        //list of menu descriptions push and pull
        public class MenuItems
        {
            public int MenuItemID { get; set; }
            public string ItemName { get; set; }
            public string ItemDescription { get; set; }
            public string ItemIngredients { get; set; }
            public decimal ItemPrice { get; set; }

            public MenuItems() { }

            public  MenuItems(int menuItemsID, string itemName, string itemDescription, string itemIngredients, decimal itemPrice)
            {
                MenuItemID = menuItemsID;
                ItemName = itemName;
                ItemDescription = itemDescription;
                ItemIngredients = itemIngredients;
                ItemPrice = itemPrice;
            }

        }

}
