using Base.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Base.Infrastructure.Services.File;

public class LocalFileService : IFileService
{
	private readonly string _rootPath;

	public LocalFileService(IConfiguration configuration)
	{
		_rootPath = configuration["FileSettings:RootPath"] ?? "UploadedFiles";
	}

	public async Task<string> UploadAsync(IFormFile file, string folderName)
	{
		if (file == null || file.Length == 0)
			throw new ArgumentException("Geçersiz dosya.");

		// Tarihe göre klasör oluşturmak için: Expenses/2025/04/27/
		var today = DateTime.UtcNow;
		var datePath = Path.Combine(today.Year.ToString(), today.Month.ToString("D2"), today.Day.ToString("D2"));
		var directoryPath = Path.Combine(_rootPath, folderName, datePath);

		if (!Directory.Exists(directoryPath))
		{
			Directory.CreateDirectory(directoryPath);
		}

		// Dosya adı: Orijinal isim + _ + Guid
		var originalFileName = Path.GetFileNameWithoutExtension(file.FileName);
		var extension = Path.GetExtension(file.FileName);
		var uniqueFileName = $"{originalFileName}_{Guid.NewGuid()}{extension}";
		var filePath = Path.Combine(directoryPath, uniqueFileName);

		using (var stream = new FileStream(filePath, FileMode.Create))
		{
			await file.CopyToAsync(stream);
		}

		// Relative path dönerken: Expenses/2025/04/27/orijinalisim_guid.ext
		var relativePath = Path.Combine(folderName, datePath, uniqueFileName)
			.Replace("\\", "/"); // Windows uyumu

		return relativePath;
	}

	public async Task<byte[]> DownloadAsync(string filePath)
	{
		var fullPath = Path.Combine(_rootPath, filePath.Replace("/", Path.DirectorySeparatorChar.ToString()));

		if (!System.IO.File.Exists(fullPath))
			throw new FileNotFoundException("Dosya bulunamadı.", filePath);

		return await System.IO.File.ReadAllBytesAsync(fullPath);
	}

	public async Task DeleteAsync(string filePath)
	{
		var fullPath = Path.Combine(_rootPath, filePath.Replace("/", Path.DirectorySeparatorChar.ToString()));

		if (System.IO.File.Exists(fullPath))
		{
			await Task.Run(() => System.IO.File.Delete(fullPath));
		}
	}
}
