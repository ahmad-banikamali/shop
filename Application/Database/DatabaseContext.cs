using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database
{
    public interface DatabaseContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<FilterKey> FilterKeys { get; set; }
        DbSet<FilterValue> FilterValues { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }

        int SaveChanges();
    }
}
