using System.Net.Http;

namespace TryCourier.Exceptions;

public class CourierForbiddenException : Courier4xxException
{
    public CourierForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
