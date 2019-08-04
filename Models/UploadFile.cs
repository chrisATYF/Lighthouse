using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lighthouse.Models
{
    public class UploadFile
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public string ExternalURL { get; set; }
        public byte[] Data { get; set; }
        public DateTime DateAdded { get; set; }

        [NotMapped]
        public string DateAddedHumanized => DateAdded.Humanize();
    }
}