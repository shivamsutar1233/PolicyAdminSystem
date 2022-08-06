using ConsumerMicroServices.Controllers;
using ConsumerMicroServices.Models;
using ConsumerMicroServices.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumerMicroservices.UnitTests
{
    [TestFixture]
    class ConsumerControllerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        public ConsumerController _consumerController;
        Mock<IConsumerService> mock = new Mock<IConsumerService>();

        private readonly BusinessProperty businessProperty = new BusinessProperty()
        {
            ConsumerId = 1,
            BuildingSqft = 200,
            BuildingType = "Rental",
            BuildingStoreys = 5,
            BuildingAge = 5,
            CostOfTheAsset = 9,
            SalvageValue = 3,
            UsefulLifeOfTheAsset = 2
        };

        private readonly Business business = new Business()
        {
            BusinessType = "Replacement",
            AnnualTurnOver = 1000000,
            CapitalInvested = 200000,
            TotalEmployees = 5
        };

        private readonly Consumer consumer = new Consumer()
        {
            ConsumerName = "Ritik",
            ConsumerEmail = "ritik@gmail.com",
            ConsumerPan = "BBBBB4444B",
            BusinessOverview = "Solo",
            ValidityOfConsumer = 5,
            AgentId = 11,
            AgentName = "Shivam"
        };


        private readonly ConsumerBusiness consumerBusiness = new ConsumerBusiness()
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
           
        };

        public ConsumerControllerTests()
        {
            _consumerController = new ConsumerController(mock.Object);
        }



        [Test]
        public void CreateBusinessProperty_TakesBusinessProperty_ReturnsBusinessPropertyObjectWithPropertyId()
        {
            var result = new BusinessProperty()
            {
                ConsumerId = 1,
                PropertyId = 1,
                BuildingSqft = 200,
                BuildingType = "Rental",
                BuildingStoreys = 5,
                BuildingAge = 5,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                UsefulLifeOfTheAsset = 2
            };

            mock.Setup(m => m.CreateBusinessProperty(businessProperty)).Returns(result);
            var response = _consumerController.CreateBusinessProperty(businessProperty) as OkObjectResult;

            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public void UpdateBusinessProperty_TakesBusinessPropertyAsInput_ReturnsTrue()
        {
            businessProperty.PropertyId = 1;
            var result = new BusinessProperty()
            {
                PropertyId = 1,
                BuildingSqft = 200,
                BuildingType = "Rental",
                BuildingStoreys = 5,
                BuildingAge = 5,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                UsefulLifeOfTheAsset = 2
            };

            mock.Setup(m => m.UpdateBusinessProperty(businessProperty)).Returns(true);
            var response = _consumerController.UpdateBusinessProperty(businessProperty) as OkObjectResult;

            Assert.AreEqual(200, response.StatusCode);
        }


        [Test]
        public void ViewConsumerProperty_TakesConsumerIdAndPropertyIdAsInput_ReturnsThePropertyOject()
        {
            var ConsumerId = 1;
            var PropertyId = 1;
            var result = new BusinessPropertyDetails()
            {
                ConsumerId = 1,
                PropertyId = 1,
                BuildingSqft = 200,
                BuildingType = "Rental",
                BuildingStoreys = 5,
                BuildingAge = 5,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                UsefulLifeOfTheAsset = 2,
                PropertyValue = 2
            };


            mock.Setup(m => m.ViewConsumerProperty(ConsumerId, PropertyId)).Returns(result);
            var response = _consumerController.ViewConsumerProperty(ConsumerId, PropertyId) as OkObjectResult;
            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public void CreateConsumerBusiness_TakesConsumerAndBusinessCombinedAsInput_ReturnsTheConsumerBusinessOBjectWithCustomerAndBusinessId()
        {
            var result = new ConsumerBusiness()
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

            mock.Setup(m => m.CreateConsumerBusiness(consumerBusiness)).Returns(result);
            var response = _consumerController.CreateConsumerBusiness(consumerBusiness) as OkObjectResult;
            Assert.AreEqual(200, response.StatusCode);
        }


        [Test]
        public void UpdateConsumerBusiness_TakesConsumerAndBusinessWithConsumerAndBusinessIdAsInputs_ReturnsTrue()
        {
            var result = new ConsumerBusiness()
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

            mock.Setup(m => m.UpdateConsumerBusiness(consumerBusiness)).Returns(true);
            var response = _consumerController.UpdateConsumerBusiness(consumerBusiness) as OkObjectResult;
            Assert.AreEqual(200, response.StatusCode);
        }


        [Test]
        public void ViewConsumerBusiness_TakesConsumerAndBusinessIdAsInput_ReturnsTheConsumerBusinessObject()
        {
            var ConsumerId = 1;
            var BusinessId = 1;

            var result = new ConsumerBusinessDetails()
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

            mock.Setup(m => m.ViewConsumerBusiness(ConsumerId, BusinessId)).Returns(result);
            var response = _consumerController.ViewConsumerBusiness(ConsumerId, BusinessId) as OkObjectResult;
            Assert.AreEqual(200, response.StatusCode);
        }
    }
}
