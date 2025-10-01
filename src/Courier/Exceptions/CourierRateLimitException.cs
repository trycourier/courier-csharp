using System.Net.Http;

namespace Courier.Exceptions;

public class CourierRateLimitException : Courier4xxException
{
    public CourierRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
