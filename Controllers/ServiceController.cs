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

        public ActionResult Detail() 
        {
            var v = from t in _db.tb_Service
                    select t;
            return View(v.ToList());
        }
    }
}