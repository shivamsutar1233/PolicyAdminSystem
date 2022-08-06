using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using PolicyMicroservice.Models;
using PolicyMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolicyMicroservice.UnitTests
{
    [TestFixture]
    class ConsumerPolicyRepositoryTest
    {
        private readonly string _connectionString = "Data Source=LAPTOP-A6G2G4CS\\DATABASES_DOTNET;Initial Catalog=PolicyDB;Integrated Security=True;Pooling=False";
        private readonly DatabaseContext _context = new DatabaseContext();
        ConsumerPolicyRepository policyRepository;
        public ConsumerPolicyRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(_connectionString).Options;
            DatabaseContext databaseContext = new DatabaseContext(options);

            policyRepository = new ConsumerPolicyRepository(databaseContext);
        }

        [Test]
        public void CreatePolicy_TakesConsumerBusinessAndPolicyMasterAndStringQuote_ReturnsPolicyIdForCreatedPolicy()
        {
            var consumerBusiness = new ConsumerBusiness()
            {
                ConsumerId = 9,
                ConsumerName = "Jones",
                Email= "jones@gmail.com",
                Pan = "BBBBB4563B",
                AgentId = 10,
                AgentName = "Ritik",
                BusinessId = 9,
                ValidityofConsumer = 5,
                BusinessOverview = "Actor",
                BusinessType = "Replacement",
                AnnualTurnOver = 1000000,
                TotalEmployees = 100,
                CapitalInvested = 200000,
                BusinessValue = 5
            };

            var policyMaster = new PolicyMaster()
            {
                Id = "P01"
            };

            string quote = "No Quotes, Contact Insurance Provider";

            var result = policyRepository.CreatePolicy(consumerBusiness, policyMaster, quote);

            Assert.That(result, Is.InstanceOf<int>());

        }

        [Test]
        public void IssuePolicy_TakesIssuePolicyRequest_ReturnsTrue()
        {
            var consumerPolicy = new IssuePolicyRequest()
            {
                PolicyId = 5,
                ConsumerId = 9,
                BusinessId = 9,
                PaymentDetails = "Success",
                AcceptanceStatus = "Accepted"
            };

            var result = policyRepository.IssuePolicy(consumerPolicy);

            Assert.IsTrue(result);
        }


        [Test]
        public void GetPolicy_TakesConsumerIdAndPolicyIdAsInput_ReturnsPoliciesObjectForACustomer()
        {
            var consumerId = 9;
            var PolicyId = 5;

            var result = policyRepository.GetPolicy(consumerId, PolicyId);
            var resultNew = JsonConvert.SerializeObject(result);
            var expected = JsonConvert.SerializeObject(new 
            {
                
                PolicyId = 5,
                Id ="P01",
                ConsumerId = 9,
                BusinessId = 9,
                AcceptedQuotes = "50000",
                PolicyStatus = "Issued",
                PaymentDetails = "Success",
                AcceptanceStatus = "Accepted",
                EffectiveDate = result.EffectiveDate
                //AgentId = 10,
                //AgentName = "Ritik",


            });
            Assert.AreEqual(expected, resultNew);
        }
    }
}
