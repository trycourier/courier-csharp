using System.Net.Http;

namespace Courier.Exceptions;

public class CourierUnprocessableEntityException : Courier4xxException
{
    public CourierUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
