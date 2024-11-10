using GoldenPet.Models;
using System.Linq;
using System.Web.Mvc;
using GoldenPet.Models;

namespace GoldenPet.Controllers
{
    public class MenuController : Controller
    {
        goldenpetEntities _db = new goldenpetEntities();

        public ActionResult GetMenu()
        {
            var v = from t in _db.tb_Menu
                    where t.hide == true
                    orderby t.order ascending
                    select t;

            return PartialView(v.ToList());
        }

        public ActionResult GetMenuCategory(long id, string metatitle)
        {
            ViewBag.meta = metatitle;
            var v = from t in _db.tb_MenuCategory
                    where  t.menuId == id && t.hide == true
                    orderby t.order ascending
                    select t;

            return PartialView(v.ToList());
        }

        public ActionResult GetLogo()
        {         
            var logo = from t in _db.tb_Logo
                    where  t.hide == true
                    select t;

            return PartialView(logo.FirstOrDefault());
        }
    }
}