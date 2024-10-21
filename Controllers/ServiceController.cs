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

        public ActionResult Detail(string meta)
        {
            var service = _db.tb_Service.FirstOrDefault(t => t.meta == meta);
            if (service == null)
            {
                return HttpNotFound(); // Return 404 error if no service is found
            }
            return View(service);
        }

    }
}