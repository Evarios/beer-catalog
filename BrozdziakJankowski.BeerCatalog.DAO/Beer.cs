﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrozdziakJankowski.BeerCatalog.DAO
{
    public class Beer
    {
        public int BeerId { get; set; } // Primary Key
        public string Name { get; set; }
        public string Type { get; set; }
        public double AlcoholContent { get; set; }
        public int ProducerId { get; set; } // Foreign Key

        // Navigation property back to Producer
        public Producer Producer { get; set; }
    }
}