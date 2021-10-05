using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
   public class GoodRepository : IDisposable
    {
        readonly InternetShopContext db = new InternetShopContext();

        public List<Good> GetAll()
        {
            return db.Goods.ToList();
        }
        public Good Get(int id)
        {
            return db.Goods.Find(id);
        }
        public void CreateOrUpdate(Good good)
        {
            db.Goods.AddOrUpdate(good);
        }
        public void Delete(Good good)
        {
            db.Goods.Remove(good);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        ~GoodRepository()
        {
            db.Dispose();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
