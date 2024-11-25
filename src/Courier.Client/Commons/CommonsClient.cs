using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class CommonsClient
{
    private RawClient _client;

    internal CommonsClient(RawClient client)
    {
        _client = client;
    }
}
