using Com.Courier.Core;
using Com.Courier.Users;

#nullable enable

namespace Com.Courier.Users;

public class UsersClient
{
    private RawClient _client;

    public UsersClient(RawClient client)
    {
        _client = client;
        Preferences = new PreferencesClient(_client);
        Tenants = new TenantsClient(_client);
        Tokens = new TokensClient(_client);
    }

    public PreferencesClient Preferences { get; }

    public TenantsClient Tenants { get; }

    public TokensClient Tokens { get; }
}
