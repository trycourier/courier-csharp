using Courier.Client.Core;

namespace Courier.Client;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class MessageNotFoundError(MessageNotFound body)
    : CourierApiException("MessageNotFoundError", 404, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new MessageNotFound Body => body;
}
