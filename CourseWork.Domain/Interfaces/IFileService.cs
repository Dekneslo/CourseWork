using CourseWork.Domain.Contracts.FileContracts;
using FileAccess = CourseWork.Domain.Entities.FileAccess;

namespace CourseWork.Domain.Interfaces
{
    public interface IFileService
    {
        Task<FileResponse[]> GetFilesByUserAsync(int userId);
        
        Task<FileResponse> AddFileAsync(UploadFileRequest request);
        
        Task<FileResponse> UpdateFileAsync(UpdateFileRequest request);
        
        Task<FileResponse> UploadFileAsync(UploadFileRequest request);
        
        Task<FileResponse> DeleteFileAsync(int id);

        Task<FileAccess> SetFileAccessAsync(int fileId, int userId, string accessType);
    }
}
