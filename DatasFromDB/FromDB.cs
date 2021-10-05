using CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatasFromDB
{
    public class FromDB
    {
        public List<Person> GetPeoplesFromDB()
        {
            List<Person> peoples = new List<Person>();

            //Task.Run(() =>
            //{            
            using (InternetShopContext context = new InternetShopContext())
            {
                var Peoples = context.Persons;
                foreach (var people in Peoples)
                {
                    peoples.Add(people);
                }
            }
            //});
            return peoples;
        }
        public List<Good> GetGoodsFromDB()
        {
            List<Good> goods = new List<Good>();

            Task.Run(() =>
            {
                using (InternetShopContext context = new InternetShopContext())
                {
                    foreach (var good in context.Goods)
                    {
                        goods.Add(good);
                    }
                }
            });
            return goods;
        }
        public List<Manufacturer> GetManufacturersFromDB()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();

            //Task.Run(() =>
            //{
            using (InternetShopContext context = new InternetShopContext())
            {
                foreach (var manufacturer in context.Manufacturers)
                {
                    manufacturers.Add(manufacturer);
                }
            }
            // });
            return manufacturers;
        }
        public List<Category> GetCategoriesFromDB()
        {
            List<Category> categories = new List<Category>();

            //Task.Run(() =>
            //{
            using (InternetShopContext context = new InternetShopContext())
            {
                foreach (var category in context.Categories)
                {
                    categories.Add(category);
                }
            }
            // });
            return categories;
        }
        public List<Photo> GetPhotosFromDB()
        {
            List<Photo> photos = new List<Photo>();

            //Task.Run(() =>
            //{
            using (InternetShopContext context = new InternetShopContext())
            {
                foreach (var photo in context.Photos)
                {
                    photos.Add(photo);
                }
            }
            // });
            return photos;
        }
    }
}
