using GoldenPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenPet.Controllers
{
    public class BookingController : Controller
    {
        goldenpetEntities _db = new goldenpetEntities();

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookAppointment([Bind(Include = "id,customerID,serviceID,bookingDate,appoINTmentDate,petNumber,status")] tb_Booking tb_Booking)
        {
            if (ModelState.IsValid)
            {
                _db.tb_Booking.Add(tb_Booking);
                _db.SaveChanges();
                return RedirectToAction("Index", "Default");

            }
            return View();
        }
    }
}