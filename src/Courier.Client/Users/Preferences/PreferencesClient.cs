using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public partial class PreferencesClient
{
    private RawClient _client;

    internal PreferencesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Fetch all user preferences.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Preferences.ListAsync("user_id", new UserPreferencesParams());
    /// </code>
    /// </example>
    public async Task<UserPreferencesListResponse> ListAsync(
        string userId,
        UserPreferencesParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.TenantId != null)
        {
            _query["tenant_id"] = request.TenantId;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/users/{userId}/preferences",
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
                return JsonUtils.Deserialize<UserPreferencesListResponse>(responseBody)!;
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
    /// Fetch user preferences for a specific subscription topic.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Preferences.GetAsync("user_id", "topic_id", new UserPreferencesTopicParams());
    /// </code>
    /// </example>
    public async Task<UserPreferencesGetResponse> GetAsync(
        string userId,
        string topicId,
        UserPreferencesTopicParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.TenantId != null)
        {
            _query["tenant_id"] = request.TenantId;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/users/{userId}/preferences/{topicId}",
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
                return JsonUtils.Deserialize<UserPreferencesGetResponse>(responseBody)!;
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

    /// <summary>
    /// Update or Create user preferences for a specific subscription topic.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Preferences.UpdateAsync(
    ///     "abc-123",
    ///     "74Q4QGFBEX481DP6JRPMV751H4XT",
    ///     new UserPreferencesUpdateParams
    ///     {
    ///         Topic = new TopicPreferenceUpdate
    ///         {
    ///             Status = PreferenceStatus.OptedIn,
    ///             HasCustomRouting = true,
    ///             CustomRouting = new List&lt;ChannelClassification&gt;()
    ///             {
    ///                 ChannelClassification.Inbox,
    ///                 ChannelClassification.Email,
    ///             },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<UserPreferencesUpdateResponse> UpdateAsync(
        string userId,
        string topicId,
        UserPreferencesUpdateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.TenantId != null)
        {
            _query["tenant_id"] = request.TenantId;
        }
        var requestBody = new Dictionary<string, object>() { { "topic", request.Topic } };
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"/users/{userId}/preferences/{topicId}",
                Body = requestBody,
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
                return JsonUtils.Deserialize<UserPreferencesUpdateResponse>(responseBody)!;
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
