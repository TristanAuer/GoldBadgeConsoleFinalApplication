using GreenPlanKomodo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace GreenTesting
{
    [TestClass]
    public class GreenTests
    {
        [TestMethod]
        public void SetCarMake_ShouldSetCorrectCarMake()
        {
            CarInformation info = new CarInformation();

            info.CarMake = "Ford";

            string expected = "Ford";
            string actual = info.CarMake;

            Assert.AreEqual(expected, actual);
        }
    }
}
