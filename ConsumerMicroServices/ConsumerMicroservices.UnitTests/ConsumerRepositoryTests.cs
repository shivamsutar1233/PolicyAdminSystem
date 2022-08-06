using ConsumerMicroServices.Models;
using ConsumerMicroServices.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsumerMicroservices.UnitTests
{
    [TestFixture]
    class ConsumerRepositoryTests
    {
        private readonly string _connectionString = "Data Source=LAPTOP-A6G2G4CS\\DATABASES_DOTNET;Initial Catalog=PolicyDB;Integrated Security=True;Pooling=False";
        ConsumerRepository consumerRepository;
        private readonly DataBaseContext _context = new DataBaseContext();
        public ConsumerRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>().UseSqlServer(_connectionString).Options;
            DataBaseContext databaseContext = new DataBaseContext(options);

            consumerRepository = new ConsumerRepository(databaseContext);
        }



        [Test]
        public void CreateBusinessProperty_TakesBusinessPropertyAsInput_ReturnsBusinessPropertyWithPropertyId()
        {
            BusinessProperty businessProperty = new BusinessProperty()
            {
                ConsumerId = 1,
                BuildingSqft = 200,
                BuildingType = "Testing",
                BuildingStoreys = 5,
                BuildingAge = 5,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                UsefulLifeOfTheAsset = 2
            };
            var result = consumerRepository.CreateBusinessProperty(businessProperty);

            Assert.That(result.PropertyId, Is.TypeOf<int>());
        }

        [Test]
        public void UpdateBusinessProperty_TakesBusinessPropertyAsInput_ReturnsTrue()
        {
            BusinessProperty businessProperty = new BusinessProperty()
            {
                ConsumerId = 1,
                BuildingSqft = 200,
                BuildingType = "Rental",
                BuildingStoreys = 5,
                BuildingAge = 5,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                UsefulLifeOfTheAsset = 2,
                PropertyId = 18
            };

            var result = consumerRepository.UpdateBusinessProperty(businessProperty);

            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateBusinessProperty_TakesBusinessPropertyAsInput_ReturnsKeyNotFoundException()
        {
            BusinessProperty businessProperty = new BusinessProperty()
            {
                ConsumerId = 1,
                BuildingSqft = 200,
                BuildingType = "Rental",
                BuildingStoreys = 5,
                BuildingAge = 5,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                UsefulLifeOfTheAsset = 2,
                PropertyId = 250 //Wrong Property Id Given
            };

            //var result = consumerRepository.UpdateBusinessProperty(businessProperty);
            Assert.Throws<KeyNotFoundException>(() => consumerRepository.UpdateBusinessProperty(businessProperty));
        }

        [Test]
        public void ViewConsumerProperty_TakesNullValuesForConsumerIdAndPropertyIdAsInput_ReturnnsConsumerPropertyDetailsObject()
        {
            int ConsumerId = 1;
            int PropertyId = 18;

            BusinessPropertyDetails businessProperty = new BusinessPropertyDetails()
            {
                ConsumerId = 1,
                BuildingSqft = 200,
                BuildingType = "Rental",
                BuildingStoreys = 5,
                BuildingAge = 5,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                UsefulLifeOfTheAsset = 2,
                PropertyId = 18,
                PropertyValue =3
            };

         

            var result = consumerRepository.ViewConsumerProperty(ConsumerId, PropertyId);
            var expected = JsonConvert.SerializeObject(businessProperty);
            var resultNew = JsonConvert.SerializeObject(result);

            Assert.AreEqual(expected, resultNew);
        }

        [Test]
        public void ViewConsumerProperty_TakesNullValuesForConsumerIdAndPropertyIdAsInput_ReturnsKeyNotFoundException()
        {
            int ConsumerId = 500; //Wrongs Values are given
            int PropertyId = 500; //Wrong Values are given

            BusinessProperty businessProperty = new BusinessProperty()
            {
                ConsumerId = 1,
                BuildingSqft = 200,
                BuildingType = "Rental",
                BuildingStoreys = 5,
                BuildingAge = 5,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                UsefulLifeOfTheAsset = 2,
                PropertyId = 18
            };

            //var expected = JsonConvert.SerializeObject(businessProperty);
            //var resultNew = JsonConvert.SerializeObject(result);

            Assert.Throws<KeyNotFoundException>(() => consumerRepository.ViewConsumerProperty(ConsumerId, PropertyId));
        }


        [Test]
        public void CreateConsumerBusiness_TakesConsumerAndBusinessObjectAsInput_ReturnsTheConsumerBusinessObject()
        {

            ConsumerBusiness consumerBusiness = new ConsumerBusiness()
            {
                ConsumerName = "Tests",
                ConsumerEmail = "Test@gmail.com",
                ConsumerPan = "TESTS4444B",
                BusinessOverview = "TESTS",
                ValidityOfConsumer = 5,
                AgentId = 11,
                AgentName = "TESTS",
                BusinessType = "Replacement",
                AnnualTurnOver = 1000000,
                CapitalInvested = 200000,
                TotalEmployees = 5,

            };

            ConsumerBusiness result = consumerRepository.CreateConsumerBusiness(consumerBusiness);

            Assert.That(result.ConsumerId, Is.TypeOf<int>());
            Assert.That(result.BusinessId, Is.TypeOf<int>());

        }


        [Test]
        public void UpdateConsumerBusiness_TakesConsumerBusinessAsInput_ReturnsTrue()
        {
            ConsumerBusiness consumerBusiness = new ConsumerBusiness()
            {
                ConsumerName = "Ritik",
                ConsumerEmail = "ritik@gmail.com",
                ConsumerPan = "BBBBB4444B",
                BusinessOverview = "Solo",
                ValidityOfConsumer = 5,
                AgentId = 11,
                AgentName = "Shivam",
                BusinessType = "Replacement",
                AnnualTurnOver = 1000000,
                CapitalInvested = 200000,
                TotalEmployees = 5,
                ConsumerId = 1,
                BusinessId = 1
            };

            var result = consumerRepository.UpdateConsumerBusiness(consumerBusiness);
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateConsumerBusiness_TakesConsumerBusinessAsInput_ReturnsFalse()
        {
            ConsumerBusiness consumerBusiness = new ConsumerBusiness()
            {
                ConsumerName = "Ritik",
                ConsumerEmail = "ritik@gmail.com",
                ConsumerPan = "BBBBB4444B",
                BusinessOverview = "Solo",
                ValidityOfConsumer = 5,
                AgentId = 11,
                AgentName = "Shivam",
                BusinessType = "Replacement",
                AnnualTurnOver = 1000000,
                CapitalInvested = 200000,
                TotalEmployees = 5,
                ConsumerId = 250,
                BusinessId = 250
            };

            var result = consumerRepository.UpdateConsumerBusiness(consumerBusiness);
            Assert.IsFalse(result);
        }



        [Test]
        public void ViewConsumerBusiness_TakesConsumerIdAndBusinessId_ReturnsConsumerBusiness()
        {

            var ConsumerId = 1;
            var BusinessId = 1;

            ConsumerBusinessDetails consumerBusiness = new ConsumerBusinessDetails()
            {
                ConsumerName = "Ritik",
                ConsumerEmail = "ritik@gmail.com",
                ConsumerPan = "BBBBB4444B",
                BusinessOverview = "Solo",
                ValidityOfConsumer = 5,
                AgentId = 11,
                AgentName = "Shivam",
                BusinessType = "Replacement",
                AnnualTurnOver = 1000000,
                CapitalInvested = 200000,
                TotalEmployees = 5,
                ConsumerId = 1,
                BusinessId = 1,
                BusinessValue =5
            };

            var result = consumerRepository.ViewConsumerBusiness(ConsumerId, BusinessId);
            var expected = JsonConvert.SerializeObject(consumerBusiness);
            var resultNew = JsonConvert.SerializeObject(result);

            Assert.AreEqual(expected, resultNew);




        }
    }
}

