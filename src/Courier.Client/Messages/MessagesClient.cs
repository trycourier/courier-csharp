using System.Net.Http;
using System.Text.Json;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class MessagesClient
{
    private RawClient _client;

    public MessagesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Fetch the statuses of messages you've previously sent.
    /// </summary>
    public async Task<ListMessagesResponse> ListAsync(ListMessagesRequest request)
    {
        var _query = new Dictionary<string, object>() { };
        if (request.Archived != null)
        {
            _query["archived"] = request.Archived.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Event != null)
        {
            _query["event"] = request.Event;
        }
        if (request.List != null)
        {
            _query["list"] = request.List;
        }
        if (request.MessageId != null)
        {
            _query["messageId"] = request.MessageId;
        }
        if (request.Notification != null)
        {
            _query["notification"] = request.Notification;
        }
        if (request.Provider != null)
        {
            _query["provider"] = request.Provider;
        }
        if (request.Recipient != null)
        {
            _query["recipient"] = request.Recipient;
        }
        if (request.Status != null)
        {
            _query["status"] = request.Status;
        }
        if (request.Tag != null)
        {
            _query["tag"] = request.Tag;
        }
        if (request.Tags != null)
        {
            _query["tags"] = request.Tags;
        }
        if (request.TenantId != null)
        {
            _query["tenant_id"] = request.TenantId;
        }
        if (request.EnqueuedAfter != null)
        {
            _query["enqueued_after"] = request.EnqueuedAfter;
        }
        if (request.TraceId != null)
        {
            _query["traceId"] = request.TraceId;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "messages",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<ListMessagesResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Fetch the status of a message you've previously sent.
    /// </summary>
    public async Task<MessageDetails> GetAsync(string messageId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Get, Path = $"messages/{messageId}" }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<MessageDetails>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Cancel a message that is currently in the process of being delivered. A well-formatted API call to the cancel message API will return either `200` status code for a successful cancellation or `409` status code for an unsuccessful cancellation. Both cases will include the actual message record in the response body (see details below).
    /// </summary>
    public async Task<MessageDetails> CancelAsync(string messageId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"messages/{messageId}/cancel"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<MessageDetails>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Fetch the array of events of a message you've previously sent.
    /// </summary>
    public async Task<MessageHistoryResponse> GetHistoryAsync(
        string messageId,
        GetMessageHistoryRequest request
    )
    {
        var _query = new Dictionary<string, object>() { };
        if (request.Type != null)
        {
            _query["type"] = request.Type;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"messages/{messageId}/history",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<MessageHistoryResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task<RenderOutputResponse> GetContentAsync(string messageId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"messages/{messageId}/output"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<RenderOutputResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task ArchiveAsync(string requestId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"requests/{requestId}/archive"
            }
        );
    }
}
