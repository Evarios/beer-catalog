using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.Models;

namespace BrozdziakJankowski.BeerCatalog.BL
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public IEnumerable<Producer> GetAllProducers()
        {
            return _producerRepository.GetAllProducers();
        }

        public Producer GetProducerById(int id)
        {
            return _producerRepository.GetProducerById(id);
        }

        public void AddProducer(Producer producer)
        {
            _producerRepository.AddProducer(producer);
        }

        public void UpdateProducer(Producer producer)
        {
            _producerRepository.UpdateProducer(producer);
        }

        public void DeleteProducer(int id)
        {
            _producerRepository.DeleteProducer(id);
        }
    }
}
