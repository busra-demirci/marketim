using System;
using Marketim.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Marketim.UnitTest
{
    [TestClass]
    public class DefinitionUT
    {
        private DefinitionOperations definitionOperations;

        [TestInitialize]
        public void Setup()
        {
            definitionOperations = new DefinitionOperations();
        }

        [TestMethod]
        public void GetCities()
        {
            var result = definitionOperations.GetCities();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTowns()
        {
            int cityId = 34;

            var result = definitionOperations.GetTowns(cityId);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetUnits()
        {
            var result = definitionOperations.GetUnits();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetRecordStatuses()
        {
            var result = definitionOperations.GetRecordStatuses();

            Assert.IsNotNull(result);
        }
    }
}
