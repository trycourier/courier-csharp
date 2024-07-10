using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

public class CommonsClient
{
    private RawClient _client;

    public CommonsClient(RawClient client)
    {
        _client = client;
    }
}
