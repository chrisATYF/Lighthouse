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
    [RoutePrefix("Profile")]
    public class ProfileController : Controller
    {
        protected readonly IProfile _efProfileService;

        public ProfileController(IProfile efProfileService)
        {
            _efProfileService = efProfileService;
        }
        
        [Route("", Name = "ProfileIndex")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("SingleProfile/{modelId}", Name = "ProfileSingleProfile")]
        public async Task<ActionResult> SingleProfile(int modelId)
        {
            var model = await _efProfileService.GetUserProfile(modelId);

            return View(model);
        }

        [Route("Add", Name = "ProfileAdd")]
        public ActionResult Add()
        {
            var model = new UserProfile();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Add", Name = "ProfileAddPost")]
        public async Task<ActionResult> Add(UserProfile model)
        {
            await _efProfileService.AddUserProfile(model);

            return RedirectToRoute("ProfileSingleProfile", new { modelId = model.Id });
        }
    }
}