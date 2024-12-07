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
    public class ContactController : Controller
    {
        private goldenpetEntities db = new goldenpetEntities();

        // GET: Admin/Contact
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_Contact.ToListAsync());
        }

        // GET: Admin/Contact/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Contact tb_Contact = await db.tb_Contact.FindAsync(id);
            if (tb_Contact == null)
            {
                return HttpNotFound();
            }
            return View(tb_Contact);
        }

        // GET: Admin/Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,phonenumber,location,email")] tb_Contact tb_Contact)
        {
            if (ModelState.IsValid)
            {
                db.tb_Contact.Add(tb_Contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_Contact);
        }

        // GET: Admin/Contact/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Contact tb_Contact = await db.tb_Contact.FindAsync(id);
            if (tb_Contact == null)
            {
                return HttpNotFound();
            }
            return View(tb_Contact);
        }

        // POST: Admin/Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,phonenumber,location,email")] tb_Contact tb_Contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Contact).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_Contact);
        }

        // GET: Admin/Contact/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Contact tb_Contact = await db.tb_Contact.FindAsync(id);
            if (tb_Contact == null)
            {
                return HttpNotFound();
            }
            return View(tb_Contact);
        }

        // POST: Admin/Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_Contact tb_Contact = await db.tb_Contact.FindAsync(id);
            db.tb_Contact.Remove(tb_Contact);
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
