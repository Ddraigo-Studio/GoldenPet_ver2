using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoldenPet.Models;

namespace GoldenPet.Areas.Admin.Controllers
{
    public class tb_BookingController : Controller
    {
        private goldenpetEntities db = new goldenpetEntities();
        public int bookingCount()
        {
            return db.tb_Booking.Count();
        }

        // GET: Admin/tb_Booking
        public async Task<ActionResult> Index()
        {
            var tb_Booking = db.tb_Booking.Include(t => t.tb_Customer).Include(t => t.tb_Service);
            return View(await tb_Booking.ToListAsync());
        }

        // GET: Admin/tb_Booking/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Booking tb_Booking = await db.tb_Booking.FindAsync(id);
            if (tb_Booking == null)
            {
                return HttpNotFound();
            }
            return View(tb_Booking);
        }

        // GET: Admin/tb_Booking/Create
        public ActionResult Create()
        {
            ViewBag.customerID = new SelectList(db.tb_Customer, "id", "customerName");
            ViewBag.serviceID = new SelectList(db.tb_Service, "id", "name");
            return View();
        }

        // POST: Admin/tb_Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,customerID,serviceID,bookingDate,appoINTmentDate,petNumber,status")] tb_Booking tb_Booking)
        {
            if (ModelState.IsValid)
            {
                db.tb_Booking.Add(tb_Booking);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.customerID = new SelectList(db.tb_Customer, "id", "customerName", tb_Booking.customerID);
            ViewBag.serviceID = new SelectList(db.tb_Service, "id", "name", tb_Booking.serviceID);
            return View(tb_Booking);
        }

        // GET: Admin/tb_Booking/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Booking tb_Booking = await db.tb_Booking.FindAsync(id);
            if (tb_Booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerID = new SelectList(db.tb_Customer, "id", "customerName", tb_Booking.customerID);
            ViewBag.serviceID = new SelectList(db.tb_Service, "id", "name", tb_Booking.serviceID);
            return View(tb_Booking);
        }

        // POST: Admin/tb_Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,customerID,serviceID,bookingDate,appoINTmentDate,petNumber,status")] tb_Booking tb_Booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Booking).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.customerID = new SelectList(db.tb_Customer, "id", "customerName", tb_Booking.customerID);
            ViewBag.serviceID = new SelectList(db.tb_Service, "id", "name", tb_Booking.serviceID);
            return View(tb_Booking);
        }

        // GET: Admin/tb_Booking/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Booking tb_Booking = await db.tb_Booking.FindAsync(id);
            if (tb_Booking == null)
            {
                return HttpNotFound();
            }
            return View(tb_Booking);
        }

        // POST: Admin/tb_Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_Booking tb_Booking = await db.tb_Booking.FindAsync(id);
            db.tb_Booking.Remove(tb_Booking);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
