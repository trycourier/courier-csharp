using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public partial class UsersClient
{
    private RawClient _client;

    internal UsersClient(RawClient client)
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
