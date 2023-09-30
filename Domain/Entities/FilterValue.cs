using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FilterValue
    {
        public long FilterKeyId { get; set; }
        public FilterKey FilterKey { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public string Value { get; set; }
    }
}
