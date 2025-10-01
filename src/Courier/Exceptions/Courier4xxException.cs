using System.Net.Http;

namespace Courier.Exceptions;

public class Courier4xxException : CourierApiException
{
    public Courier4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
