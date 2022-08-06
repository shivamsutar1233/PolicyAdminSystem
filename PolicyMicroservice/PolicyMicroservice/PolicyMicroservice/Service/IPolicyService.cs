using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Service
{   

    public interface IPolicyService
    {
        int CreatePolicy(CreatePolicyRequest createPolicy);
        bool IssuePolicy(IssuePolicyRequest issuePolicy);
        PolicyDetails ViewPolicy(int consumerId, int BusinessId, int policyId);
        string GetQuotes(int PropertyValue, int BusinessValue, string PropertyType);
    }
}
