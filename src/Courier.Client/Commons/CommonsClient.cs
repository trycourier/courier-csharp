using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class CommonsClient
{
    private RawClient _client;

    public CommonsClient(RawClient client)
    {
        _client = client;
    }
}
