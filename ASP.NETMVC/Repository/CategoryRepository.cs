using ASP.NETMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NETMVC.Repository
{
    public class CategoryRepository
    {
     private ApplicationDbContext db = new ApplicationDbContext();
        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public Category GetById(int id)
        {
            return db.Categories.Find(id);
        }
        public void Add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void Update(Category category) 
        {
            db.Entry(category).State=EntityState.Modified;  
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }          
        }
    }
}