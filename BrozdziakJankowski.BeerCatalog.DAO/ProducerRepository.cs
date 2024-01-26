using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrozdziakJankowski.BeerCatalog.Models;
using BrozdziakJankowski.BeerCatalog.Interfaces;

namespace BrozdziakJankowski.BeerCatalog.DAO
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly BeerCatalogContext _context;

        public ProducerRepository(BeerCatalogContext context)
        {
            _context = context;
        }

        public IEnumerable<Producer> GetAllProducers()
        {
            return _context.Producers.ToList();
        }

        public Producer GetProducerById(int id)
        {
            return _context.Producers.Find(id);
        }

        public void AddProducer(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
        }

        public void UpdateProducer(Producer producer)
        {
            _context.Producers.Update(producer);
            _context.SaveChanges();
        }

        public void DeleteProducer(int id)
        {
            var producer = _context.Producers.Find(id);
            if (producer != null)
            {
                _context.Producers.Remove(producer);
                _context.SaveChanges();
            }
        }
    }
}
