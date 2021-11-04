using CAFE_Komodo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CafeTesting
{
    [TestClass]
    public class CafeREPO
    {
        private MenuREPO _repo;
        private MenuItems _menu;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuREPO();
            _menu = new MenuItems(1,"tacos","beef tacos", "lettus, beef, tomato, union, cheese",8);

            _repo.AddMenuItem(_menu);
        }
        [TestMethod]
        //delete
        public void DeletMenuItemIsTrue()
        {
            bool deleteContent = _repo.DeletMenuItem(_menu.MenuItemID);
            Assert.IsTrue(deleteContent);
        }
        

        [TestMethod]
        //add Method
        public void AddMenuItem()
        {
            //arrange - setting up the data required for test\
            MenuItems content = new MenuItems();
            content.MenuItemID = 1;
            MenuREPO repo = new MenuREPO();
            //Act - call our method that we test get a result
            _repo.AddMenuItem(content);
            MenuItems contentFromRepo = repo.getMenuByID(1);

            //assert compare returned method to exspected result should have been.
            Assert.IsNull(contentFromRepo); 
        }
        //read
        [TestMethod]
        public void getMenuByID()
        {

        }
       //public void getMenusit
    }
}
