using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class PreferencesClient
{
    private RawClient _client;

    public PreferencesClient(RawClient client)
    {
        _client = client;
    }
}
