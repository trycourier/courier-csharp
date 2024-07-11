using System.Net.Http;
using System.Text.Json;
using Courier.Net;
using Courier.Net.Core;
using Courier.Net.Users;

#nullable enable

namespace Courier.Net;

public partial class Courier
{
    private RawClient _client;

    public Courier(string? authorizationToken = null, ClientOptions? clientOptions = null)
    {
        authorizationToken ??= GetFromEnvironmentOrThrow(
            "COURIER_AUTH_TOKEN",
            "Please pass in authorizationToken or set the environment variable COURIER_AUTH_TOKEN."
        );
        _client = new RawClient(
            new Dictionary<string, string>()
            {
                { "Authorization", $"Bearer {authorizationToken}" },
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Courier.Net" },
                { "X-Fern-SDK-Version", "0.0.5" },
            },
            clientOptions ?? new ClientOptions()
        );
        Audiences = new AudiencesClient(_client);
        AuditEvents = new AuditEventsClient(_client);
        AuthTokens = new AuthTokensClient(_client);
        Automations = new AutomationsClient(_client);
        Brands = new BrandsClient(_client);
        Commons = new CommonsClient(_client);
        Bulk = new BulkClient(_client);
        Inbound = new InboundClient(_client);
        Lists = new ListsClient(_client);
        Messages = new MessagesClient(_client);
        Notifications = new NotificationsClient(_client);
        Preferences = new PreferencesClient(_client);
        Profiles = new ProfilesClient(_client);
        Send = new SendClient(_client);
        Templates = new TemplatesClient(_client);
        Tenants = new TenantsClient(_client);
        Translations = new TranslationsClient(_client);
        Users = new UsersClient(_client);
    }

    public AudiencesClient Audiences { get; init; }

    public AuditEventsClient AuditEvents { get; init; }

    public AuthTokensClient AuthTokens { get; init; }

    public AutomationsClient Automations { get; init; }

    public BrandsClient Brands { get; init; }

    public CommonsClient Commons { get; init; }

    public BulkClient Bulk { get; init; }

    public InboundClient Inbound { get; init; }

    public ListsClient Lists { get; init; }

    public MessagesClient Messages { get; init; }

    public NotificationsClient Notifications { get; init; }

    public PreferencesClient Preferences { get; init; }

    public ProfilesClient Profiles { get; init; }

    public SendClient Send { get; init; }

    public TemplatesClient Templates { get; init; }

    public TenantsClient Tenants { get; init; }

    public TranslationsClient Translations { get; init; }

    public UsersClient Users { get; init; }

    /// <summary>
    /// Use the send API to send a message to one or more recipients.
    /// </summary>
    public async Task<SendMessageResponse> SendAsync(SendMessageRequest request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "/send",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<SendMessageResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    private static string GetFromEnvironmentOrThrow(string env, string message)
    {
        return Environment.GetEnvironmentVariable(env) ?? throw new Exception(message);
    }
}
