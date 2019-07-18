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

        [Route("Group/{modelId}", Name = "MissionGroup")]
        public async Task<ActionResult> Group(int modelId)
        {
            var model = await _efMissionService.GetGroupAsync(modelId);

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

        [Route("Edit/{modelId}", Name = "MissionEdit")]
        public async Task<ActionResult> Edit(int modelId)
        {
            var model = await _efMissionService.GetGroupAsync(modelId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit", Name = "MissionEditPost")]
        public async Task<ActionResult> Edit(MissionGroup model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _efMissionService.EditGroupAsync(model);

            return RedirectToRoute("MissionGroup", new { modelId = model.Id });
        }

        [Route("Delete/{modelId}", Name = "MissionDelete")]
        public async Task<ActionResult> Delete(int modelId)
        {
            var model = await _efMissionService.GetGroupAsync(modelId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Delete", Name = "MissionDeletePost")]
        public async Task<ActionResult> Delete(MissionGroup model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _efMissionService.DeleteGroupAsync(model);

            return RedirectToRoute("MissionIndex");
        }
    }
}