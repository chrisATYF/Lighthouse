using Lighthouse.Models;
using Lighthouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lighthouse.Controllers
{
    [RoutePrefix("MissionGroup")]
    public class MissionGroupController : Controller
    {
        protected readonly IMissionGroup _efMissionService;

        public MissionGroupController(IMissionGroup efMissionService)
        {
            _efMissionService = efMissionService;
        }

        [Route("", Name = "MissionIndex")]
        public async Task<ActionResult> Index()
        {
            var model = await _efMissionService.GetAllGroupsAsync();

            return View(model);
        }

        [Route("Group/{groupId}", Name = "MissionGroup")]
        public async Task<ActionResult> Group(int groupId)
        {
            var model = await _efMissionService.GetGroupAsync(groupId);

            return View(model);
        }

        [Route("Add", Name = "MissionAdd")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Add", Name = "MissionAddPost")]
        public async Task<ActionResult> Add(MissionGroup model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _efMissionService.AddGroupAsync(model);

            return RedirectToRoute("MissionIndex");
        }
    }
}