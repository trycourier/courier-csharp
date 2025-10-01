using System.Net.Http;

namespace Courier.Exceptions;

public class CourierUnexpectedStatusCodeException : CourierApiException
{
    public CourierUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
