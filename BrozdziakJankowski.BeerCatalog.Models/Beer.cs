using BrozdziakJankowski.BeerCatalog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BrozdziakJankowski.BeerCatalog.Models
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public BeerType Type { get; set; }
        public double AlcoholContent { get; set; }
        public int ProducerId { get; set; }

        public Producer Producer { get; set; }
    }
}