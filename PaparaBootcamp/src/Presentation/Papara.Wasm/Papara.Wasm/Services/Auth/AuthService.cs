using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace Papara.Wasm.Services.Auth;

public class AuthService : IAuthService
{
	private readonly HttpClient _httpClient;
	private readonly ILocalStorageService _localStorage;
	private readonly AuthenticationStateProvider _authStateProvider;

	private const string TOKEN_KEY = "access_token";

	public AuthService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
	{
		_httpClient = httpClient;
		_localStorage = localStorage;
		_authStateProvider = authStateProvider;
	}

	public async Task<bool> LoginAsync(string userName, string password)
	{
		var response = await _httpClient.PostAsJsonAsync("auth/login", new { userName, password });

		if (!response.IsSuccessStatusCode)
			return false;

		var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

		if (result is null || string.IsNullOrWhiteSpace(result.AccessToken))
			return false;

		await _localStorage.SetItemAsync(TOKEN_KEY, result.AccessToken);
		await _localStorage.SetItemAsync("refresh_token", result.RefreshToken);
		if (_authStateProvider is CustomAuthStateProvider customProvider)
		{
			await customProvider.NotifyUserAuthentication(result.AccessToken);
		}

		Console.WriteLine("🎯 Login sonrası token: " + result.AccessToken);

		return true;
	}

	public async Task LogoutAsync()
	{
		try
		{
			await _httpClient.PostAsync("auth/logout", null);

			await _localStorage.RemoveItemAsync(TOKEN_KEY);

			if (_authStateProvider is CustomAuthStateProvider customProvider)
			{
				customProvider.NotifyUserLogout();
			}
		}
		catch (Exception ex)
		{

			throw ex;
		}

	}

	private class LoginResponse
	{
		public string AccessToken { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;
	}
}
