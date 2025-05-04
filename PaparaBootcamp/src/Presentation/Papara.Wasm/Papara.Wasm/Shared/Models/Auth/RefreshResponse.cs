namespace Papara.Wasm.Shared.Models.Auth;

public class RefreshResponse
{
	public string AccessToken { get; set; } = string.Empty;
	public string RefreshToken { get; set; } = string.Empty;
}
