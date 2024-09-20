using GoldenPet.Models;
using System.Linq;
using System.Web.Mvc;

namespace GoldenPet.Controllers
{
    public class MenuController : Controller
    {
        GoldenPetEntities _db = new GoldenPetEntities();

        // GET: Memu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMenu()
        {
            var v = from t in _db.tb_Menu
                    where t.hide == true
                    orderby t.order ascending
                    select t;

            return PartialView(v.ToList());
        }
    }
}