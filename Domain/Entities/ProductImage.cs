using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductImage
    {
        public long Id { get; set; } 
        public  string  Url  { get; set; } 
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
