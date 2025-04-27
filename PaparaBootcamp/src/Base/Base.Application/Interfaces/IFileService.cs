using Microsoft.AspNetCore.Http;

namespace Base.Application.Interfaces;

public interface IFileService
{
	Task<string> UploadAsync(IFormFile file, string directory = "");
	Task<byte[]> DownloadAsync(string filePath);
	Task DeleteAsync(string filePath);
}
