using Lighthouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lighthouse.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        protected readonly IMessage _efMessageService;

        public HomeController(IMessage efMessageService)
        {
            _efMessageService = efMessageService;
        }

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
        public async Task<ActionResult> Start()
        {
            var model = await _efMessageService.GetAllMessageAsync();

            return View(model);
        }
    }
}