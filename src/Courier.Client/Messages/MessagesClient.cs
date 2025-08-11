using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class MessagesClient
{
    private RawClient _client;

    internal MessagesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Fetch the statuses of messages you've previously sent.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Messages.ListAsync(new ListMessagesRequest());
    /// </code>
    /// </example>
    public async Task<ListMessagesResponse> ListAsync(
        ListMessagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["provider"] = request.Provider;
        _query["status"] = request.Status;
        _query["tag"] = request.Tag;
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
        if (request.Recipient != null)
        {
            _query["recipient"] = request.Recipient;
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
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = "messages",
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
                return JsonUtils.Deserialize<ListMessagesResponse>(responseBody)!;
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
    /// Fetch the status of a message you've previously sent.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Messages.GetAsync("message_id");
    /// </code>
    /// </example>
    public async Task<MessageDetailsExtended> GetAsync(
        string messageId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"messages/{messageId}",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<MessageDetailsExtended>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<BadRequest>(responseBody));
                case 404:
                    throw new MessageNotFoundError(
                        JsonUtils.Deserialize<MessageNotFound>(responseBody)
                    );
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Cancel a message that is currently in the process of being delivered. A well-formatted API call to the cancel message API will return either `200` status code for a successful cancellation or `409` status code for an unsuccessful cancellation. Both cases will include the actual message record in the response body (see details below).
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Messages.CancelAsync("message_id");
    /// </code>
    /// </example>
    public async Task<MessageDetails> CancelAsync(
        string messageId,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"messages/{messageId}/cancel",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<MessageDetails>(responseBody)!;
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
    /// Fetch the array of events of a message you've previously sent.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Messages.GetHistoryAsync("message_id", new GetMessageHistoryRequest());
    /// </code>
    /// </example>
    public async Task<MessageHistoryResponse> GetHistoryAsync(
        string messageId,
        GetMessageHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Type != null)
        {
            _query["type"] = request.Type;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"messages/{messageId}/history",
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
                return JsonUtils.Deserialize<MessageHistoryResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<BadRequest>(responseBody));
                case 404:
                    throw new MessageNotFoundError(
                        JsonUtils.Deserialize<MessageNotFound>(responseBody)
                    );
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <example>
    /// <code>
    /// await client.Messages.GetContentAsync("message_id");
    /// </code>
    /// </example>
    public async Task<RenderOutputResponse> GetContentAsync(
        string messageId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"messages/{messageId}/output",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<RenderOutputResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<BadRequest>(responseBody));
                case 404:
                    throw new MessageNotFoundError(
                        JsonUtils.Deserialize<MessageNotFound>(responseBody)
                    );
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <example>
    /// <code>
    /// await client.Messages.ArchiveAsync("request_id");
    /// </code>
    /// </example>
    public async Task ArchiveAsync(
        string requestId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"requests/{requestId}/archive",
                Options = options,
            },
            cancellationToken
        );
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }
}
