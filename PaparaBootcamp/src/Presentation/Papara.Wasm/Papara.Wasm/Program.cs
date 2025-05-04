using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Papara.Wasm;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Papara.Wasm.Services.Auth;
using Papara.Wasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Config (appsettings.json içinden)
var apiUrl = builder.Configuration["ApiUrl"] ?? throw new Exception("ApiUrl not found in configuration");
var fileBaseUrl = builder.Configuration["FileBaseUrl"] ?? throw new Exception("FileBaseUrl not found in configuration");

builder.Services.AddSingleton(new ConfigurationModel
{
	ApiUrl = apiUrl,
	FileBaseUrl = fileBaseUrl
});
// HttpClient (Papara.WebApi'ye istek atmak için)
builder.Services.AddScoped<AuthHeaderHandler>();
builder.Services.AddScoped<RefreshTokenHandler>();

builder.Services.AddScoped(sp =>
{
	var baseAddress = new Uri(apiUrl);

	// LocalStorage bağımlılığı gerekli
	var localStorage = sp.GetRequiredService<ILocalStorageService>();

	// Handler'lar çözülüyor
	var refreshHandler = sp.GetRequiredService<RefreshTokenHandler>();
	var authHandler = sp.GetRequiredService<AuthHeaderHandler>();

	// Handler zinciri oluşturuluyor: Refresh → Auth → HttpClientHandler
	authHandler.InnerHandler = new HttpClientHandler();
	refreshHandler.InnerHandler = authHandler;

	// Zincirin başına RefreshTokenHandler veriliyor
	return new HttpClient(refreshHandler)
	{
		BaseAddress = baseAddress
	};
});


// Blazored Toast
builder.Services.AddBlazoredToast();

// Blazored LocalStorage (JWT ve kullanıcı verisi için)
builder.Services.AddBlazoredLocalStorage(config =>
{
	config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
	config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
	config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
	config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
	config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
	config.JsonSerializerOptions.WriteIndented = false;
});

// Auth servisleri
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

//await builder.Build().RunAsync();

var host = builder.Build();

var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
await localStorage.ContainKeyAsync("access_token"); 

await host.RunAsync();

