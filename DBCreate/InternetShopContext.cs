using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
   public class InternetShopContext : DbContext
    {
        public InternetShopContext() : base("name = InternetShop") { }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }

    }
}
