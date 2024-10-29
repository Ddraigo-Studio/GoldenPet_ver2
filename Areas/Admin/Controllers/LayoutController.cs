using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenPet.Areas.Admin.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Admin/Layout
        public ActionResult Top()
        {
            return PartialView();
        }
        public ActionResult Middle()
        {
            return PartialView();
        }
        public ActionResult Bottom()
        {
            return PartialView();
        }
        public ActionResult Middle_2()
        {
            return PartialView();
        }

    }
}