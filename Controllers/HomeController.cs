using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lighthouse.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("", Name = "HomeIndex")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToRoute("HomeStart");
            }

            return View();
        }

        [Route("Mission", Name = "HomeMission")]
        public ActionResult Mission()
        {
            return View();
        }

        [Route("Start", Name = "HomeStart")]
        public ActionResult Start()
        {
            return View();
        }
    }
}