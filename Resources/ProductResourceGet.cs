using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Api.Resources
{
    public class ProductResourceGet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int QuantityInPackage { get; set; }

        public string UnitOfMeasurement { get; set; }

        public CategoryResourceGet Category { get; set; }
    }
}
