using ASP.NETMVC.Models;
using ASP.NETMVC.Repository;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVC.Controllers
{
    public class ProductController : Controller
    {
       private ProductRepository repo =new ProductRepository();
       private CategoryRepository categoryrepo =new CategoryRepository();
        // GET: Product
        public ActionResult Index(int page=1,int pageSize = 10)
        {
            int totalRecords;
            var products = repo.GetAll(page, pageSize, out totalRecords);

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(products);
        }

        public ActionResult create()
        {
            ViewBag.CategoryId = new SelectList(categoryrepo.GetAll(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
             repo.Add(product);
                TempData["Insert"] = "Product Added SuccesFully";
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(categoryrepo.GetAll(), "CategoryId", "CategoryName");
            return View(product);
        }
        public ActionResult Edit(int id)
        {
            var product=repo.GetById(id);

            ViewBag.CategoryId = new SelectList(categoryrepo.GetAll(), "CategoryId", "CategoryName",product.CategoryId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Update(product);
                TempData["Update"] = "Product Updated SuccesFully";
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(categoryrepo.GetAll(), "CategoryId", "CategoryName");
            return View(product) ;
        }

        public ActionResult Delete(int id)
        {
            return View(repo.GetById(id));  
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            TempData["Delete"] = "Product Deleted SuccesFully";
            return RedirectToAction("Index");   
        }
    }
}