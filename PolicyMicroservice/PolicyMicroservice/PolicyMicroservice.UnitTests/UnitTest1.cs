//using PolicyMicroservice.Models;
//using PolicyMicroservice.Repository;
//using NUnit.Framework;
//using Moq;

//namespace PolicyMicroserviceTest
//{
//    [TestFixture]
//    public class Tests
//    {

//        Mock<DatabaseContext> mock = new Mock<DatabaseContext>();

//        [Test]
//        public void GetPolicyMethod()
//        {
//            ConsumerPolicyRepository consumerPolicyRepository = new ConsumerPolicyRepository(mock.Object);
//            PolicyDetails policyDetails = new PolicyDetails()
//            {
//                ConsumerId = 1,
//                PolicyId = 1,
//                BusinessId = 1,
//                ConsumerName = "Apoorva",
//                AgentId = 2,
//                AgentName = "Ujjwal",
//                AcceptedQuotes = "81000",
//                PolicyStatus = "Initiated",
//                PaymentDetails = "Success",
//                AcceptanceStatus = "Accept",
//            };
//            Assert.AreEqual(policyDetails.PaymentDetails, consumerPolicyRepository.GetPolicy(1, 1).PaymentDetails);
//        }

//        //[Test]
//        //public void CreatePolicyMethod()
//        //{
//        //    bool output = true;
//        //    ConsumerPolicyRepository consumerPolicyRepository = new ConsumerPolicyRepository(mock.Object);
//        //    CreatePolicyRequest createPolicyRequest = new CreatePolicyRequest()
//        //    {
//        //        ConsumerId = 1,
//        //        BusinessId = 1,
//        //    };
//        //    Assert.AreEqual(output, consumerPolicyRepository.CreatePolicy(createPolicyRequest));

//        //}

//        [Test]
//        public void IssuePolicyMethod()
//        {
//            bool output = true;
//            ConsumerPolicyRepository consumerPolicyRepository = new ConsumerPolicyRepository(mock.Object);
//            IssuePolicyRequest issuePolicyRequest = new IssuePolicyRequest()
//            {
//                ConsumerId = 1,
//                BusinessId = 1,
//                PolicyId = 1,
//                PaymentDetails = "Success",
//                AcceptanceStatus = "Accepted",

//            };
//            Assert.AreEqual(output, consumerPolicyRepository.IssuePolicy(issuePolicyRequest));

//        }


//    }
//}