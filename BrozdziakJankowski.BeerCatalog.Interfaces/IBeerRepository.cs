using BrozdziakJankowski.BeerCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozdziakJankowski.BeerCatalog.Interfaces
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> GetAllBeers();
        Beer GetBeerById(int id);
        void AddBeer(Beer beer);
        void UpdateBeer(Beer beer);
        void DeleteBeer(int id);
    }
}
