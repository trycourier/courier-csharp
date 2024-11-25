using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class ProfilesClient
{
    private RawClient _client;

    internal ProfilesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns the specified user profile.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Profiles.GetAsync("user_id");
    /// </code>
    /// </example>
    public async Task<ProfileGetResponse> GetAsync(
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/profiles/{userId}",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ProfileGetResponse>(responseBody)!;
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
    /// Merge the supplied values with an existing profile or create a new profile if one doesn't already exist.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Profiles.CreateAsync(
    ///     "user_id",
    ///     new MergeProfileRequest
    ///     {
    ///         Profile = new Dictionary&lt;string, object&gt;()
    ///         {
    ///             {
    ///                 "profile",
    ///                 new Dictionary&lt;object, object?&gt;() { { "key", "value" } }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<MergeProfileResponse> CreateAsync(
        string userId,
        MergeProfileRequest request,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/profiles/{userId}",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<MergeProfileResponse>(responseBody)!;
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
    /// When using `PUT`, be sure to include all the key-value pairs required by the recipient's profile.
    /// Any key-value pairs that exist in the profile but fail to be included in the `PUT` request will be
    /// removed from the profile. Remember, a `PUT` update is a full replacement of the data. For partial updates,
    /// use the [Patch](https://www.courier.com/docs/reference/profiles/patch/) request.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Profiles.ReplaceAsync(
    ///     "user_id",
    ///     new ReplaceProfileRequest
    ///     {
    ///         Profile = new Dictionary&lt;string, object&gt;()
    ///         {
    ///             {
    ///                 "profile",
    ///                 new Dictionary&lt;object, object?&gt;() { { "key", "value" } }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<ReplaceProfileResponse> ReplaceAsync(
        string userId,
        ReplaceProfileRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"/profiles/{userId}",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ReplaceProfileResponse>(responseBody)!;
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
    /// await client.Profiles.MergeProfileAsync(
    ///     "user_id",
    ///     new List&lt;UserProfilePatch&gt;()
    ///     {
    ///         new UserProfilePatch
    ///         {
    ///             Op = "op",
    ///             Path = "path",
    ///             Value = "value",
    ///         },
    ///         new UserProfilePatch
    ///         {
    ///             Op = "op",
    ///             Path = "path",
    ///             Value = "value",
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task MergeProfileAsync(
        string userId,
        IEnumerable<UserProfilePatch> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethodExtensions.Patch,
                Path = $"/profiles/{userId}",
                Body = request,
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

    /// <summary>
    /// Deletes the specified user profile.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Profiles.DeleteAsync("user_id");
    /// </code>
    /// </example>
    public async Task DeleteAsync(
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Delete,
                Path = $"/profiles/{userId}",
                Options = options,
            },
            cancellationToken
        );
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
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

    /// <summary>
    /// Returns the subscribed lists for a specified user.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Profiles.GetListSubscriptionsAsync("user_id", new GetListSubscriptionsRequest());
    /// </code>
    /// </example>
    public async Task<GetListSubscriptionsResponse> GetListSubscriptionsAsync(
        string userId,
        GetListSubscriptionsRequest request,
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
                Path = $"/profiles/{userId}/lists",
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
                return JsonUtils.Deserialize<GetListSubscriptionsResponse>(responseBody)!;
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
    /// Subscribes the given user to one or more lists. If the list does not exist, it will be created.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Profiles.SubscribeToListsAsync(
    ///     "user_id",
    ///     new SubscribeToListsRequest
    ///     {
    ///         Lists = new List&lt;SubscribeToListsRequestListObject&gt;()
    ///         {
    ///             new SubscribeToListsRequestListObject { ListId = "listId", Preferences = null },
    ///             new SubscribeToListsRequestListObject { ListId = "listId", Preferences = null },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<SubscribeToListsResponse> SubscribeToListsAsync(
        string userId,
        SubscribeToListsRequest request,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/profiles/{userId}/lists",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<SubscribeToListsResponse>(responseBody)!;
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
    /// Removes all list subscriptions for given user.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Profiles.DeleteListSubscriptionAsync("user_id");
    /// </code>
    /// </example>
    public async Task<DeleteListSubscriptionResponse> DeleteListSubscriptionAsync(
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Delete,
                Path = $"/profiles/{userId}/lists",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<DeleteListSubscriptionResponse>(responseBody)!;
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
