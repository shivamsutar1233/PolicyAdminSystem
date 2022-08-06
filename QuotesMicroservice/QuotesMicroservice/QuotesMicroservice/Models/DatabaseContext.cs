using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<QuotesMaster> Quotes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuotesMaster>().HasData(
                    new QuotesMaster { Id=1,MinPropertyValue = 0, MaxPropertyValue = 3, MinBusinessValue = 0, MaxBusinessValue = 3, PropertyType = "Factory Equipment", Quotes = "80000" },
                    new QuotesMaster { Id = 2, MinPropertyValue = 4, MaxPropertyValue = 7, MinBusinessValue = 4, MaxBusinessValue = 7, PropertyType = "Factory Equipment", Quotes = "50000" },
                    new QuotesMaster { Id = 3, MinPropertyValue = 8, MaxPropertyValue = 10, MinBusinessValue = 8, MaxBusinessValue = 10, PropertyType = "Factory Equipment", Quotes = "30000" },

                    new QuotesMaster { Id = 4, MinPropertyValue = 0, MaxPropertyValue = 3, MinBusinessValue = 0, MaxBusinessValue = 3, PropertyType = "Building", Quotes = "80000" },
                    new QuotesMaster { Id = 5, MinPropertyValue = 4, MaxPropertyValue = 7, MinBusinessValue = 4, MaxBusinessValue = 7, PropertyType = "Building", Quotes = "50000" },
                    new QuotesMaster { Id = 6, MinPropertyValue = 8, MaxPropertyValue = 10, MinBusinessValue = 8, MaxBusinessValue = 10, PropertyType = "Building", Quotes = "30000" },

                    new QuotesMaster { Id = 7, MinPropertyValue = 0, MaxPropertyValue = 3, MinBusinessValue = 0, MaxBusinessValue = 3, PropertyType = "Property In Transit", Quotes = "80000" },
                    new QuotesMaster { Id = 8, MinPropertyValue = 4, MaxPropertyValue = 7, MinBusinessValue = 4, MaxBusinessValue = 7, PropertyType = "Property In Transit", Quotes = "50000" },
                    new QuotesMaster { Id = 9, MinPropertyValue = 8, MaxPropertyValue = 10, MinBusinessValue = 8, MaxBusinessValue = 10, PropertyType = "Property In Transit", Quotes = "30000" }                );
        }
    }
}
