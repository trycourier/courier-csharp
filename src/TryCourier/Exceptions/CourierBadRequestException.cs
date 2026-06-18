using System.Net.Http;

namespace TryCourier.Exceptions;

public class CourierBadRequestException : Courier4xxException
{
    public CourierBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
