using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFE_Komodo
{
    class CafeUI
    {
        private MenuREPO _listofMenuItems = new MenuREPO();

        public void Run()
        {
            SeedMenu();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Komodo Cafe Menu, please type the corrisponding number for the action you would like to complete.\n" +
                    "1. List Menu Items\n" +
                    "2. Search Menu Item by ItemID\n" +
                    "3. Add Menu Item\n" +
                    "4. Delete Menu Item\n" +
                    "5. Exit Application");
                string menuInput = Console.ReadLine();
                switch (menuInput)
                {
                    case "1":
                        Console.Clear();
                        ListMenuItems();
                        break;
                    case "2":
                        Console.Clear();
                        ListMenuByID();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        CreateNewItem();
                        break;
                    case "4":
                        Console.Clear();
                        DeleteItem();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Confirm you want to end program (Y/N)");
                        string Leave = Console.ReadLine().ToLower();
                        if (Leave == "y")
                        {
                            Console.Clear();
                            Console.WriteLine("Thank you good bye. press any button to exit");
                            Console.ReadKey();
                            keepRunning = false;

                        }
                        else
                        {
                            Console.Clear();
                            Menu();

                        }

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Sorry I didnt get that, lease enter provided number to select action. Example Type \" 1 \" \n");
                        break;

                }
                Console.WriteLine("\n Please Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        //Create menu item
        public void CreateNewItem()
        {

            Console.Clear();
            MenuItems newMenuContent = new MenuItems();
            //itemID
            Console.WriteLine("Input new menu item ID number: ");
            //string newmenuItemID = Console.ReadLine();
           //newMenuContent.MenuItemID = int.Parse(newmenuItemID);

            bool KeepRunning = true;
            while (KeepRunning)
            {
                try
                {
                    string newmenuItemID = Console.ReadLine();
                    newMenuContent.MenuItemID = int.Parse(newmenuItemID);
                    KeepRunning = false;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Sorry please input numbers only!\n");
                    Console.WriteLine("Input new menu item ID number: ");
                }
                
            }
            
            //item name
            Console.WriteLine("Input new Item Name: ");
            newMenuContent.ItemName = Console.ReadLine();
            //item description
            Console.WriteLine("Input new Item Description: ");
            newMenuContent.ItemDescription = Console.ReadLine();
            //item ingredients
            Console.WriteLine("Input new Item Ingredients: ");
            newMenuContent.ItemIngredients = Console.ReadLine();
            //item price
            Console.WriteLine("Input new Price item ID number: ");
            string newItemPrice = Console.ReadLine();
            bool sucess2 = decimal.TryParse(newItemPrice, out decimal newMenuItemPrice);
            if (sucess2)
            {
                newMenuContent.ItemPrice = newMenuItemPrice;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry please input numbers only");
            }
            _listofMenuItems.AddMenuItem(newMenuContent);
        }
        //Delete menu item
        public void DeleteItem()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                ListMenuItems();
                Console.WriteLine("\n Select Item you want to delete by ID\n");
                ListMenuByID();
                Console.WriteLine("\n Confirm Item ID you want to remove,\n or (n) to cancel ");
                string ItemIdString = Console.ReadLine();
                bool isParsable = int.TryParse(ItemIdString, out int result);

                //Call the delet Method
                bool wasDeleted = _listofMenuItems.DeletMenuItem(result);
                // if the contect was deleted ,result
                if (wasDeleted)
                {
                    Console.WriteLine("Item deleted. Press any key to continue.");
                    Console.ReadKey();
                    keepRunning = false;
                }
               
                else
                {
                    Console.WriteLine("Action could not be deleted.");
             
                }
                Console.Clear();
            }
        }
        //list menu
        public void ListMenuItems()
        {
            List<MenuItems> listAllMenuItems = _listofMenuItems.getMenuList();
            foreach (MenuItems menuItem in listAllMenuItems)
            {
                Console.WriteLine(
                    $"Item ID:          {menuItem.MenuItemID} \n" +
                    $"Item Name:        {menuItem.ItemName} \n" +
                    $"Item Description: {menuItem.ItemDescription} \n" +
                    $"Item Ingredients: {menuItem.ItemIngredients} \n" +
                    $"Item Price:       ${menuItem.ItemPrice} \n");
            }
        }
        //list by ID
        public void ListMenuByID()
        {
            //promt user
            Console.WriteLine("Enter Item ID");
            List<MenuItems> listAllMenuItems = _listofMenuItems.getMenuList();
            foreach (MenuItems menuItem in listAllMenuItems)
            {
                Console.WriteLine(
                    $"Item ID:          {menuItem.MenuItemID}");
            }
            //get user input
            try
            {
                string userItemID = Console.ReadLine();
                int result = int.Parse(userItemID);
                MenuItems menuItemID = _listofMenuItems.getMenuByID(result);
                if (menuItemID != null)
                {
                    Console.WriteLine(
                        $"Item ID:          {menuItemID.MenuItemID} \n" +
                        $"Item Name:        {menuItemID.ItemName} \n" +
                        $"Item Description: {menuItemID.ItemDescription} \n" +
                        $"Item Ingredients: {menuItemID.ItemIngredients} \n" +
                        $"Item Price:       ${menuItemID.ItemPrice} \n");
                }
                else
                {
                    Console.WriteLine("Incorrect ID.");
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Sorry please input numbers only");
            }
            
            

        }
        private void SeedMenu()
        {
            MenuItems SeedContent1 = new MenuItems(1, "Pizza", "Pan Baked Cheese Pizza", "Cheese, tomato sause, flour, yeast, water, sugar, and salt ", 20);
            MenuItems SeedContent2 = new MenuItems(2, "Apple Pie", "Home made Apple Pie", "Apple, butter, flour, egg, cinnamon, crust, sugar, brownsugar", 15);

            _listofMenuItems.AddMenuItem(SeedContent1);
            _listofMenuItems.AddMenuItem(SeedContent2);
        }
    }
}
