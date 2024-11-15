﻿using GoldenPet.Models;
using GoldenPet.Models.PackagePricing_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static GoldenPet.Models.PackagePricing_Model.PackagePricing;

namespace GoldenPet.Controllers
{
    public class AboutUsController : Controller
    {
        goldenpetEntities _db = new goldenpetEntities();
        // GET: AboutUs
        public ActionResult Index()
        {
            return View();
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
    }
}