using ASP.NETMVC.Models;
using ASP.NETMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVC.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryRepository repo=new CategoryRepository();
        // GET: Category
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
             repo.Add(category);           
              TempData["Insert"] = "Category Added SuccesFully";
             return RedirectToAction("Index");
            }
            return View(category);
        }
        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                repo.Update(category);
                TempData["Update"] = "Category Update SuccesFully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public ActionResult Delete(int id)
        {
            return View(repo.GetById(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            TempData["Delete"] = "Category Delete SuccesFully";
            return RedirectToAction("Index");
        }
    }
}