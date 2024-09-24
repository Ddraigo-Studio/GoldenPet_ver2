using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoldenPet.Models;

namespace GoldenPet.Controllers
{
    public class ProductController : Controller
    {
        
        GoldenPetEntities _db = new GoldenPetEntities();
        // GET: Product
        public ActionResult Index(string meta)
        {
            var v = from t in _db.tb_Product
                    where t.meta == meta
                    select t;
            return View(v.FirstOrDefault());
        }

        public ActionResult Detail(long id)
        {
            var v = from t in _db.tb_Product
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }

    }
}