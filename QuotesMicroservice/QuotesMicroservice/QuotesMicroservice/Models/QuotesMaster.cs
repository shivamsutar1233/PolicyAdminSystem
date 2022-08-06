using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Models
{
    public class QuotesMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MinBusinessValue { get; set; }
        public int MaxBusinessValue { get; set; }

        public int MinPropertyValue { get; set; }
        public int MaxPropertyValue { get; set; }

        public string PropertyType { get; set; }

        public string Quotes { get; set; }

    }
}

