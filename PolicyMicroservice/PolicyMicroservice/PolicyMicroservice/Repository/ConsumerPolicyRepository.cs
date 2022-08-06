using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using PolicyMicroservice;

namespace PolicyMicroservice.Repository
{
    public class ConsumerPolicyRepository : IConsumerPolicyRepository
    {
        private readonly DatabaseContext context;
        public ConsumerPolicyRepository(DatabaseContext _context)
        {
            context = _context;
        }
        
        public int CreatePolicy(ConsumerBusiness consumerBusiness,PolicyMaster policyMaster,string Quote)
        {     
            var consumerPolicy = new ConsumerPolicy()
            {
                Id = policyMaster.Id,
                ConsumerId = consumerBusiness.ConsumerId,
                BusinessId = consumerBusiness.BusinessId,
                AcceptedQuotes = Quote,
                PolicyStatus = "Initiated",
                PaymentDetails = "Not Paid Yet",
                AcceptanceStatus = "Initiated",
                EffectiveDate = DateTime.Now,
            };
            context.Policies.Add(consumerPolicy);
            context.SaveChanges();
            var result = context.Policies.Max(p=>p.PolicyId);
            return result;
        }

        public bool IssuePolicy(IssuePolicyRequest issuePolicy)
        {
            var consumerPolicy = context.Policies.FirstOrDefault(p => p.ConsumerId.Equals(issuePolicy.ConsumerId)
                                                                                    && p.BusinessId.Equals(issuePolicy.BusinessId)
                                                                                    && p.PolicyId.Equals(issuePolicy.PolicyId));
            consumerPolicy.PaymentDetails = issuePolicy.PaymentDetails;
            consumerPolicy.PolicyStatus = "Issued";
            string accquote = consumerPolicy.AcceptedQuotes;
            consumerPolicy.AcceptanceStatus = issuePolicy.AcceptanceStatus;
            consumerPolicy.EffectiveDate = DateTime.Now;
            context.Policies.Update(consumerPolicy);
            context.SaveChanges();
            //PolicyData.PolicyList.Remove(consumerPolicy);
            /*DateTime date = DateTime.Now;
            ConsumerPolicy addPolicy = new ConsumerPolicy()
            {
                ConsumerId = issuePolicy.ConsumerId,
                BusinessId = issuePolicy.BusinessId,
                PolicyId = issuePolicy.PolicyId,
                AcceptedQuotes = accquote,
                PolicyStatus = "Issued",
                PaymentDetails = issuePolicy.PaymentDetails,
                AcceptanceStatus = issuePolicy.AcceptanceStatus,
                EffectiveDate = date
            };
*/
            //PolicyData.PolicyList.Add(addPolicy);
            return true;
        }

        public ConsumerPolicy GetPolicy(int ConsumerId, int PolicyId)
        {
            var consumer = context.Policies.FirstOrDefault(p => p.ConsumerId.Equals(ConsumerId) && p.PolicyId.Equals(PolicyId));
            return consumer;
        }
    }
    
}
