using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models.Inbound.InboundTrackEventParamsProperties;

namespace Courier.Tests.Services.Inbound;

public class InboundServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task TrackEvent_Works()
    {
        var response = await this.client.Inbound.TrackEvent(
            new()
            {
                Event = "New Order Placed",
                MessageID = "4c62c457-b329-4bea-9bfc-17bba86c393f",
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "order_id", JsonSerializer.SerializeToElement("bar") },
                    { "total_orders", JsonSerializer.SerializeToElement("bar") },
                    { "last_order_id", JsonSerializer.SerializeToElement("bar") },
                },
                Type = Type.Track,
            }
        );
        response.Validate();
    }
}
