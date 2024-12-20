using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class AuditEventsClient
{
    private RawClient _client;

    internal AuditEventsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Fetch the list of audit events
    /// </summary>
    /// <example>
    /// <code>
    /// await client.AuditEvents.ListAsync(new ListAuditEventsRequest());
    /// </code>
    /// </example>
    public async Task<ListAuditEventsResponse> ListAsync(
        ListAuditEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = "/audit-events",
                Query = _query,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ListAuditEventsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Fetch a specific audit event by ID.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.AuditEvents.GetAsync("audit-event-id");
    /// </code>
    /// </example>
    public async Task<AuditEvent> GetAsync(
        string auditEventId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/audit-events/{auditEventId}",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<AuditEvent>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }
}
