using System.Net.Http;

namespace Courier.Exceptions;

public class CourierBadRequestException : Courier4xxException
{
    public CourierBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
