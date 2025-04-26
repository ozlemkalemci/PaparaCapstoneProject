namespace Base.Application.Common.Exceptions;

public class InvalidCredentialsException : Exception
{
	public InvalidCredentialsException()
		: base("Geçersiz kullanıcı adı veya şifre.")
	{
	}
}
