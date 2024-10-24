using GoldenPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenPet.Controllers
{
    public class ServiceController : Controller
    {
        GoldenPetEntities _db = new GoldenPetEntities();

        // GET: Service
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Detail(long id)
        {
            var v = from t in _db.tb_Service
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }


        public ActionResult getServiceCategory()
        {
            ViewBag.meta = "dich-vu";
            var v = from t in _db.tb_Service
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }


        public ActionResult getImgService(long id)
        {
            var v = from t in _db.tb_ImgService
                    where t.hide == true && t.id_Service == id
                    select t;
            return PartialView(v.FirstOrDefault());
        }

    }
}