using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PolicyMicroservice.Controllers;
using PolicyMicroservice.Models;
using PolicyMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolicyMicroservice.UnitTests
{

    [TestFixture]
    class PolicyControllerTests
    {



        public PolicyController policyController;


        Mock<IPolicyService> mock = new Mock<IPolicyService>();

        private CreatePolicyRequest createPolicyRequest = new CreatePolicyRequest()
        {
            ConsumerId = 1,
            BusinessId = 1
        };
        private IssuePolicyRequest issuePolicy = new IssuePolicyRequest()
        {
            ConsumerId = 1,
            BusinessId = 1,
            PolicyId = 1,
            PaymentDetails = "Success",
            AcceptanceStatus = "Accepted"
        };


        public PolicyControllerTests()
        {
            policyController = new PolicyController(mock.Object);
        }



        [Test]
        public void CreatePolicy_TakesCreatePolicyRequest_ReturnsOkObjectResult()
        {
            var PolicyId = 1;

            mock.Setup(m => m.CreatePolicy(createPolicyRequest)).Returns(PolicyId);
            var response = policyController.CreatePolicy(createPolicyRequest) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public void IssuePolicy_TakesIssuePolicyRequestObjectAsInput_ReturnsTrue()
        {
            var value = true;
            mock.Setup(m => m.IssuePolicy(issuePolicy)).Returns(value);
            var response = policyController.IssuePolicy(issuePolicy) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public void ViewPolicy_TakesConsumerAndBusinessAndPolicyIdsAsInput_ReturnPolicyDetails()
        {
            var ConsumerId = 1;
            var PolicyId = 2;
            var BusinessId = 3;
            var policyDetails = new PolicyDetails()
            {
                ConsumerId = 1,
                BusinessId = 1,
                PolicyId = 1,
                PolicyStatus = "Issued",
                AcceptedQuotes = "81000",
                PaymentDetails = "Success",
                AcceptanceStatus = "Accepted",
                AgentId = 10,
                AgentName = "Ritik",
                ConsumerName="Shivam",
                EffectiveDate = new DateTime(2021, 05, 31)
            };


            mock.Setup(m => m.ViewPolicy(ConsumerId, BusinessId, PolicyId)).Returns(policyDetails);
            var response = policyController.ViewPolicy(ConsumerId, BusinessId, PolicyId) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public void GetQuotes_TakesPropertyValueAndBusinessValueAndPropertyTypeAsInputs_ReturnsQuotes()
        {
            var quotes = "50000";
            var PropertyValue = 5;
            var BusinessValue = 4;
            var PropertyType = "Building";

            mock.Setup(m => m.GetQuotes(PropertyValue, BusinessValue, PropertyType)).Returns(quotes);
            var response = policyController.GetQuotes(PropertyValue, BusinessValue, PropertyType) as OkObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
        }
    }
}

