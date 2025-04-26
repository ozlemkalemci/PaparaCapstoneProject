using Microsoft.AspNetCore.Builder;

namespace Base.Infrastructure.Middlewares;

public static class ExceptionMiddlewareExtensions
{
	public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
	{
		return app.UseMiddleware<GlobalExceptionMiddleware>();
	}
}
