using Microsoft.AspNetCore.Http;

namespace Base.Application.Interfaces;

public interface IFileService
{
	Task<string> UploadFileAsync(IFormFile file, string folderPath);
	Task DeleteFileAsync(string filePath);
}
