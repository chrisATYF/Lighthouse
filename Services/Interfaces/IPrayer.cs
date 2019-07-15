using Lighthouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lighthouse.Services.Interfaces
{
    public interface IPrayer
    {
        Task<List<PrayerRequest>> GetAllPrayersAsync();
        Task<PrayerRequest> GetPrayerAsync(int prayerId);
        Task<PrayerRequest> AddPrayersAsync(PrayerRequest model);
        Task<PrayerRequest> EditPrayerAsync(PrayerRequest model);
        Task DeletePrayerAsync(PrayerRequest model);
        Task<ApplicationUser> GetApplicationUserAsync(string aspNetUserId);
    }
}