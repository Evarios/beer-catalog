using BrozdziakJankowski.BeerCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozdziakJankowski.BeerCatalog.Interfaces
{
    public interface IProducerService
    {
        public interface IProducerService
        {
            IEnumerable<Producer> GetAllProducers();
            Producer GetProducerDetails(int producerId);
            void AddNewProducer(Producer producer);
            // Other business operations as needed
        }
    }
}
