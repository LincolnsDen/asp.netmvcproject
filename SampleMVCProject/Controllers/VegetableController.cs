using SampleMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCProject.Controllers
{
    public class VegetableController : Controller
    {
        AllContext db = new AllContext();

        public ActionResult Index()
        {
            return View(db.vegetables.ToList());
        }

        [Authorize]
        public ActionResult Create()
        {
            return View(db.seasons.ToList());
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Create(Vegetable vegetable, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string fname = Image.FileName;
                string root = Server.MapPath("~/Images/") + fname;
                Image.SaveAs(root);

                vegetable.Image = "/Images/" + fname;
                db.vegetables.Add(vegetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var bce = ModelState.Values.SelectMany(w => w.Errors).Select(e => e.ErrorMessage);
                 ViewBag.er = ModelState.SelectMany(w => w.Value.Errors).Select(e => e.ErrorMessage);
                ViewBag.er = ModelState.Values.SelectMany(e => e.Errors).Select(em => em.ErrorMessage);
                return View(db.seasons.ToList());
            }
        }

        //[Authorize]
        public ActionResult Edit(int Id)
        {
            var row = db.vegetables.Find(Id);
            ViewBag.season = db.seasons.ToList();
            return View(row);
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Edit(Vegetable vegetable, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string fname = Image.FileName;
                string root = Server.MapPath("~/Images/") + fname;
                Image.SaveAs(root);

                vegetable.Image = "/Images/" + fname;
                db.Entry(vegetable).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.er = ModelState.Values.SelectMany(e => e.Errors).Select(em => em.ErrorMessage);
                var row = db.vegetables.Find(vegetable.ID);
                ViewBag.season = db.seasons.ToList();
                return View(row);
            }
        }

        public ActionResult Delete(int Id)
        {
            var row = db.vegetables.Find(Id);
            db.Entry(row).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
