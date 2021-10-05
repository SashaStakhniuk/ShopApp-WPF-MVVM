using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ReceiptRepository : IDisposable
    {
        readonly InternetShopContext db = new InternetShopContext();

        public List<Receipt> GetAll()
        {
            return db.Receipts.ToList();
        }
        public Receipt Get(int id)
        {
            return db.Receipts.Find(id);
        }
        public void CreateOrUpdate(Receipt receipt)
        {
            db.Receipts.AddOrUpdate(receipt);
        }
        public void Delete(Receipt receipt)
        {
            db.Receipts.Remove(receipt);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        ~ReceiptRepository()
        {
            db.Dispose();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
