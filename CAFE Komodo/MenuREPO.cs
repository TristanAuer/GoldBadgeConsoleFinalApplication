using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFE_Komodo
{
    public class MenuREPO
    {
        private List<MenuItems> _listOfMenuItems = new List<MenuItems>();

        //create new menu item
        public void AddMenuItem(MenuItems content)
        {
            _listOfMenuItems.Add(content);
        }

        //delete menu item
        public bool DeletMenuItem(int menuItemID)
        {
            MenuItems content = getMenuByID(menuItemID);
            if (content == null)
            {
                return false;
            }
            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(content);
            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //list Menu items
        public List<MenuItems> getMenuList()
        {
            return _listOfMenuItems;
        }
        //helper get item by ID

        public MenuItems getMenuByID(int menuItemID)
        {
            foreach(MenuItems content in _listOfMenuItems)
            {
                if(content.MenuItemID == menuItemID)
                {
                    return content;
                }
            }
            return null;
        }
        

    }
}
