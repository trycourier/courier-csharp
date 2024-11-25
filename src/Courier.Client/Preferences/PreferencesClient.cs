using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class PreferencesClient
{
    private RawClient _client;

    internal PreferencesClient(RawClient client)
    {
        _client = client;
    }
}
