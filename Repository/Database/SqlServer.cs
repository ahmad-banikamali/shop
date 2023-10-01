using Application.Database;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class SqlServer : DbContext,DatabaseContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<FilterKey> FilterKeys { get; set; }
        public DbSet<FilterValue> FilterValues { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; } 

        public SqlServer(DbContextOptions<SqlServer> options) :base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {

                builder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                builder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                builder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                builder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
             }


            builder.Entity<FilterValue>().HasKey(e => new {e.FilterKeyId,e.ProductId});

            builder.Entity<Category>().HasOne(p=>p.ParentCategory).WithMany(p=>p.ChildCategories).OnDelete(DeleteBehavior.NoAction); 

            builder.Entity<Category>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<FilterKey>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<FilterValue>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<Product>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<ProductImage>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

            /*builder.Entity<Category>().HasData(new List<Category>{ 
                new Category {Id = 1,Name = "لوازم الکترونیکی"},
                new Category {Id = 2,Name = "لوازم آشپزخانه"},
                new Category {Id = 3,Name = "لوازم ورزشی"},
                new Category {Id = 4,Name = "لوازم خودرو"},


                new Category {Id = 5, Name = "گوشی",ParentCategoryId = 1,},
                new Category {Id = 6, Name = "لپ تاپ",ParentCategoryId = 1},
                new Category {Id = 7, Name = "تلوزیون",ParentCategoryId = 1},
                new Category {Id = 8, Name = "لوازم جانبی",ParentCategoryId = 1}, 

                new Category {Id = 9, Name = "یخچال",ParentCategoryId = 2},
                new Category {Id = 10, Name = "گاز",ParentCategoryId = 2},
                new Category {Id = 11, Name = "ماشین لباسشویی",ParentCategoryId = 2},
                new Category {Id = 12, Name = "مایکرویو",ParentCategoryId = 2},


                new Category {Id = 13, Name = "کوهنوردی",ParentCategoryId = 3},
                new Category {Id = 14, Name = "شنا",ParentCategoryId = 3},
                new Category {Id = 15, Name = "فوتبال",ParentCategoryId = 3},
                new Category {Id = 16, Name = "دوچرخه",ParentCategoryId = 3}, 


                new Category {Id = 17, Name = "آینه",ParentCategoryId = 4},
                new Category {Id = 18, Name = "رنگ",ParentCategoryId = 4},
                new Category {Id = 19, Name = "چرخ",ParentCategoryId = 4},
                new Category {Id = 20, Name = "صندلی",ParentCategoryId = 4},   
            });*/

      

            base.OnModelCreating(builder);
        }

       


        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                p.State == EntityState.Added ||
                p.State == EntityState.Deleted
                );
            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

 
                if (item.State == EntityState.Added  )
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Modified  )
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Deleted  )
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemoved").CurrentValue = true;
                    item.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }


    }
}
