using Lighthouse.Models;
using Lighthouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lighthouse.Services
{
    public class EFMissionGroupService : IMissionGroup
    {
        protected readonly ApplicationDbContext _context;

        public EFMissionGroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MissionGroup>> GetAllGroupsAsync()
        {
            return await _context.MissionGroups.ToListAsync();
        }

        public async Task<MissionGroup> GetGroupAsync(int modelId)
        {
            return await _context.MissionGroups.FirstOrDefaultAsync(i => i.Id == modelId);
        }

        public async Task<MissionGroup> AddGroupAsync(MissionGroup model)
        {
            model.DateCreated = DateTime.UtcNow;
            _context.MissionGroups.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }
    }
}