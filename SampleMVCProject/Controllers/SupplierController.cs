using SampleMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCProject.Controllers
{
    public class SupplierController : Controller
    {
        AllContext db = new AllContext();

        public ActionResult Index()
        {
            ViewBag.fruits = db.fruits.ToList();
            return View(db.fruitSuppliers.ToList());
        }



        //[Authorize]
        [HttpPost]
        public ActionResult Create(FruitSupplier supplier)
        {
            if (ModelState.IsValid)
            {

                db.fruitSuppliers.Add(supplier);
                db.SaveChanges();
                return PartialView("_supplierList", db.fruitSuppliers.ToList());
            }
            else
            {
                ViewBag.er = ModelState.Values.SelectMany(e => e.Errors).Select(em => em.ErrorMessage);
                return View(db.fruits.ToList());
            }
        }

        //[Authorize]
        public ActionResult Edit(int Id)
        {
            var row = db.fruitSuppliers.Find(Id);
            ViewBag.fruit = db.fruits.ToList();
            return View(row);
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Edit(FruitSupplier supplier)
        {
            if (ModelState.IsValid)
            {

                db.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.er = ModelState.Values.SelectMany(e => e.Errors).Select(em => em.ErrorMessage);
                var row = db.fruitSuppliers.Find(supplier.ID);
                ViewBag.fruit = db.fruits.ToList();
                return View(row);
            }
        }

        public ActionResult Delete(int Id)
        {
            var row = db.fruitSuppliers.Find(Id);
            db.Entry(row).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}