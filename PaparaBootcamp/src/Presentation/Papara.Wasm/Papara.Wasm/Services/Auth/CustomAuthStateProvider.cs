using Blazored.LocalStorage;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Papara.Wasm.Services.Auth;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
	private readonly ILocalStorageService _localStorage;
	private static readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
	private const string TOKEN_KEY = "access_token";

	public CustomAuthStateProvider(ILocalStorageService localStorage)
	{
		_localStorage = localStorage;
	}

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		//var token = await _localStorage.GetItemAsStringAsync(TOKEN_KEY);
		var token = await _localStorage.GetItemAsync<string>("access_token");

		if (string.IsNullOrWhiteSpace(token) || !IsTokenValid(token))
			return new AuthenticationState(_anonymous);

		var user = ParseClaimsFromToken(token);
		return new AuthenticationState(user);
	}

	public Task NotifyUserAuthentication(string token)
	{
		var user = ParseClaimsFromToken(token);
		NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
		return Task.CompletedTask;
	}

	public void NotifyUserLogout()
	{
		NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
	}

	private ClaimsPrincipal ParseClaimsFromToken(string token)
	{
		var handler = new JwtSecurityTokenHandler();
		var jwtToken = handler.ReadJwtToken(token);
		var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
		return new ClaimsPrincipal(identity);
	}

	private bool IsTokenValid(string token)
	{
		try
		{
			var handler = new JwtSecurityTokenHandler();
			return handler.CanReadToken(token) && token.Count(c => c == '.') == 2;
		}
		catch
		{
			return false;
		}
	}
}
