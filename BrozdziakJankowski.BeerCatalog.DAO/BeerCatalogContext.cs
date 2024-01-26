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
            //optionsBuilder.UseSqlite("Data Source=beerCatalog.db");
            optionsBuilder.UseSqlite("Data Source=\"D:\\OneDrive\\Dokumenty\\Studia\\sem7v2\\PW\\projekt\\beer-catalog\\BrozdziakJankowski.BeerCatalog.DAO\\beerCatalog.db\"");
        }
    }
}
