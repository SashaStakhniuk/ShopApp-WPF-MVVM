using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
   public class PhotoRepository : IDisposable
    {
        readonly InternetShopContext db = new InternetShopContext();

        public List<Photo> GetAll()
        {
            return db.Photos.ToList();
        }
        public Photo Get(int id)
        {
            return db.Photos.Find(id);
        }
        public void CreateOrUpdate(Photo photo)
        {
            db.Photos.AddOrUpdate(photo);
        }
        public void Delete(Photo photo)
        {
            db.Photos.Remove(photo);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        ~PhotoRepository()
        {
            db.Dispose();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
