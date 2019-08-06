using Lighthouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lighthouse.Services.Interfaces
{
    public interface IUploadFile
    {
        Task<List<UploadFile>> GetAllUploadFilesAsync();
        Task<UploadFile> GetUploadFileAsync(int modelId);
        Task<UploadFile> AddUploadFileAsync(UploadFile model);
        Task<UploadFile> EditUploadFileAsync(UploadFile model);
        Task DeleteUploadFileAsync(UploadFile model);
    }
}