using BrozdziakJankowski.BeerCatalog.DAO;
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
        Beer GetBeerById(int beerId);
        void AddBeer(Beer beer);
        void UpdateBeer(Beer beer);
        void DeleteBeer(int beerId);
    }
}
