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
    public class EFUploadFile : IUploadFile
    {
        protected readonly ApplicationDbContext _context; 

        public EFUploadFile(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UploadFile>> GetAllUploadFilesAsync()
        {
            return await _context.UploadFiles.ToListAsync();
        }

        public async Task<UploadFile> GetUploadFileAsync(int modelId)
        {
            return await _context.UploadFiles.FirstOrDefaultAsync(i => i.Id == modelId);
        }

        public async Task<UploadFile> AddUploadFileAsync(UploadFile model)
        {
            _context.UploadFiles.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<UploadFile> EditUploadFileAsync(UploadFile model)
        {
            var modelEdit = await _context.UploadFiles.FirstOrDefaultAsync(i => i.Id == model.Id);
            modelEdit = model;
            modelEdit.DateAdded = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return modelEdit;
        }
        public async Task DeleteUploadFileAsync(UploadFile model)
        {
            _context.UploadFiles.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}