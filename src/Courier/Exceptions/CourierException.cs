using System;
using System.Net.Http;

namespace Courier.Exceptions;

public class CourierException : Exception
{
    public CourierException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected CourierException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
