using ASP.NETMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace ASP.NETMVC.Repository
{
    public class ProductRepository
    {
        private ApplicationDbContext db=new ApplicationDbContext();

        public List<Product> GetAll(int pageNumber, int pageSize, out int totalRecords)
        {
            totalRecords = db.Products.Count();

            return db.Products
                .Include("Category")  
            .OrderBy(p => p.ProductId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public Product GetById (int id)
        {

            return db.Products.Find(id);
        }
        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Update(Product product) 
        {
            db.Entry(product).State=EntityState.Modified;
            db.SaveChanges();   
        }

        public void Delete(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
               db.Products.Remove(product);
              db.SaveChanges();
            }
        }    
    }
}