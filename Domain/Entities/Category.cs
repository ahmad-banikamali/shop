using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Category? ParentCategory { get; set; }
        public long ParentCategoryId { get; set; }

        public ICollection<Category> ChildCategories { get; set;} = new List<Category>();

        public ICollection<FilterKey> FilterKeys { get; set;} = new List<FilterKey>();
    }
}
