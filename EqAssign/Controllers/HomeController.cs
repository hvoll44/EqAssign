using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EqAssign.Controllers
{
    //[AllowAnonymous]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }
    }
}