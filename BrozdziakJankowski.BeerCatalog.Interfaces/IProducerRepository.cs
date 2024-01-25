using BrozdziakJankowski.BeerCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozdziakJankowski.BeerCatalog.Interfaces
{
    public interface IProducerRepository
    {
        IEnumerable<Producer> GetAllProducers();
        Producer GetProducerById(int id);
        void AddProducer(Producer producer);
        void UpdateProducer(Producer producer);
        void DeleteProducer(int id);
    }
}
