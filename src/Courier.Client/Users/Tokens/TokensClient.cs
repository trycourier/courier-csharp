using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public partial class TokensClient
{
    private RawClient _client;

    internal TokensClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Adds multiple tokens to a user and overwrites matching existing tokens.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Tokens.AddMultipleAsync("user_id");
    /// </code>
    /// </example>
    public async Task AddMultipleAsync(
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"/users/{userId}/tokens",
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
    /// Adds a single token to a user and overwrites a matching existing token.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Tokens.AddAsync(
    ///     "user_id",
    ///     "token",
    ///     new UserToken
    ///     {
    ///         Token = null,
    ///         ProviderKey = ProviderKey.FirebaseFcm,
    ///         ExpiryDate = null,
    ///         Properties = null,
    ///         Device = null,
    ///         Tracking = null,
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task AddAsync(
        string userId,
        string token,
        UserToken request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"/users/{userId}/tokens/{token}",
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
    /// Apply a JSON Patch (RFC 6902) to the specified token.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Tokens.UpdateAsync(
    ///     "user_id",
    ///     "token",
    ///     new PatchUserTokenOpts
    ///     {
    ///         Patch = new List&lt;PatchOperation&gt;()
    ///         {
    ///             new PatchOperation
    ///             {
    ///                 Op = "op",
    ///                 Path = "path",
    ///                 Value = null,
    ///             },
    ///             new PatchOperation
    ///             {
    ///                 Op = "op",
    ///                 Path = "path",
    ///                 Value = null,
    ///             },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task UpdateAsync(
        string userId,
        string token,
        PatchUserTokenOpts request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethodExtensions.Patch,
                Path = $"/users/{userId}/tokens/{token}",
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
    /// Get single token available for a `:token`
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Tokens.GetAsync("user_id", "token");
    /// </code>
    /// </example>
    public async Task<GetUserTokenResponse> GetAsync(
        string userId,
        string token,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/users/{userId}/tokens/{token}",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<GetUserTokenResponse>(responseBody)!;
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
    /// Gets all tokens available for a :user_id
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Tokens.ListAsync("user_id");
    /// </code>
    /// </example>
    public async Task<IEnumerable<UserToken>> ListAsync(
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
                Path = $"/users/{userId}/tokens",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<IEnumerable<UserToken>>(responseBody)!;
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
    /// await client.Users.Tokens.DeleteAsync("user_id", "token");
    /// </code>
    /// </example>
    public async Task DeleteAsync(
        string userId,
        string token,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Delete,
                Path = $"/users/{userId}/tokens/{token}",
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
