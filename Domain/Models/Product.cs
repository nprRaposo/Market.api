using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Api.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
