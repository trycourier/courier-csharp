using System;

namespace TryCourier.Exceptions;

public class CourierInvalidDataException : CourierException
{
    public CourierInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
