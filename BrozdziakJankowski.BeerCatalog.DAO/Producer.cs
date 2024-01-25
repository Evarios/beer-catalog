using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozdziakJankowski.BeerCatalog.DAO
{
    public class Producer
    {
        public int ProducerId { get; set; } // Primary Key
        public string Name { get; set; }
        public string Country { get; set; }

        // Navigation property for related Beers
        public ICollection<Beer> Beers { get; set; }
    }
}
