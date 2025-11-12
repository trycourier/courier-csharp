using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Send;

namespace Courier.Services;

public interface ISendService
{
    ISendService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Send a message to one or more recipients.
    /// </summary>
    Task<SendMessageResponse> Message(
        SendMessageParams parameters,
        CancellationToken cancellationToken = default
    );
}
