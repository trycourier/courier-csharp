using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class SendClient
{
    private RawClient _client;

    public SendClient(RawClient client)
    {
        _client = client;
    }
}
