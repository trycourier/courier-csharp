using System.Threading.Tasks;
using Courier.Models.Inbound;

namespace Courier.Services.Inbound;

public interface IInboundService
{
    /// <summary>
    /// Courier Track Event
    /// </summary>
    Task<InboundTrackEventResponse> TrackEvent(InboundTrackEventParams parameters);
}
