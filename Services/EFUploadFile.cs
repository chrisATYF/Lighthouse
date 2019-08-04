using Lighthouse.Models;
using Lighthouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lighthouse.Services
{
    public class EFUploadFile : IUploadFile
    {
        protected readonly ApplicationDbContext _context; 

        public EFUploadFile(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}