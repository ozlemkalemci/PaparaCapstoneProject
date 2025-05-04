using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.IdentityModel.Tokens.Jwt;
using Papara.Wasm.Shared.Models.Auth;
using Papara.Wasm.Services;

public class RefreshTokenHandler : DelegatingHandler
{
	private readonly ILocalStorageService _localStorage;
	private readonly HttpClient _httpClient;
	public RefreshTokenHandler(ILocalStorageService localStorage, ConfigurationModel config)
	{
		_localStorage = localStorage;
		_httpClient = new HttpClient { BaseAddress = new Uri(config.ApiUrl) };
	}


	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		Console.WriteLine("🚀 RefreshTokenHandler çalıştı");

		var token = await _localStorage.GetItemAsync<string>("access_token");
		Console.WriteLine($"🔐 Token çekildi: {(token is null ? "YOK" : "VAR")}");

		if (!string.IsNullOrWhiteSpace(token) && IsTokenExpired(token))
		{
			var refreshToken = await _localStorage.GetItemAsync<string>("refresh_token");
			Console.WriteLine($"🔁 RefreshToken çekildi: {(refreshToken is null ? "YOK" : "VAR")}");

			if (!string.IsNullOrWhiteSpace(refreshToken))
			{
				Console.WriteLine("♻ Refresh işlemi başlatılıyor...");
				//var response = await base.SendAsync(new HttpRequestMessage(HttpMethod.Post, "auth/refresh-token")
				//{
				//	Content = JsonContent.Create(new { refreshToken })
				//}, cancellationToken);

				var requestModel = new RefreshTokenRequest { RefreshToken = refreshToken };
				var response = await _httpClient.PostAsJsonAsync("auth/refresh-token", requestModel);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadFromJsonAsync<RefreshResponse>();

					await _localStorage.SetItemAsync("access_token", result.AccessToken);
					await _localStorage.SetItemAsync("refresh_token", result.RefreshToken);

					Console.WriteLine("✅ Refresh işlemi başarılı");
				}
				else
				{
					Console.WriteLine("❌ Refresh token isteği başarısız");
				}
			}
		}

		var finalToken = await _localStorage.GetItemAsync<string>("access_token");
		if (!string.IsNullOrWhiteSpace(finalToken))
		{
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", finalToken);
		}

		return await base.SendAsync(request, cancellationToken);
	}


	private bool IsTokenExpired(string token)
	{
		var handler = new JwtSecurityTokenHandler();
		var jwt = handler.ReadJwtToken(token);
		var exp = jwt.ValidTo;
		bool expStation = exp < DateTimeOffset.UtcNow;

		return expStation;
	}



}
