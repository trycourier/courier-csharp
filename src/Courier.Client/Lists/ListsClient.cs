using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;

namespace Courier.Client;

public partial class ListsClient
{
    private RawClient _client;

    internal ListsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns all of the lists, with the ability to filter based on a pattern.
    /// </summary>
    /// <example><code>
    /// await client.Lists.ListAsync(new GetAllListsRequest());
    /// </code></example>
    public async Task<ListGetAllResponse> ListAsync(
        GetAllListsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Pattern != null)
        {
            _query["pattern"] = request.Pattern;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "/lists",
                    Query = _query,
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
                return JsonUtils.Deserialize<ListGetAllResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<BadRequest>(responseBody));
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
    }

    /// <summary>
    /// Returns a list based on the list ID provided.
    /// </summary>
    /// <example><code>
    /// await client.Lists.GetAsync("list_id");
    /// </code></example>
    public async Task<List> GetAsync(
        string listId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format("/lists/{0}", ValueConvert.ToPathParameterString(listId)),
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
                return JsonUtils.Deserialize<List>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<NotFound>(responseBody));
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
    }

    /// <summary>
    /// Create or replace an existing list with the supplied values.
    /// </summary>
    /// <example><code>
    /// await client.Lists.UpdateAsync("list_id", new ListPutParams { Name = "name", Preferences = null });
    /// </code></example>
    public async Task UpdateAsync(
        string listId,
        ListPutParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format("/lists/{0}", ValueConvert.ToPathParameterString(listId)),
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
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

    /// <summary>
    /// Delete a list by list ID.
    /// </summary>
    /// <example><code>
    /// await client.Lists.DeleteAsync("list_id");
    /// </code></example>
    public async Task DeleteAsync(
        string listId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format("/lists/{0}", ValueConvert.ToPathParameterString(listId)),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
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

    /// <summary>
    /// Restore a previously deleted list.
    /// </summary>
    /// <example><code>
    /// await client.Lists.RestoreAsync("list_id", new RestoreListRequest());
    /// </code></example>
    public async Task RestoreAsync(
        string listId,
        RestoreListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "/lists/{0}/restore",
                        ValueConvert.ToPathParameterString(listId)
                    ),
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
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

    /// <summary>
    /// Get the list's subscriptions.
    /// </summary>
    /// <example><code>
    /// await client.Lists.GetSubscribersAsync("list_id", new GetSubscriptionForListRequest());
    /// </code></example>
    public async Task<ListGetSubscriptionsResponse> GetSubscribersAsync(
        string listId,
        GetSubscriptionForListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "/lists/{0}/subscriptions",
                        ValueConvert.ToPathParameterString(listId)
                    ),
                    Query = _query,
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
                return JsonUtils.Deserialize<ListGetSubscriptionsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<NotFound>(responseBody));
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
    }

    /// <summary>
    /// Subscribes the users to the list, overwriting existing subscriptions. If the list does not exist, it will be automatically created.
    /// </summary>
    /// <example><code>
    /// await client.Lists.UpdateSubscribersAsync(
    ///     "list_id",
    ///     new SubscribeUsersToListRequest
    ///     {
    ///         Recipients = new List&lt;PutSubscriptionsRecipient&gt;()
    ///         {
    ///             new PutSubscriptionsRecipient { RecipientId = "recipientId", Preferences = null },
    ///             new PutSubscriptionsRecipient { RecipientId = "recipientId", Preferences = null },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task UpdateSubscribersAsync(
        string listId,
        SubscribeUsersToListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "/lists/{0}/subscriptions",
                        ValueConvert.ToPathParameterString(listId)
                    ),
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<BadRequest>(responseBody));
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
    }

    /// <summary>
    /// Subscribes additional users to the list, without modifying existing subscriptions. If the list does not exist, it will be automatically created.
    /// </summary>
    /// <example><code>
    /// await client.Lists.AddSubscribersAsync(
    ///     "list_id",
    ///     new AddSubscribersToList
    ///     {
    ///         Recipients = new List&lt;PutSubscriptionsRecipient&gt;()
    ///         {
    ///             new PutSubscriptionsRecipient { RecipientId = "recipientId", Preferences = null },
    ///             new PutSubscriptionsRecipient { RecipientId = "recipientId", Preferences = null },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task AddSubscribersAsync(
        string listId,
        AddSubscribersToList request,
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
                    Path = string.Format(
                        "/lists/{0}/subscriptions",
                        ValueConvert.ToPathParameterString(listId)
                    ),
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<BadRequest>(responseBody));
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
    }

    /// <summary>
    /// Subscribe a user to an existing list (note: if the List does not exist, it will be automatically created).
    /// </summary>
    /// <example><code>
    /// await client.Lists.SubscribeAsync(
    ///     "list_id",
    ///     "user_id",
    ///     new SubscribeUserToListRequest { Preferences = null }
    /// );
    /// </code></example>
    public async Task SubscribeAsync(
        string listId,
        string userId,
        SubscribeUserToListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "/lists/{0}/subscriptions/{1}",
                        ValueConvert.ToPathParameterString(listId),
                        ValueConvert.ToPathParameterString(userId)
                    ),
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
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

    /// <summary>
    /// Delete a subscription to a list by list ID and user ID.
    /// </summary>
    /// <example><code>
    /// await client.Lists.UnsubscribeAsync("list_id", "user_id");
    /// </code></example>
    public async Task UnsubscribeAsync(
        string listId,
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "/lists/{0}/subscriptions/{1}",
                        ValueConvert.ToPathParameterString(listId),
                        ValueConvert.ToPathParameterString(userId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<NotFound>(responseBody));
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
    }
}
