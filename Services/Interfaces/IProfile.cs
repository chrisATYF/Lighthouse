using Lighthouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lighthouse.Services.Interfaces
{
    public interface IProfile
    {
        Task<List<UserProfile>> GetAllUserProfiles();
        Task<UserProfile> GetUserProfile(int modelId);
        Task<UserProfile> AddUserProfile(UserProfile model);
        Task<UserProfile> EditUserProfile(UserProfile model);
        Task DeleteUserProfile(UserProfile model);
    }
}