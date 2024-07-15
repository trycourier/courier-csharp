using System.Net.Http;
using System.Text.Json;
using Courier.Client.Core;
using Courier.Client.Users;

#nullable enable

namespace Courier.Client.Users;

public class TokensClient
{
    private RawClient _client;

    public TokensClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Adds multiple tokens to a user and overwrites matching existing tokens.
    /// </summary>
    public async Task AddMultipleAsync(string userId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/users/{userId}/tokens"
            }
        );
    }

    /// <summary>
    /// Adds a single token to a user and overwrites a matching existing token.
    /// </summary>
    public async Task AddAsync(string userId, string token, UserToken request)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/users/{userId}/tokens/{token}",
                Body = request
            }
        );
    }

    /// <summary>
    /// Apply a JSON Patch (RFC 6902) to the specified token.
    /// </summary>
    public async Task UpdateAsync(string userId, string token, PatchUserTokenOpts request)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethodExtensions.Patch,
                Path = $"/users/{userId}/tokens/{token}",
                Body = request
            }
        );
    }

    /// <summary>
    /// Get single token available for a `:token`
    /// </summary>
    public async Task<GetUserTokenResponse> GetAsync(string userId, string token)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"/users/{userId}/tokens/{token}"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<GetUserTokenResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Gets all tokens available for a :user_id
    /// </summary>
    public async Task<IEnumerable<UserToken>> ListAsync(string userId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"/users/{userId}/tokens"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<UserToken>>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task DeleteAsync(string userId, string token)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"/users/{userId}/tokens/{token}"
            }
        );
    }
}
