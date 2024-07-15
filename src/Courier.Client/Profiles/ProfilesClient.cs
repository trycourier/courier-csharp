using System.Net.Http;
using System.Text.Json;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class ProfilesClient
{
    private RawClient _client;

    public ProfilesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns the specified user profile.
    /// </summary>
    public async Task<ProfileGetResponse> GetAsync(string userId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Get, Path = $"/profiles/{userId}" }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<ProfileGetResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Merge the supplied values with an existing profile or create a new profile if one doesn't already exist.
    /// </summary>
    public async Task<MergeProfileResponse> CreateAsync(string userId, MergeProfileRequest request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"/profiles/{userId}",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<MergeProfileResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// When using `PUT`, be sure to include all the key-value pairs required by the recipient's profile.
    /// Any key-value pairs that exist in the profile but fail to be included in the `PUT` request will be
    /// removed from the profile. Remember, a `PUT` update is a full replacement of the data. For partial updates,
    /// use the [Patch](https://www.courier.com/docs/reference/profiles/patch/) request.
    /// </summary>
    public async Task<ReplaceProfileResponse> ReplaceAsync(
        string userId,
        ReplaceProfileRequest request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/profiles/{userId}",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<ReplaceProfileResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Deletes the specified user profile.
    /// </summary>
    public async Task DeleteAsync(string userId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"/profiles/{userId}"
            }
        );
    }

    /// <summary>
    /// Returns the subscribed lists for a specified user.
    /// </summary>
    public async Task<GetListSubscriptionsResponse> GetListSubscriptionsAsync(
        string userId,
        GetListSubscriptionsRequest request
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
                Path = $"/profiles/{userId}/lists",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<GetListSubscriptionsResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Subscribes the given user to one or more lists. If the list does not exist, it will be created.
    /// </summary>
    public async Task<SubscribeToListsResponse> SubscribeToListsAsync(
        string userId,
        SubscribeToListsRequest request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"/profiles/{userId}/lists",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<SubscribeToListsResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Removes all list subscriptions for given user.
    /// </summary>
    public async Task<DeleteListSubscriptionResponse> DeleteListSubscriptionAsync(string userId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"/profiles/{userId}/lists"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<DeleteListSubscriptionResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
