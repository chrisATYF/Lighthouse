using Lighthouse.Models;
using Lighthouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lighthouse.Services
{
    public class EFMessageService : IMessage
    {
        protected readonly ApplicationDbContext _context;
        public EFMessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetAllMessageAsync()
        {
            return await _context.Messages.ToListAsync();
        }
    }
}