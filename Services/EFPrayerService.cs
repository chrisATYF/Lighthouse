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
    public class EFPrayerService : IPrayer
    {
        protected readonly ApplicationDbContext _context;

        public EFPrayerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PrayerRequest>> GetAllPrayersAsync()
        {
            return await _context.PrayerRequests.ToListAsync();
        }
    }
}