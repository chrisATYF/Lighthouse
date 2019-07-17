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
        protected readonly IMissionGroup _efMissionService;

        public HomeController(IMessage efMessageService, IMissionGroup efMissionService)
        {
            _efMessageService = efMessageService;
            _efMissionService = efMissionService;
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
            var missionModel = await _efMissionService.GetAllGroupsAsync();
            var model = new MessageMissionViewModel { Messages = mssgModel, MissionGroups = missionModel };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Start", Name = "HomeStartPost")]
        public async Task<ActionResult> Start(Message model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userAspNetId = User.Identity.GetUserId();
            var appUser = await _efMessageService.GetApplicationUserAsync(userAspNetId);
            model.AppUser = appUser;
            model.DateSubmitted = DateTime.UtcNow;
            await _efMessageService.AddMessageAsync(model);

            return RedirectToRoute("HomeStart");
        }
    }
}