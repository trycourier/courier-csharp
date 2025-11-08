using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Inbound = Courier.Models.Inbound;

namespace Courier.Services.Inbound;

public interface IInboundService
{
    IInboundService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Courier Track Event
    /// </summary>
    Task<Inbound::InboundTrackEventResponse> TrackEvent(
        Inbound::InboundTrackEventParams parameters,
        CancellationToken cancellationToken = default
    );
}
