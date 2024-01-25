using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.Models;

namespace BrozdziakJankowski.BeerCatalog.BL
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public IEnumerable<Beer> GetAllBeers()
        {
            return _beerRepository.GetAllBeers();
        }

        public Beer GetBeerById(int id)
        {
            return _beerRepository.GetBeerById(id);
        }

        public void AddBeer(Beer beer)
        {   
            _beerRepository.AddBeer(beer);
        }

        public void UpdateBeer(Beer beer)
        {
            _beerRepository.UpdateBeer(beer);
        }

        public void DeleteBeer(int id)
        {
            _beerRepository.DeleteBeer(id);
        }
    }
}
