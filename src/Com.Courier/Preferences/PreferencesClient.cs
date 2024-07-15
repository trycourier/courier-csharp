using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

public class PreferencesClient
{
    private RawClient _client;

    public PreferencesClient(RawClient client)
    {
        _client = client;
    }
}
