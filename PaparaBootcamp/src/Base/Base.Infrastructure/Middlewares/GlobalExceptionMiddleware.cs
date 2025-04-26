using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using Base.Application.Common.Exceptions;

namespace Base.Infrastructure.Middlewares;

public class GlobalExceptionMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<GlobalExceptionMiddleware> _logger;

	public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleGlobalExceptionAsync(context, ex, _logger);
		}
	}

	private static async Task HandleGlobalExceptionAsync(HttpContext context, Exception exception, ILogger logger)
	{
		context.Response.ContentType = "application/json";
		var response = context.Response;
		var errorDetails = new { message = "Bilinmeyen bir hata oluştu." };

		switch (exception)
		{
			case SecurityTokenException:
				response.StatusCode = (int)HttpStatusCode.Unauthorized;
				errorDetails = new { message = "Geçersiz veya süresi dolmuş token." };
				break;

			case InvalidCredentialsException:
				response.StatusCode = (int)HttpStatusCode.Unauthorized;
				errorDetails = new { message = exception.Message };
				break;

			case UnauthorizedAccessException:
				response.StatusCode = (int)HttpStatusCode.Unauthorized;
				errorDetails = new { message = "Yetkisiz erişim." };
				break;

			case ForbidException:
				response.StatusCode = (int)HttpStatusCode.Forbidden;
				errorDetails = new { message = exception.Message };
				break;

			case KeyNotFoundException:
				response.StatusCode = (int)HttpStatusCode.NotFound;
				errorDetails = new { message = exception.Message };
				break;

			case InvalidOperationException:
				response.StatusCode = (int)HttpStatusCode.BadRequest;
				errorDetails = new { message = "İş kurallarına aykırı işlem" };
				break;

			default:
				response.StatusCode = (int)HttpStatusCode.InternalServerError;
				errorDetails = new { message = exception.Message };
				break;
		}

		logger.LogError(exception, "Beklenmeyen bir hata oluştu: {Message}", exception.Message);

		var errorJson = JsonSerializer.Serialize(errorDetails);
		await context.Response.WriteAsync(errorJson);
	}
}
