using System;
using System.Net.Http;

namespace Courier.Exceptions;

public class CourierIOException : CourierException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public CourierIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
