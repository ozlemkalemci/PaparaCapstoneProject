using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.IdentityModel.Tokens.Jwt;

public class RefreshTokenHandler : DelegatingHandler
{
	private readonly ILocalStorageService _localStorage;

	public RefreshTokenHandler(ILocalStorageService localStorage)
	{
		_localStorage = localStorage;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var token = await _localStorage.GetItemAsync<string>("access_token");

		if (!string.IsNullOrWhiteSpace(token) && IsTokenExpired(token))
		{
			var refreshToken = await _localStorage.GetItemAsync<string>("refresh_token");

			if (!string.IsNullOrWhiteSpace(refreshToken))
			{
				var response = await base.SendAsync(new HttpRequestMessage(HttpMethod.Post, "auth/refresh-token")
				{
					Content = JsonContent.Create(new { refreshToken })
				}, cancellationToken);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadFromJsonAsync<RefreshResponse>();

					await _localStorage.SetItemAsync("access_token", result.AccessToken);
					await _localStorage.SetItemAsync("refresh_token", result.RefreshToken);
				}
			}
		}

		// Refresh sonrası yeni token varsa onu ekle
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

		return exp < DateTime.UtcNow;
	}

	private class RefreshResponse
	{
		public string AccessToken { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;
	}
}
