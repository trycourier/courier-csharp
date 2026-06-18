using System.Net.Http;

namespace TryCourier.Exceptions;

public class CourierUnprocessableEntityException : Courier4xxException
{
    public CourierUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
