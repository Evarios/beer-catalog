using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrozdziakJankowski.BeerCatalog.Models;

namespace BrozdziakJankowski.BeerCatalog.DAO
{
    public class BeerCatalogContext : DbContext
    {
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Beer> Beers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace "Your_Connection_String_Here" with your actual database connection string
            optionsBuilder.UseSqlite("Data Source=beerCatalog.db");
        }
    }
}
