using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Inbound;

namespace Courier.Services.Inbound;

public interface IInboundService
{
    IInboundService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Courier Track Event
    /// </summary>
    Task<InboundTrackEventResponse> TrackEvent(
        InboundTrackEventParams parameters,
        CancellationToken cancellationToken = default
    );
}
