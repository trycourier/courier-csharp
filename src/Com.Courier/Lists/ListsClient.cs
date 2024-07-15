using System.Net.Http;
using System.Text.Json;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

public class ListsClient
{
    private RawClient _client;

    public ListsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns all of the lists, with the ability to filter based on a pattern.
    /// </summary>
    public async Task<ListGetAllResponse> ListAsync(GetAllListsRequest request)
    {
        var _query = new Dictionary<string, object>() { };
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Pattern != null)
        {
            _query["pattern"] = request.Pattern;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "/lists",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<ListGetAllResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Returns a list based on the list ID provided.
    /// </summary>
    public async Task<List> GetAsync(string listId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Get, Path = $"/lists/{listId}" }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<List>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Create or replace an existing list with the supplied values.
    /// </summary>
    public async Task<List> UpdateAsync(string listId, ListPutParams request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/lists/{listId}",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<List>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Delete a list by list ID.
    /// </summary>
    public async Task DeleteAsync(string listId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Delete, Path = $"/lists/{listId}" }
        );
    }

    /// <summary>
    /// Restore a previously deleted list.
    /// </summary>
    public async Task RestoreAsync(string listId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/lists/{listId}/restore"
            }
        );
    }

    /// <summary>
    /// Get the list's subscriptions.
    /// </summary>
    public async Task<ListGetSubscriptionsResponse> GetSubscribersAsync(
        string listId,
        GetSubscriptionForListRequest request
    )
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
                Path = $"/lists/{listId}/subscriptions",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<ListGetSubscriptionsResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Subscribes the users to the list, overwriting existing subscriptions. If the list does not exist, it will be automatically created.
    /// </summary>
    public async Task UpdateSubscribersAsync(string listId, SubscribeUsersToListRequest request)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/lists/{listId}/subscriptions",
                Body = request
            }
        );
    }

    /// <summary>
    /// Subscribes additional users to the list, without modifying existing subscriptions. If the list does not exist, it will be automatically created.
    /// </summary>
    public async Task AddSubscribersAsync(string listId, AddSubscribersToList request)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"/lists/{listId}/subscriptions",
                Body = request
            }
        );
    }

    /// <summary>
    /// Subscribe a user to an existing list (note: if the List does not exist, it will be automatically created).
    /// </summary>
    public async Task SubscribeAsync(
        string listId,
        string userId,
        SubscribeUserToListRequest request
    )
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/lists/{listId}/subscriptions/{userId}",
                Body = request
            }
        );
    }

    /// <summary>
    /// Delete a subscription to a list by list ID and user ID.
    /// </summary>
    public async Task UnsubscribeAsync(string listId, string userId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"/lists/{listId}/subscriptions/{userId}"
            }
        );
    }
}
