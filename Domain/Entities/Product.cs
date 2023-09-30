using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public int Price { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

        public int ProductCount { get; set; }

    }

    
}
