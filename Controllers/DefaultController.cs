using GoldenPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenPet.Controllers
{
    public class DefaultController : Controller
    {
        GoldenPetEntities _db = new GoldenPetEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getAbout()
        {
            var v = from t in _db.tb_Advertisement
                    where t.hide == true
                    orderby t.order ascending
                    select t;

            return PartialView(v.ToList());
        }
        public ActionResult getImg(string type)
        {
            var v = from t in _db.tb_Img
                    where t.hide == true && t.type == type  // Filter by type
                    orderby t.order ascending
                    select t;

            return PartialView(v.ToList());  // Return the filtered list
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

        public ActionResult getProductHome(long id, string metatitle)
        {
            ViewBag.meta = metatitle;
            var v = from t in _db.tb_Product
                    where t.categoryID == id && t.hide == true
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

        

    }
}