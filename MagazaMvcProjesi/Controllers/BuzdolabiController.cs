﻿using MagazaMvcProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaMvcProjesi.Controllers
{
    [Authorize(Roles ="A")]
    public class BuzdolabiController : Controller
    {
        MagazaMvcProjemEntities db = new MagazaMvcProjemEntities();
       

        public ActionResult Liste(string searchBy,string search)
        {

           if(searchBy== "refColor")
            {
                return View(db.Refrigators.Where(i=>i.refColor==search || search==null).ToList());
            }
            else
            {
                return View(db.Refrigators.Where(i=>i.energyClass==search || search==null).ToList());
            }


        }

        public ActionResult Ekle()
        {


            List<SelectListItem> veriler = (from x in db.Dealers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.dealerId.ToString(),
                                                Value = x.dealerId.ToString()

                                            }).ToList();

            ViewBag.veri = veriler;



            List<SelectListItem> datalar = (from i in db.Customers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.customerId.ToString(),
                                                Value = i.customerId.ToString()

                                            }).ToList();

            ViewBag.data = datalar;


            return View();


        }

        [HttpPost]
        public ActionResult Ekle(Refrigator refrigate)
        {
            try
            {
                db.Refrigators.Add(refrigate);
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            catch
            {

                return View();
            }




        }

        public ActionResult Güncelle(int id)
        {
            List<SelectListItem> veriler = (from x in db.Dealers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.dealerId.ToString(),
                                                Value = x.dealerId.ToString()

                                            }).ToList();

            ViewBag.veri = veriler;



            List<SelectListItem> datalar = (from i in db.Customers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.customerId.ToString(),
                                                Value = i.customerId.ToString()

                                            }).ToList();

            ViewBag.data = datalar;

            var result = db.Refrigators.Find(id);
            return View(result);




        }
        [HttpPost]
        public ActionResult Güncelle(int id, Refrigator refrigate)
        {
            try
            {
                db.Entry(refrigate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            catch
            {

                return View();
            }



        }

        public ActionResult Sil(int id)
        {
            var result = db.Televisions.Find(id);
            return View(result);


        }
        [HttpPost]
        public ActionResult Sil(int id, Television televizyon)
        {

            try
            {
                var result = db.Televisions.Find(id);
                db.Televisions.Remove(result);
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            catch
            {

                return View();
            }


        }

    }
}