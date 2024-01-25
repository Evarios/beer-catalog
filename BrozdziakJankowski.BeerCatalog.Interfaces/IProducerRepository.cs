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
        Task<IEnumerable<Producer>> GetAllProducers();
        Task<Producer> GetProducerById(int producerId);
        Task AddProducer(Producer producer);
        Task UpdateProducer(Producer producer);
        Task DeleteProducer(int producerId);
    }
}
