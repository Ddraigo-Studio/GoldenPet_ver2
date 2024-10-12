using GoldenPet.Models;
using GoldenPet.Models.PackagePricing_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static GoldenPet.Models.PackagePricing_Model.PackagePricing;

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

        public ActionResult getImg(string type) //hàm get Partial view cho trang defualt 
        {
            var v = from t in _db.tb_Img
                    where t.hide == true && t.type == type  
                    orderby t.order ascending
                    select t;

            return PartialView(v.ToList()); 
        }

        public ActionResult getFooter()
        {
            var v = from t in _db.tb_Contact
                    select t;
              
            return PartialView(v.ToList());

        }

        public ActionResult getContactInfoTopBar()
        {
            var v = from t in _db.tb_Contact
                    select t;
            return PartialView(v.ToList());

        }

        public ActionResult getPricingPlan()
        {
            var packages = _db.tb_Package
                              .Select(p => new PackagePricing
                              {
                                  PackageName = p.name,
                                  PackagePrice = p.price,
                                  Imglink=p.img,
                                  Features = _db.tb_PackageFeature
                                                .Where(f => f.packageId == p.id)
                                                .Select(f => new FeatureModel
                                                {
                                                    FeatureName = f.featureName,
                                                    IsIncluded = f.isIncluded ?? false
                                                    
                                                }).ToList()
                              }).ToList();

            return PartialView(packages);
        }

        public ActionResult getAboutUs()
        {
            var packages = _db.tb_Package
                              .Select(p => new PackagePricing
                              {
                                  PackageName = p.name,
                                  PackagePrice = p.price,
                                  Imglink = p.img,
                                  Features = _db.tb_PackageFeature
                                                .Where(f => f.packageId == p.id)
                                                .Select(f => new FeatureModel
                                                {
                                                    FeatureName = f.featureName,
                                                    IsIncluded = f.isIncluded ?? false

                                                }).ToList()
                              }).ToList();

            return PartialView(packages);
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
            var v = (from t in _db.tb_Product
                     where t.categoryID == id && t.hide == true
                     orderby t.order descending
                     select t).Take(4); // Chỉ lấy 4 sản phẩm

            return PartialView(v.ToList());
        }


        public ActionResult getNews()
        {
            var v = from t in _db.tb_News
                    select t;

            return PartialView(v.ToList());
        }





    }
}