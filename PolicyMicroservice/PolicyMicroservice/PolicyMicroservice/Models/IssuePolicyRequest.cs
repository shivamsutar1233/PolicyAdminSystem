using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    public class IssuePolicyRequest
    {
        public int PolicyId { get; set; }
        public int ConsumerId { get; set; }
        public int BusinessId { get; set; }
        public string PaymentDetails { get; set; }
        public string AcceptanceStatus { get; set; }

    }
}
