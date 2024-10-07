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
        public ActionResult Index(string metatitle)
        {
            ViewBag.meta = metatitle;
            var v = from t in _db.tb_Product
                    where  t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getCategory()
        {
            //var category = _db.Menus.Where(x => x.Id == 3).FirstOrDefault();
            ViewBag.meta = "san-pham";
            var v = from t in _db.tb_ProductCategory
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getProduct(long id, string metatitle)
        {
            ViewBag.meta = metatitle;
            var v = from t in _db.tb_Product
                    where t.categoryID == id && t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult Detail(long id)
        {
            
            var v = from t in _db.tb_Product
                    where  t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }

    }
}