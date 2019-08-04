using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lighthouse.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime AddDate { get; set; }

        [NotMapped]
        public string AddDateHumanized => AddDate.Humanize();
    }
}