using ConsumerMicroServices.Models;
using ConsumerMicroServices.Repository;
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
    class ConsumerServiceTests
    {

        public ConsumerService _service;
        Mock<IConsumerRepository> mock = new Mock<IConsumerRepository>();

        public ConsumerServiceTests()
        {
            _service = new ConsumerService(mock.Object);
        }

        private readonly BusinessProperty businessProperty = new BusinessProperty()
        {
            ConsumerId = 1,
            BuildingSqft = 200,
            BuildingType = "Rental",
            BuildingStoreys = 5,
            BuildingAge = 5,
            CostOfTheAsset = 9,
            SalvageValue = 3,
            PropertyId = 1,
            UsefulLifeOfTheAsset = 2
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
            ConsumerId = 1,
            BusinessId = 1
        };

        [Test]
        public void CreateBusinessProperty_TakesBusinessPropertyAsInput_ReturnsBusinessProperty()
        {
            mock.Setup(m => m.CreateBusinessProperty(businessProperty)).Returns(businessProperty);
            var response = _service.CreateBusinessProperty(businessProperty);

            Assert.IsNotNull(response);
            Assert.AreEqual(businessProperty, response);
        }

        [Test]
        public void UpdateBusinessProperty_TakesBusinessPropertyAsInput_ReturnsTrue()
        {
            mock.Setup(m => m.UpdateBusinessProperty(businessProperty)).Returns(true);
            var response = _service.UpdateBusinessProperty(businessProperty);

            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);
        }

        [Test]
        public void ViewConsumerProperty_TakesConsumerIdAndPropertyIdAsInputs_ReturnsBusinessPropertyDetails()
        {
            var ConsumerId = 1;
            var PropertyId = 1;
            BusinessPropertyDetails businessPropertyDetails = new BusinessPropertyDetails()
            {
                ConsumerId = 1,
                PropertyValue = 2,
                BuildingSqft = 200,
                BuildingType = "Rental",
                BuildingStoreys = 5,
                BuildingAge = 5,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                PropertyId = 1,
                UsefulLifeOfTheAsset = 2
            };


            mock.Setup(m => m.ViewConsumerProperty(ConsumerId,PropertyId)).Returns(businessPropertyDetails);
            var response = _service.ViewConsumerProperty(ConsumerId, PropertyId);

            Assert.IsNotNull(response);
            Assert.AreEqual(businessPropertyDetails, response);

        }

        [Test]
        public void CreateConsumerBusiness_TakesConsumerBusinessAsInput_ReturnsConsumerBusiness()
        {
            mock.Setup(m => m.CreateConsumerBusiness(consumerBusiness)).Returns(consumerBusiness);
            var response = _service.CreateConsumerBusiness(consumerBusiness);

            Assert.IsNotNull(response);
            Assert.AreEqual(consumerBusiness, response);
        }

        [Test]
        public void UpdateConsumerBusiness_TakesConsumerBusinessAsInput_ReturnsTrue()
        {
            mock.Setup(m => m.UpdateConsumerBusiness(consumerBusiness)).Returns(true);
            var response = _service.UpdateConsumerBusiness(consumerBusiness);

            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);
        }
    
        [Test]
        public void ViewConsumerBusiness_TakesConsumerIdAndBusinessIdAsInput_Returns()
        {
            var ConsumerId = 1;
            var BusinessId = 1;
            ConsumerBusinessDetails consumerBusinessDetails = new ConsumerBusinessDetails()
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

            mock.Setup(m => m.ViewConsumerBusiness(ConsumerId, BusinessId)).Returns(consumerBusinessDetails);
            var response = _service.ViewConsumerBusiness(ConsumerId, BusinessId);

            Assert.IsNotNull(response);
            Assert.AreEqual(consumerBusinessDetails, response);
        }
    }
}
