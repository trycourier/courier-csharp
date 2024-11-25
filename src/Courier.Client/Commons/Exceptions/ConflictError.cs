using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
public class ConflictError(Conflict body) : CourierApiException("ConflictError", 409, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new Conflict Body => body;
}
