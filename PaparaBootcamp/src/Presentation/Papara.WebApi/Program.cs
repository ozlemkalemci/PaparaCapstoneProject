using Base.Application;
using Base.Application.Interfaces;
using Base.Application.Settings;
using Base.Infrastructure;
using Base.Infrastructure.Middlewares;
using Base.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Papara.Application;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// JWT Settings Configuration
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

// CORS Policy
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyOrigin()
			  .AllowAnyHeader()
			  .AllowAnyMethod();
	});
});

// JWT Authentication Middleware
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.RequireHttpsMetadata = false;
		options.SaveToken = false;
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidIssuer = jwtSettings.Issuer,
			ValidateAudience = true,
			ValidAudience = jwtSettings.Audience,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
			ClockSkew = TimeSpan.Zero
		};
		
		// Redis Blacklist ve hata kontrolü
		options.Events = new JwtBearerEvents
		{
			OnAuthenticationFailed = context =>
			{
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				context.Response.ContentType = "application/json";

				var result = JsonSerializer.Serialize(new { message = "Geçersiz veya süresi dolmuþ token." });
				return context.Response.WriteAsync(result);
			},
			OnTokenValidated = async context =>
			{
				var jti = context.Principal.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;

				var redisHelper = context.HttpContext.RequestServices.GetRequiredService<IRedisService>();

				if (!string.IsNullOrEmpty(jti) && await redisHelper.IsBlacklistedAsync(jti))
				{
					context.Fail("Token is blacklisted.");
				}
			}
		};
	});

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger Configuration
builder.Services.AddSwaggerGen(setup =>
{
	setup.SwaggerDoc("v1", new OpenApiInfo { Title = "Papara.WebApi", Version = "v1" });

	setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		Scheme = "bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "JWT Token giriniz. Örn: Bearer <token>"
	});

	setup.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new List<string>()
		}
	});
});

// Katman servis kayýtlarý
builder.Services.AddBaseApplicationServices();
builder.Services.AddBasePersistence(builder.Configuration);
builder.Services.AddBaseInfrastructure();
builder.Services.AddPaparaApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseGlobalExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();