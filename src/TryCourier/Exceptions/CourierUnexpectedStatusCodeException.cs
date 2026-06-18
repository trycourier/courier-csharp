using System.Net.Http;

namespace TryCourier.Exceptions;

public class CourierUnexpectedStatusCodeException : CourierApiException
{
    public CourierUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
