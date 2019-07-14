using Lighthouse.Models;
using Lighthouse.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lighthouse.Controllers
{
    [RoutePrefix("Prayer")]
    public class PrayerController : Controller
    {
        protected readonly IPrayer _efPrayerService;

        public PrayerController(IPrayer efPrayerService)
        {
            _efPrayerService = efPrayerService;
        }

        [Route("", Name = "PrayerIndex")]
        public async Task<ActionResult> Index()
        {
            var model = await _efPrayerService.GetAllPrayersAsync();

            return View(model);
        }

        [Route("Add", Name = "PrayerAddPrayer")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Add", Name = "PrayerAddPrayerPost")]
        public async Task<ActionResult> Add(PrayerRequest model)
        {
            var userAspNetId = User.Identity.GetUserId();
            var appModel = await _efPrayerService.GetApplicationUserAsync(userAspNetId);
            model.AppUser = appModel;
            model.DateSubmitted = DateTime.UtcNow;
            await _efPrayerService.AddPrayersAsync(model);

            return RedirectToRoute("PrayerIndex");
        }
    }
}