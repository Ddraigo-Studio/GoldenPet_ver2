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
    public class ServiceController : Controller
    {
        private goldenpetEntities db = new goldenpetEntities();

        // GET: Admin/Service
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_Service.ToListAsync());
        }

        // GET: Admin/Service/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Service tb_Service = await db.tb_Service.FindAsync(id);
            if (tb_Service == null)
            {
                return HttpNotFound();
            }
            return View(tb_Service);
        }

        // GET: Admin/Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,title,description,description_1,description_2,price,duration,img,img2,img3,img4,link,meta,hide,order,createdDate,createdBy,modifidedDate,modifidedBy")] tb_Service tb_Service)
        {
            if (ModelState.IsValid)
            {
                db.tb_Service.Add(tb_Service);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_Service);
        }

        // GET: Admin/Service/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Service tb_Service = await db.tb_Service.FindAsync(id);
            if (tb_Service == null)
            {
                return HttpNotFound();
            }
            return View(tb_Service);
        }

        // POST: Admin/Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,title,description,description_1,description_2,price,duration,img,img2,img3,img4,link,meta,hide,order,createdDate,createdBy,modifidedDate,modifidedBy")] tb_Service tb_Service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Service).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_Service);
        }

        // GET: Admin/Service/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Service tb_Service = await db.tb_Service.FindAsync(id);
            if (tb_Service == null)
            {
                return HttpNotFound();
            }
            return View(tb_Service);
        }

        // POST: Admin/Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_Service tb_Service = await db.tb_Service.FindAsync(id);
            db.tb_Service.Remove(tb_Service);
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
