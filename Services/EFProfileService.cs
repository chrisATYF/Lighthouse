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
    public class EFProfileService : IProfile
    {
        protected readonly ApplicationDbContext _context;

        public EFProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> AddUserProfile(UserProfile model)
        {
            _context.UserProfiles.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task DeleteUserProfile(UserProfile model)
        {
            _context.UserProfiles.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<UserProfile> EditUserProfile(UserProfile model)
        {
            var modelEdit = await _context.UserProfiles.FirstOrDefaultAsync(i => i.Id == model.Id);
            modelEdit = model;

            return modelEdit;
        }

        public async Task<List<UserProfile>> GetAllUserProfiles()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetUserProfile(int modelId)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(i => i.Id == modelId);
        }
    }
}