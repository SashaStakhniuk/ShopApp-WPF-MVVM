using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PersonRepository : IDisposable
    {
        readonly InternetShopContext db = new InternetShopContext();

        public List<Person> GetAll()
        {
            return db.Persons.ToList();
        }
        public Person Get(int id)
        {
            return db.Persons.Find(id);
        }
        public void CreateOrUpdate(Person person)
        {
            db.Persons.AddOrUpdate(person);
        }
        public void Delete(Person person)
        {
            db.Persons.Remove(person);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        ~PersonRepository()
        {
            db.Dispose();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
