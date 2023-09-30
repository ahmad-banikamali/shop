using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FilterKey
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
     }
}
