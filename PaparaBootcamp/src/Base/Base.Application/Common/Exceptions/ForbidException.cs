namespace Base.Application.Common.Exceptions
{
	public class ForbidException : Exception
	{
		public ForbidException(string message = "Bu işleme erişim izniniz bulunmamaktadır.")
			: base(message)
		{
		}
	}
}
