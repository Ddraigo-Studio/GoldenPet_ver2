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
using System.IO;

namespace GoldenPet.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private goldenpetEntities db = new goldenpetEntities();
        public int productCount()
        {
            return db.tb_Product.Count();
        }

        // GET: Admin/tb_Product
        public async Task<ActionResult> Index()
        {
            var tb_Product = db.tb_Product.Include(t => t.tb_ProductCategory);
            return View(await tb_Product.ToListAsync());
        }

        // GET: Admin/tb_Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Product tb_Product = await db.tb_Product.FindAsync(id);
            if (tb_Product == null)
            {
                return HttpNotFound();
            }
            return View(tb_Product);
        }

        // GET: Admin/tb_Product/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.tb_ProductCategory, "id", "name");
            return View();
        }

        // POST: Admin/tb_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public async Task<ActionResult> Create([Bind(Include = "id,name,brand,price,priceSale,img,img2,img3,img4,categoryID,description,link,meta,hide,order,createdDate")] tb_Product tb_Product, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";

            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    filename = Path.GetFileName(img.FileName);  // Ensure filename is sanitized

                    path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/img"), filename);

                    img.SaveAs(path);
                    tb_Product.img = filename;  // Set the image URL
                }
                else
                {
                    tb_Product.img = "logo.png";  // Default image if none uploaded
                }

                db.tb_Product.Add(tb_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Product);
        }

        // GET: Admin/tb_Product/Edit/5
        [ValidateInput(false)]

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Product tb_Product = await db.tb_Product.FindAsync(id);
            if (tb_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.tb_ProductCategory, "id", "name", tb_Product.categoryID);
            return View(tb_Product);
        }

        // POST: Admin/tb_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,brand,price,priceSale,img,img2,img3,img4,categoryID,description,link,meta,hide,order,createdDate")] tb_Product tb_Product, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";

            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    filename = Path.GetFileName(img.FileName);  // Ensure filename is sanitized

                    path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/img"), filename);

                    img.SaveAs(path);
                    tb_Product.img = filename;  // Set the image URL
                }
                else
                {
                    tb_Product.img = "logo.png";  // Default image if none uploaded
                }

                db.Entry(tb_Product).State = System.Data.Entity.EntityState.Modified;
                 await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_Product);
            //if (ModelState.IsValid)
            //{
            //    db.Entry(tb_Product).State = System.Data.Entity.EntityState.Modified;
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.categoryID = new SelectList(db.tb_ProductCategory, "id", "name", tb_Product.categoryID);
            //return View(tb_Product);
        }

        // GET: Admin/tb_Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Product tb_Product = await db.tb_Product.FindAsync(id);
            if (tb_Product == null)
            {
                return HttpNotFound();
            }
            return View(tb_Product);
        }

        // POST: Admin/tb_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_Product tb_Product = await db.tb_Product.FindAsync(id);
            db.tb_Product.Remove(tb_Product);
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
