using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

public class PreferencesClient
{
    private RawClient _client;

    public PreferencesClient(RawClient client)
    {
        _client = client;
    }
}
