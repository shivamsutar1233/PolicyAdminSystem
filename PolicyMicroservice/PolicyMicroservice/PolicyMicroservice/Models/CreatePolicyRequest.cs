using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    public class CreatePolicyRequest
    {
        public int ConsumerId { get; set; }
        public int BusinessId { get; set; }
    }
}
