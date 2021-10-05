using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ManufacturerRepository : IDisposable
    {
        readonly InternetShopContext db = new InternetShopContext();

        public List<Manufacturer> GetAll()
        {
            return db.Manufacturers.ToList();
        }
        public Manufacturer Get(int id)
        {
            return db.Manufacturers.Find(id);
        }
        public void CreateOrUpdate(Manufacturer manufacturer)
        {
            db.Manufacturers.AddOrUpdate(manufacturer);
        }
        public void Delete(Manufacturer manufacturer)
        {
            db.Manufacturers.Remove(manufacturer);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        ~ManufacturerRepository()
        {
            db.Dispose();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
