using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

public class CommonsClient
{
    private RawClient _client;

    public CommonsClient(RawClient client)
    {
        _client = client;
    }
}
