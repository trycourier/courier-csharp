using System.Net.Http;

namespace Courier.Exceptions;

public class Courier5xxException : CourierApiException
{
    public Courier5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
