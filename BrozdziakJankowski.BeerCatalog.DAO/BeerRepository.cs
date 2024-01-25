using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozdziakJankowski.BeerCatalog.DAO
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BeerCatalogContext _context; // Your DbContext

        public BeerRepository(BeerCatalogContext context)
        {
            _context = context;
        }

        public IEnumerable<Beer> GetAllBeers()
        {
            return _context.Beers.ToList();
        }

        public Beer GetBeerById(int id)
        {
            return _context.Beers.Find(id);
        }

        public void AddBeer(Beer beer)
        {
            _context.Beers.Add(beer);
            _context.SaveChanges();
        }


        public void UpdateBeer(Beer beer)
        {
            _context.Beers.Update(beer);
            _context.SaveChanges();
        }

        public void DeleteBeer(int id)
        {
            var beer = _context.Beers.Find(id);
            if (beer != null)
            {
                _context.Beers.Remove(beer);
                _context.SaveChanges();
            }
        }
    }
}
