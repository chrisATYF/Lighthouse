using Lighthouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lighthouse.Services.Interfaces
{
    public interface IMissionGroup
    {
        Task<List<MissionGroup>> GetAllGroupsAsync();
        Task<MissionGroup> GetGroupAsync(int modelId);
        Task<MissionGroup> AddGroupAsync(MissionGroup model);
    }
}