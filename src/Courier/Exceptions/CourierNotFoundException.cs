using System.Net.Http;

namespace Courier.Exceptions;

public class CourierNotFoundException : Courier4xxException
{
    public CourierNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
