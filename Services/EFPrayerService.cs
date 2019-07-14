﻿using Lighthouse.Models;
using Lighthouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lighthouse.Services
{
    public class EFPrayerService : IPrayer
    {
        protected readonly ApplicationDbContext _context;

        public EFPrayerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PrayerRequest>> GetAllPrayersAsync()
        {
            return await _context.PrayerRequests
                .Include(a => a.AppUser)
                .ToListAsync();
        }

        public async Task<PrayerRequest> AddPrayersAsync(PrayerRequest model)
        {
            _context.PrayerRequests.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<ApplicationUser> GetApplicationUserAsync(string aspNetUserId)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Id == aspNetUserId);
        }
    }
}