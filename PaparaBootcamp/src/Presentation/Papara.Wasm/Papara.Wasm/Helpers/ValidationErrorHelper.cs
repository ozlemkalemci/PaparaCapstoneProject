using Blazored.Toast.Services;
using System.Net;
using System.Text.Json;

namespace Papara.Wasm.Helpers;

public static class ValidationErrorHelper
{
	public static async Task ShowErrorsAsync(HttpResponseMessage response, IToastService toast)
	{
		if (response.StatusCode == HttpStatusCode.BadRequest)
		{
			var json = await response.Content.ReadAsStringAsync();

			try
			{
				var errorObject = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
				if (errorObject != null && errorObject.TryGetValue("message", out var message))
				{
					var lines = message.Split("--")
									   .Select(x => x.Trim())
									   .Where(x => !string.IsNullOrWhiteSpace(x))
									   .ToList();

					foreach (var line in lines)
					{
						// Eğer mesaj şu formatta ise: "Request.ExpenseTypeId: Masraf türü seçilmelidir. Severity: Error"
						var parts = line.Split(":", 2);
						if (parts.Length == 2)
						{
							var cleanMessage = parts[1].Trim();
							toast.ShowError(cleanMessage);
						}
						else
						{
							toast.ShowError(line); // fallback
						}
					}

					return;
				}
			}
			catch
			{
				toast.ShowError("Doğrulama hataları çözümlenemedi.");
			}

			toast.ShowError("Geçersiz istek. Lütfen bilgilerinizi kontrol ediniz.");
		}
		else
		{
			toast.ShowError($"Sunucu hatası: {(int)response.StatusCode}");
		}
	}
}
