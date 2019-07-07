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
        
        public async Task<Message> AddMessageAsync(Message model)
        {
            _context.Messages.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Message> EditMessageAsync(Message model)
        {
            var modelEdit = await _context.Messages.FirstOrDefaultAsync(i => i.Id == model.Id);
            modelEdit.DateSubmitted = model.DateSubmitted;
            modelEdit.MessageDetails = model.MessageDetails;

            return modelEdit;
        }

        public async Task DeleteMessage(Message model)
        {
            _context.Messages.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PrayerRequest>> GetAllPrayersAsync()
        {
            return await _context.PrayerRequests.ToListAsync();
        }
    }
}