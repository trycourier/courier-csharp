using System.Net.Http;
using System.Text.Json;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class AuditEventsClient
{
    private RawClient _client;

    public AuditEventsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Fetch the list of audit events
    /// </summary>
    public async Task<ListAuditEventsResponse> ListAsync(ListAuditEventsRequest request)
    {
        var _query = new Dictionary<string, object>() { };
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "/audit-events",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<ListAuditEventsResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Fetch a specific audit event by ID.
    /// </summary>
    public async Task<AuditEvent> GetAsync(string auditEventId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"/audit-events/{auditEventId}"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<AuditEvent>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
