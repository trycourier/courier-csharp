using System.Net.Http;
using System.Text.Json;
using Courier.Client.Core;
using Courier.Client.Users;

#nullable enable

namespace Courier.Client.Users;

public class PreferencesClient
{
    private RawClient _client;

    public PreferencesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Fetch all user preferences.
    /// </summary>
    public async Task<UserPreferencesListResponse> ListAsync(string userId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"/users/{userId}/preferences"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<UserPreferencesListResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Fetch user preferences for a specific subscription topic.
    /// </summary>
    public async Task<UserPreferencesGetResponse> GetAsync(string userId, string topicId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"/users/{userId}/preferences/{topicId}"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<UserPreferencesGetResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Update or Create user preferences for a specific subscription topic.
    /// </summary>
    public async Task<UserPreferencesUpdateResponse> UpdateAsync(
        string userId,
        string topicId,
        UserPreferencesUpdateParams request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/users/{userId}/preferences/{topicId}",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<UserPreferencesUpdateResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
