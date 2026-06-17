using System.Net.Http;

namespace TryCourier.Exceptions;

public class CourierUnauthorizedException : Courier4xxException
{
    public CourierUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
