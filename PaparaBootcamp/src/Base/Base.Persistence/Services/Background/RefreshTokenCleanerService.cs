using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Base.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Base.Persistence.Services.Background;

public class RefreshTokenCleanerService : BackgroundService
{
	private readonly IServiceProvider _serviceProvider;
	private readonly ILogger<RefreshTokenCleanerService> _logger;

	public RefreshTokenCleanerService(IServiceProvider serviceProvider, ILogger<RefreshTokenCleanerService> logger)
	{
		_serviceProvider = serviceProvider;
		_logger = logger;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		_logger.LogInformation("RefreshTokenCleanerService başlatıldı.");

		while (!stoppingToken.IsCancellationRequested)
		{
			using var scope = _serviceProvider.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

			try
			{
				var expired = await dbContext.RefreshTokens
					.Where(x => x.Expiration < DateTime.UtcNow)
					.ToListAsync(stoppingToken);

				if (expired.Any())
				{
					dbContext.RefreshTokens.RemoveRange(expired);
					await dbContext.SaveChangesAsync(stoppingToken);
					_logger.LogInformation($"{expired.Count} adet refresh token silindi.");
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Refresh token temizleme sırasında bir hata oluştu.");
			}

			await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
		}
	}
}
