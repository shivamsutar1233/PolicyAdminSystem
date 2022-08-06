using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Repository
{
   public interface IConsumerPolicyRepository
    {
        int CreatePolicy(ConsumerBusiness consumerBusiness,PolicyMaster policyMaster,string Quote);

        bool IssuePolicy(IssuePolicyRequest issuePolicy);

        ConsumerPolicy GetPolicy(int ConsumerId, int PolicyId);
    }
}
