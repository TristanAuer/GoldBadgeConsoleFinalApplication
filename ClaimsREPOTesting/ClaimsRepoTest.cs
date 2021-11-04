using ClaimsKomodo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsREPOTesting
{
    [TestClass]
    public class ClaimsRepoTest
    {

        private ClaimsREPO _repo;
        private ClaimInfo _content;

        public void Arrange()
        {
            _repo = new ClaimsREPO();
            _content = new ClaimInfo();

            _repo.AddClaimInfoToList(_content);
        }

        [TestMethod]
        // Add Method
        public void AddToList_ShouldGetNotNull()
        {
            ClaimInfo content = new ClaimInfo();
            content.ClaimID = 1;
            ClaimsREPO repo = new ClaimsREPO();

            repo.AddClaimInfoToList(content);
            ClaimInfo infoFromDirectory = repo.GetClaimInfo(1);

            Assert.IsNotNull(infoFromDirectory);
        }
        [TestMethod]
        public void UpdateClaim_ShouldReturnTrue()
        {
            ClaimInfo newContent = new ClaimInfo(2, ClaimTypeVar.Car, "Tree through window", 1000, DateTime.Now, DateTime.Today, true);
            bool updateResult = _repo.UpdateClaimContent(2, newContent);
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(3, false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(int originalID, bool shouldUpdate)
        {
            ClaimInfo newContent = new ClaimInfo(2, ClaimTypeVar.Car, "Tree through window", 1000, DateTime.Now, DateTime.Now, true);
            bool updateResult = _repo.UpdateClaimContent(originalID, newContent);
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveClaimInfo(_content.ClaimID);
            Assert.IsTrue(deleteResult);
        }
    }
}
