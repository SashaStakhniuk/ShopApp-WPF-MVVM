using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : IDisposable
    {
        readonly InternetShopContext db = new InternetShopContext();

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }
        public void CreateOrUpdate(Category category)
        {
            db.Categories.AddOrUpdate(category);
        }
        public void Delete(Category category)
        {
            db.Categories.Remove(category);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        ~CategoryRepository()
        {
            db.Dispose();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}


