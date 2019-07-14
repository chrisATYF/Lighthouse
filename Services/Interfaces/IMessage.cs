using Lighthouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lighthouse.Services.Interfaces
{
    public interface IMessage
    {
        Task<List<Message>> GetAllMessageAsync();
        Task<List<PrayerRequest>> GetAllPrayersAsync();
        Task<Message> AddMessageAsync(Message model);
        Task<Message> EditMessageAsync(Message model);
        Task DeleteMessage(Message model);
        Task<ApplicationUser> GetApplicationUserAsync(string aspNetUserId);
    }
}