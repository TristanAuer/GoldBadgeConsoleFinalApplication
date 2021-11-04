using GreenPlanKomodo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GreenTesting
{
    [TestClass]
    public class GreenREPOTesting
    {
        private GreenREPO _repo;
        private CarInformation _info;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new GreenREPO();
            _info = new CarInformation("Ford", "Edge", 2011, CarSize.Crossover, CarType.Gas, 28, 0, "3.6L V6");

            _repo.AddCarInfoToList(_info);
        }


        [TestMethod]
        //Add Method
        public void AddToList_ShouldGetNotNull()
        {
            // Arrange --> Setting up the playing field
            CarInformation info = new CarInformation();
            info.CarName = "Ford";
            GreenREPO repo = new GreenREPO();

            //Act --> Get/run the code we want to test
            repo.AddCarInfoToList(info);
            CarInformation infoFromDirectory = repo.GetInfoByName("Ford");

            // Assert --> Use th assert class to verify the expected outcome
            Assert.IsNotNull(infoFromDirectory);
        }

        //Update Method
        [TestMethod]
        public void UpdateCarProfile_ShouldReturnTrue()
        {
            // Arrange

            //Test Initialize
            CarInformation newInfo = new CarInformation("Ford", "Edge 2", 2011, CarSize.Crossover, CarType.Gas, 28, 0, "3.6L V6");

            // Act
            bool updateResult = _repo.UpdateExistingCarInfo("Edge", newInfo);
            //Assert
            Assert.IsTrue(updateResult);

        }

        [DataTestMethod]
        [DataRow("Edge", true)]
        [DataRow("Focus", false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(string originalName, bool shouldUpdate)
        {
            CarInformation newInfo = new CarInformation("Ford", "Edge 2", 2011, CarSize.Crossover, CarType.Gas, 28, 0, "3.6L V6");

            // Act
            bool updateResult = _repo.UpdateExistingCarInfo(originalName, newInfo);
            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteInfo_ShouldReturnTrue()
        {
            //Arrange

            //Act
            bool deleteResult = _repo.RemoveCarInfoFromList(_info.CarName);
            Assert.IsTrue(deleteResult);

        }
    }
}
