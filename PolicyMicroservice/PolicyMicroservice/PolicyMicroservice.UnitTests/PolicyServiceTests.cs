using Moq;
using NUnit.Framework;
using PolicyMicroservice.Models;
using PolicyMicroservice.Repository;
using PolicyMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolicyMicroservice.UnitTests
{
    [TestFixture]
    class PolicyServiceTests
    {

        Mock<IConsumerPolicyRepository> mock = new Mock<IConsumerPolicyRepository>();
        public PolicyService service;

        public PolicyServiceTests()
        {
            service = new PolicyService(mock.Object);
        }

        [Test]
        public void IssuePolicy_TakesIssuePolicyRequest_ReturnsFalse()
        {//Since Policy Has not been Created Till now
            IssuePolicyRequest policyRequest = new IssuePolicyRequest()
            {
                ConsumerId = 9,
                BusinessId = 9,
                PolicyId = 6,
                AcceptanceStatus = "Accepted",
                PaymentDetails = "Success"
            };

            var result = service.IssuePolicy(policyRequest);

            Assert.IsFalse(result);
        }

        

        

        

    }
}
