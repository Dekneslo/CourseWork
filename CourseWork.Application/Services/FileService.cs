using CourseWork.Domain.Contracts.FileContracts;
using CourseWork.Domain.Interfaces;
using CourseWork.Domain.Results;
using CourseWork.Persistence;
using Microsoft.EntityFrameworkCore;
using File = CourseWork.Domain.Entities.File;
using FileNotFoundException = CourseWork.Domain.Exceptions.FileNotFoundException;

namespace CourseWork.Application.Services
{
    public class FileService : IFileService
    {
        private readonly CharityDBContext _charityDbContext;


        public FileService(CharityDBContext charityDbContext)
        {
            _charityDbContext = charityDbContext;
        }

        public async Task<FileResponse> AddFileAsync(UploadFileRequest fileRequest)
        {
            var file = new File
            {
                FilePath = fileRequest.FilePath,
                FileType = fileRequest.FileType,
                FileName = fileRequest.FileName,
                UserId = fileRequest.IdUser
            };
            
            await _charityDbContext.Files.AddAsync(file);
            await _charityDbContext.SaveChangesAsync();
            return new FileResponse
            {
                FileName = file.FileName,
                FilePath = file.FilePath,
                FileSize = file.FileSize,
                FileType = file.FileType,
                IdFile = file.FileId
            };
        }

        public async Task<FileResponse[]> GetFilesByUserAsync(int userId)
        {
            var files = await _charityDbContext.Files.Where(x => x.UserId == userId).Select(x => new FileResponse
            {
                FileName = x.FileName,
                FilePath = x.FilePath,
                FileSize = x.FileSize,
                FileType = x.FileType,
                IdFile = x.FileId
            }).ToArrayAsync();
            return files;
        }

        public async Task<FileResponse> UploadFileAsync(UploadFileRequest request)
        {
            var file = new File
            {
                FilePath = request.FilePath,
                FileType = request.FileType,
                FileName = request.FileName,
                UserId = request.IdUser
            };
            
            await _charityDbContext.Files.AddAsync(file);
            await _charityDbContext.SaveChangesAsync();

            return new FileResponse
            {
                FileName = file.FileName,
                FilePath = file.FilePath,
                FileSize = file.FileSize,
                FileType = file.FileType,
                IdFile = file.FileId
            };
        }

        public async Task<FileResponse> UpdateFileAsync(UpdateFileRequest request)
        {
            var file = await _charityDbContext.Files.FirstOrDefaultAsync(x => x.FileId == request.FileId);
            if (file == null)
            {
                throw new FileNotFoundException();
            }

            file.FileType = request.FileType;
            file.FileName = request.FileName;
            file.UserId = request.IdUser;
            
            await _charityDbContext.SaveChangesAsync();

            return new FileResponse
            {
                FileName = file.FileName,
                FilePath = file.FilePath,
                FileSize = file.FileSize,
                FileType = file.FileType,
                IdFile = file.FileId
            };
        }

        public async Task<FileResponse> DeleteFileAsync(int id)
        {
            var file = await _charityDbContext.Files.FirstOrDefaultAsync(x => x.FileId == id);
            if (file == null)
            {
                throw new FileNotFoundException();
            }

            _charityDbContext.Files.Remove(file);
            await _charityDbContext.SaveChangesAsync();

            return new FileResponse
            {
                FileName = file.FileName,
                FilePath = file.FilePath,
                FileSize = file.FileSize,
                FileType = file.FileType,
                IdFile = file.FileId
            };
        }

        public async Task<CourseWork.Domain.Entities.FileAccess> SetFileAccessAsync(int fileId, int userId, string accessType)
        {
            var fileAccess = new CourseWork.Domain.Entities.FileAccess
            {
                IdFile = fileId,
                IdUser = userId,
                AccessType = accessType
            };

            await _charityDbContext.FileAccesses.AddAsync(fileAccess);
            await _charityDbContext.SaveChangesAsync();
            return fileAccess;
        }
    }
}
