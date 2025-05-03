namespace Papara.Wasm.Services.Auth;
public interface IAuthService
{
	Task<bool> LoginAsync(string userName, string password);
	Task LogoutAsync();
}