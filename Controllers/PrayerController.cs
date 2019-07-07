using Lighthouse.Services.Interfaces;
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
    }
}