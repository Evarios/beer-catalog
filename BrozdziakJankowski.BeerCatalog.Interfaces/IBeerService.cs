using BrozdziakJankowski.BeerCatalog.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozdziakJankowski.BeerCatalog.Interfaces
{
    public interface IBeerService
    {
        IEnumerable<Beer> GetAllBeers();
        Beer GetBeerDetails(int beerId);
        void AddNewBeer(Beer beer);
    }
}
