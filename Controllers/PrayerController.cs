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

        [Route("SingleRequest/{modelId}", Name = "PrayerSingleRequest")]
        public async Task<ActionResult> SingleRequest(int modelId)
        {
            var model = await _efPrayerService.GetPrayerAsync(modelId);
            
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
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userAspNetId = User.Identity.GetUserId();
            var appModel = await _efPrayerService.GetApplicationUserAsync(userAspNetId);
            model.AppUser = appModel;
            model.DateSubmitted = DateTime.UtcNow;
            await _efPrayerService.AddPrayersAsync(model);

            return RedirectToRoute("PrayerIndex");
        }

        [Route("Edit/{modelId}", Name = "PrayerEdit")]
        public async Task<ActionResult> Edit(int modelId)
        {
            var model = await _efPrayerService.GetPrayerAsync(modelId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit", Name = "PrayerEditPost")]
        public async Task<ActionResult> Edit(PrayerRequest model)
        {
            await _efPrayerService.EditPrayerAsync(model);

            return RedirectToRoute("PrayerRequest", new { modelId = model.Id });
        }

        [Route("Delete/{modelId}", Name = "PrayerDelete")]
        public async Task<ActionResult> Delete(int modelId)
        {
            var model = await _efPrayerService.GetPrayerAsync(modelId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Delete", Name = "PrayerDeletePost")]
        public async Task<ActionResult> Delete(PrayerRequest model)
        {
            await _efPrayerService.DeletePrayerAsync(model);

            return RedirectToRoute("PrayerIndex");
        }
    }
}
