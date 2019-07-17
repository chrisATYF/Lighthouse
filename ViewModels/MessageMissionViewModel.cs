using Lighthouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lighthouse.ViewModels
{
    public class MessageMissionViewModel
    {
        public int Id { get; set; }
        public List<Message> Messages { get; set; }
        public List<MissionGroup> MissionGroups { get; set; }
    }
}