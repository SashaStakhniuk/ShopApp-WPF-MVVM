using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Creating database, it can take a few minutes, please wait...");
            //using (InternetShopContext db = new InternetShopContext())
            //{
            //    db.Persons.Add(new Person
            //    {
            //        FirstName = "Sasha",
            //        LastName = "Stakhniuk",
            //        Login = "New_Login",
            //        Password = "QwErTy123",
            //        Email = "sstahniuk@gmail.com",
            //        Role = "CreatorDataBase"
            //    });
            //    db.Persons.Add(new Person
            //    {
            //        FirstName = "1",
            //        LastName = "1",
            //        Login = "1",
            //        Password = "1",
            //        Email = "1@gmail.com",
            //        Role = "Administrator"
            //    });
            //    db.Manufacturers.Add(new Manufacturer
            //    {
            //        ManufacturerId = 1,
            //        ManufacturerName = "Xiaomi"
            //    });
            //    db.Manufacturers.Add(new Manufacturer
            //    {
            //        ManufacturerId = 2,
            //        ManufacturerName = "Lenovo"
            //    });
            //    db.Manufacturers.Add(new Manufacturer
            //    {
            //        ManufacturerId = 3,
            //        ManufacturerName = "Apple"
            //    });
            //    db.Manufacturers.Add(new Manufacturer
            //    {
            //        ManufacturerId = 4,
            //        ManufacturerName = "HP"
            //    });
            //    db.Manufacturers.Add(new Manufacturer
            //    {
            //        ManufacturerId = 5,
            //        ManufacturerName = "Nikon"
            //    });
            //    db.Manufacturers.Add(new Manufacturer
            //    {
            //        ManufacturerId = 6,
            //        ManufacturerName = "Huawei"
            //    });
            //    db.Manufacturers.Add(new Manufacturer
            //    {
            //        ManufacturerId = 7,
            //        ManufacturerName = "Harlay Davidson"
            //    });

            //    db.Categories.Add(new Category
            //    {
            //        CategoryId = 1,
            //        CategoryName = "Smartphone"
            //    });

            //    db.Categories.Add(new Category
            //    {
            //        CategoryId = 2,
            //        CategoryName = "Laptop"
            //    });
            //    db.Categories.Add(new Category
            //    {
            //        CategoryId = 3,
            //        CategoryName = "Camera"
            //    });
            //    db.Categories.Add(new Category
            //    {
            //        CategoryId = 4,
            //        CategoryName = "Alcohol"
            //    });
            //    db.Categories.Add(new Category
            //    {
            //        CategoryId = 5,
            //        CategoryName = "Bikes"
            //    });
            //    db.Photos.Add(new Photo
            //    {
            //        PhotoId = 1,
            //        PhotoAddress = "https://i.citrus.ua/imgcache/size_500/uploads/shop/e/d/ed0a123bb56da3bf73ee67356ef3c8de.jpg https://3dnews.ru/assets/external/illustrations/2020/03/12/1005762/redmi1.jpg https://i2.wp.com/mobilityarena.com/wp-content/uploads/2020/08/Redmi-Note-9-Pro-64MP-quad-camera.jpg?fit=600%2C350&ssl=1 https://my-live-01.slatic.net/p/9e9bf765be38afbe488447e2865bc857.jpg"
            //    });
            //    db.Photos.Add(new Photo
            //    {
            //        PhotoId = 2,
            //        PhotoAddress = "https://i2.rozetka.ua/goods/20875005/copy_lenovo_82b30090ra_5fbe46935e64e_images_20875005921.jpg"
            //    });
            //    db.Photos.Add(new Photo
            //    {
            //        PhotoId = 3,
            //        PhotoAddress = "https://www.motorradreporter.com/sites/default/files/Daniele%20Alessandro/2020HDA12_1._Sieger_King_of_Kings_Contest_Quertaro.jpg https://cdn.riastatic.com/photosnew/auto/photo/Harley-Davidson_883-Iron__250883718f.jpg http://under35.me/wp-content/uploads/2018/05/%D0%AD%D0%BB%D0%B5%D0%BA%D1%82%D1%80%D0%BE-Harley-Davidson-2.jpg https://bilder.t-online.de/b/70/23/92/14/id_70239214/tid_da/das-design-erinnert-an-die-rennmaschinen-von-buell-die-ebenfalls-auf-harley-technik-setzen-.jpg"
            //    });
            //    db.Photos.Add(new Photo
            //    {
            //        PhotoId = 4,
            //        PhotoAddress = "https://www.notebookcheck-ru.com/typo3temp/_processed_/a/8/csm_4_zu_3_Teaser_Huawei_Mate_40_Pro_e92d433210.jpg https://tradingshenzhen.com/7983/huawei-mate-40-pro-plus-12gb256gb-kirin-9000-50-mp-cine-camera.jpg https://3dnews.ru/assets/external/illustrations/2020/09/13/1020493/mate1.jpg"
            //    });
            //    db.Photos.Add(new Photo
            //    {
            //        PhotoId = 5,
            //        PhotoAddress = "https://i.citrus.ua/uploads/shop/f/1/f182e768e00f32e0dea9b4d4fef70cea.jpg https://www.istore.ua/upload/iblock/d18/iphone_12_pro_max_graphite_hero_is.jpg https://stylus.ua/thumbs/568x568/bc/0b/1643697.png https://china-phone.info/wp-content/uploads/2020/11/1605907344_633_obzor-apple-iphone-12-pro-max.jpg"
            //    });
            //    db.Photos.Add(new Photo
            //    {
            //        PhotoId = 6,
            //        PhotoAddress = "https://i.citrus.ua/imgcache/size_800/uploads/shop/c/b/cb668d7ea1e06b04643fc000462280d2.jpg https://i.citrus.ua/imgcache/size_800/uploads/shop/b/a/baf21f40f646c8fae6bc8e5bc80c443f.jpg https://i.citrus.ua/imgcache/size_800/uploads/shop/2/f/2ff0a40b5b928a09068a4274d891d509.jpg https://i.citrus.ua/imgcache/size_800/uploads/shop/5/5/553434429f61d837c45bea2dee16d89f.jpg https://i.citrus.ua/uploads/shop/f/1/f1c313e9086d42189f47eda83c04edea.jpg"
            //    });
            //    db.Photos.Add(new Photo
            //    {
            //        PhotoId = 7,
            //        PhotoAddress = "https://upload.wikimedia.org/wikipedia/commons/2/23/Nikon_D3100.jpg"
            //    });
            //    db.Goods.Add(new Good
            //    {
            //        GoodId = 1,
            //        GoodName = "Xiaomi Redmi Note 9 Pro",
            //        ManufacturerId = 1,
            //        CategoryId = 1,
            //        PhotoId = 1,
            //        Price = 7800,
            //        GoodCount = 1200

            //    });
            //    db.Goods.Add(new Good
            //    {
            //        GoodId = 2,
            //        GoodName = "Lenovo Legion 5 17IMH05 (82B30095RA) Phantom Black",
            //        ManufacturerId = 2,
            //        CategoryId = 2,
            //        PhotoId = 2,
            //        Price = 34000,
            //        GoodCount = 800
            //    });
            //    db.Goods.Add(new Good
            //    {
            //        GoodId = 3,
            //        GoodName = "Harley Davidson",
            //        ManufacturerId = 7,
            //        CategoryId = 5,
            //        PhotoId = 3,
            //        Price = 340000,
            //        GoodCount = 58
            //    });
            //    db.Goods.Add(new Good
            //    {
            //        GoodId = 4,
            //        GoodName = "Huawei Mate 40 Pro",
            //        ManufacturerId = 6,
            //        CategoryId = 1,
            //        PhotoId = 4,
            //        Price = 20000,
            //        GoodCount = 1000
            //    });
            //    db.Goods.Add(new Good
            //    {
            //        GoodId = 5,
            //        GoodName = "IPhone 12 Pro Max",
            //        ManufacturerId = 3,
            //        CategoryId = 1,
            //        PhotoId = 5,
            //        Price = 29000,
            //        GoodCount = 3422
            //    });
            //    db.Goods.Add(new Good
            //    {
            //        GoodId = 6,
            //        GoodName = "MacBook Pro M1 Chip 13'' 8 / 256 Touch Bar Space Gray",
            //        ManufacturerId = 3,
            //        CategoryId = 2,
            //        PhotoId = 6,
            //        Price = 45000,
            //        GoodCount = 800
            //    });
            //    db.Goods.Add(new Good
            //    {
            //        GoodId = 7,
            //        GoodName = "Camera",
            //        ManufacturerId = 5,
            //        CategoryId = 3,
            //        PhotoId = 7,
            //        Price = 8000,
            //        GoodCount = 400
            //    });
            //    db.Receipts.Add(new Receipt
            //    {
            //        PersonId = 1,
            //        GoodId = 2,
            //        Price = 34000,
            //        Amount = 1,
            //        Discount = 10,
            //        GeneralPrice = 30600,
            //        BuyTime = DateTime.Now
            //    });
            //    db.SaveChanges();
            //}
        }
    }
}
