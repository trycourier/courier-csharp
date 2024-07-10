using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

public class SendClient
{
    private RawClient _client;

    public SendClient(RawClient client)
    {
        _client = client;
    }
}
