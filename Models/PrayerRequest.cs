using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lighthouse.Models
{
    public class PrayerRequest
    {
        public int Id { get; set; }
        public ApplicationUser AppUser { get; set; }
        public string RequestDetails { get; set; }
        public DateTime DateSubmitted { get; set; }

        [NotMapped]
        public string DateSubmittedHumanized => DateSubmitted.Humanize();
    }
}