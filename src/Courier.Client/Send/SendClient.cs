using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class SendClient
{
    private RawClient _client;

    internal SendClient(RawClient client)
    {
        _client = client;
    }
}
