using Humanizer;
using Lighthouse.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lighthouse.Models
{
    public class MissionGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public ApplicationUser GroupCreator { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public Countries Country { get; set; }

        [NotMapped]
        public string DateCreatedHumanized => DateCreated.Humanize();
    }
}