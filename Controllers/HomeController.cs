using Lighthouse.Models;
using Lighthouse.Services.Interfaces;
using Lighthouse.ViewModels;
using Microsoft.AspNet.Identity;
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
        protected readonly IPrayer _efPrayerService;

        public HomeController(IMessage efMessageService, IPrayer efPrayerService)
        {
            _efMessageService = efMessageService;
            _efPrayerService = efPrayerService;
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
            var mssgModel = await _efMessageService.GetAllMessageAsync();
            var prayerModel = await _efPrayerService.GetAllPrayersAsync();
            var model = new MessagePrayerViewModel { Messages = mssgModel, Prayers = prayerModel };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Start", Name = "HomeStartPost")]
        public async Task<ActionResult> Start(Message model)
        {
            model.AspNetUserId = User.Identity.GetUserId();
            model.DateSubmitted = DateTime.UtcNow;
            await _efMessageService.AddMessageAsync(model);

            return RedirectToRoute("HomeStart");
        }
    }
}