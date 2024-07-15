using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

public class SendClient
{
    private RawClient _client;

    public SendClient(RawClient client)
    {
        _client = client;
    }
}
