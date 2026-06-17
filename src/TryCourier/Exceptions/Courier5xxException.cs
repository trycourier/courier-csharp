using System.Net.Http;

namespace TryCourier.Exceptions;

public class Courier5xxException : CourierApiException
{
    public Courier5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
