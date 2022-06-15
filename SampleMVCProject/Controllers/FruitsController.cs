using SampleMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCProject.Controllers
{
    public class FruitsController : Controller
    {
        AllContext db = new AllContext();
        public ActionResult Index()
        {
            ViewBag.season = db.seasons.ToList();
            return View(db.fruits.ToList());
           
        }


        
        [HttpPost]
        public ActionResult Create(Fruit fruit, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string fname = Image.FileName;
                string root = Server.MapPath("~/Images/") + fname;
                Image.SaveAs(root);

                fruit.Image = "/Images/" + fname;
                db.fruits.Add(fruit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.er = ModelState.Values.SelectMany(e => e.Errors).Select(em => em.ErrorMessage);
                return View(db.seasons.ToList());
            }
        }

        
        public ActionResult Edit(int Id)
        {
            var row = db.fruits.Find(Id);
            ViewBag.season = db.seasons.ToList();
            return View(row);
        }

        
        [HttpPost]
        public ActionResult Edit(Fruit fruit, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string fname = Image.FileName;
                string root = Server.MapPath("~/Images/") + fname;
                Image.SaveAs(root);

                fruit.Image = "/Images/" + fname;
                db.Entry(fruit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.er = ModelState.Values.SelectMany(e => e.Errors).Select(em => em.ErrorMessage);
                var row = db.fruits.Find(fruit.ID);
                ViewBag.season = db.seasons.ToList();
                return View(row);
            }
        }

        public ActionResult Delete(int Id)
        {
            var row = db.fruits.Find(Id);
            db.Entry(row).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
 