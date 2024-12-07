using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoldenPet.Models;

namespace GoldenPet.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private goldenpetEntities db = new goldenpetEntities();
        public int newsCount()
        {
            return db.tb_News.Count();
        }
        // GET: Admin/News
        public ActionResult Index()
        {
            return View(db.tb_News.ToList());
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_News tb_News = db.tb_News.Find(id);
            if (tb_News == null)
            {
                return HttpNotFound();
            }
            return View(tb_News);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "NewsID,Title,Content,Slug,AuthorName,CategoryName,PublishedDate,LastModifiedDate,Status,Summary,ThumbnailImageURL,MetaTitle")] tb_News tb_News, HttpPostedFileBase img)
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
                    tb_News.ThumbnailImageURL =  filename;  // Set the image URL
                }
                else
                {
                    tb_News.ThumbnailImageURL = "logo.png";  // Default image if none uploaded
                }

                db.tb_News.Add(tb_News);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_News);
        }

        // GET: Admin/News/Edit/5
        [ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_News tb_News = db.tb_News.Find(id);
            if (tb_News == null)
            {
                return HttpNotFound();
            }
            return View(tb_News);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "NewsID,Title,Content,Slug,AuthorName,CategoryName,PublishedDate,LastModifiedDate,Status,Summary,ThumbnailImageURL,MetaTitle")] tb_News tb_News)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_News).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_News);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_News tb_News = db.tb_News.Find(id);
            if (tb_News == null)
            {
                return HttpNotFound();
            }
            return View(tb_News);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_News tb_News = db.tb_News.Find(id);
            db.tb_News.Remove(tb_News);
            db.SaveChanges();
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
