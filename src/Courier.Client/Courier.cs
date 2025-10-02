using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;
using Courier.Client.Users;

namespace Courier.Client;

public partial class Courier
{
    private readonly RawClient _client;

    public Courier(string? authorizationToken = null, ClientOptions? clientOptions = null)
    {
        authorizationToken ??= GetFromEnvironmentOrThrow(
            "COURIER_AUTH_TOKEN",
            "Please pass in authorizationToken or set the environment variable COURIER_AUTH_TOKEN."
        );
        var defaultHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "Authorization", $"Bearer {authorizationToken}" },
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Courier.Client" },
                { "X-Fern-SDK-Version", Version.Current },
                { "User-Agent", "Courier.Client/0.5.0" },
            }
        );
        clientOptions ??= new ClientOptions();
        foreach (var header in defaultHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        _client = new RawClient(clientOptions);
        Audiences = new AudiencesClient(_client);
        AuditEvents = new AuditEventsClient(_client);
        AuthTokens = new AuthTokensClient(_client);
        Automations = new AutomationsClient(_client);
        Brands = new BrandsClient(_client);
        Bulk = new BulkClient(_client);
        Inbound = new InboundClient(_client);
        Lists = new ListsClient(_client);
        Messages = new MessagesClient(_client);
        Notifications = new NotificationsClient(_client);
        Profiles = new ProfilesClient(_client);
        Templates = new TemplatesClient(_client);
        Tenants = new TenantsClient(_client);
        Translations = new TranslationsClient(_client);
        Users = new UsersClient(_client);
    }

    public AudiencesClient Audiences { get; }

    public AuditEventsClient AuditEvents { get; }

    public AuthTokensClient AuthTokens { get; }

    public AutomationsClient Automations { get; }

    public BrandsClient Brands { get; }

    public BulkClient Bulk { get; }

    public InboundClient Inbound { get; }

    public ListsClient Lists { get; }

    public MessagesClient Messages { get; }

    public NotificationsClient Notifications { get; }

    public ProfilesClient Profiles { get; }

    public TemplatesClient Templates { get; }

    public TenantsClient Tenants { get; }

    public TranslationsClient Translations { get; }

    public UsersClient Users { get; }

    private static string GetFromEnvironmentOrThrow(string env, string message)
    {
        return Environment.GetEnvironmentVariable(env) ?? throw new Exception(message);
    }

    /// <summary>
    /// Use the send API to send a message to one or more recipients.
    /// </summary>
    /// <example><code>
    /// await client.SendAsync(
    ///     new SendMessageRequest
    ///     {
    ///         Message = new ContentMessage
    ///         {
    ///             To = new UserRecipient { Email = "email@example.com" },
    ///             Content = new ElementalContentSugar
    ///             {
    ///                 Title = "Welcome!",
    ///                 Body = "Thanks for signing up, {{name}}",
    ///             },
    ///             Data = new Dictionary&lt;string, object&gt;() { { "name", "Peter Parker" } },
    ///             Routing = new Routing
    ///             {
    ///                 Method = RoutingMethod.Single,
    ///                 Channels = new List&lt;OneOf&lt;string, MessageRouting&gt;&gt;() { "email" },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<SendMessageResponse> SendAsync(
        SendMessageRequest request,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/send",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<SendMessageResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new CourierApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
