using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyMaster>().HasData(
                    new PolicyMaster()
                    {
                        Id = "P01",
                        PropertyType = "Building",
                        ConsumerType = "Owner",
                        AssuredSum = 20000000,
                        Tenure = 3,
                        BusinessValue = 5,
                        PropertyValue = 4,
                        BaseLocation = "Pune",
                        Type = "Replacement",
                    },
                    new PolicyMaster()
                    {
                        Id = "P02",
                        PropertyType = "Factory Equipment",
                        ConsumerType = "Owner",
                        AssuredSum = 40000000,
                        Tenure = 1,
                        BusinessValue = 9,
                        PropertyValue = 8,
                        BaseLocation = "Chennai",
                        Type = "Replacement"
                    },
                    new PolicyMaster()
                    {
                        Id = "P03",
                        PropertyType = "Property in Transit",
                        ConsumerType = "Owner",
                        AssuredSum = 20000000,
                        Tenure = 5,
                        BusinessValue = 7,
                        PropertyValue = 6,
                        BaseLocation = "Mumbai",
                        Type = "Pay Back"
                    }
                );
        }
        public DbSet<PolicyMaster> BuiltInPolicies { get; set; }
        public DbSet<ConsumerPolicy> Policies { get; set; }
    }
}
