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

        public void Arrange()
        {
            _repo = new MenuREPO();
            _menu = new MenuItems();

            _repo.AddMenuItem(_menu);
        }
        [TestMethod]

        public void TestMethod1()
        {
        }
    }
}
