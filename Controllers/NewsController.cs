using GoldenPet.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GoldenPet.Controllers
{
    public class NewsController : Controller
    {
        goldenpetEntities _db = new goldenpetEntities();

        public ActionResult getNews_Index(int page = 1, int pageSize = 6)
        {
            var v = from t in _db.tb_News
                    orderby t.PublishedDate
            select t;

            var newsList = v.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Tính tổng số trang từ cơ sở dữ liệu
            int totalPages = (int)Math.Ceiling((double)v.Count() / pageSize);

            ViewBag.CurrentPage = page;  // Trang hiện tại
            ViewBag.TotalPages = totalPages;  // Tổng số trang

            return View(newsList);
        }
        public ActionResult getNew_Details(int id) {
            var v = from t in _db.tb_News
                    where t.NewsID == id
                    select t;
            return View(v); }
    }
}