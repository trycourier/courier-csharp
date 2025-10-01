using System.Net.Http;

namespace Courier.Exceptions;

public class CourierForbiddenException : Courier4xxException
{
    public CourierForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
