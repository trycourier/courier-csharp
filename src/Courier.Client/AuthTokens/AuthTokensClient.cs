using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class AuthTokensClient
{
    private RawClient _client;

    internal AuthTokensClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a new access token.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.AuthTokens.IssueTokenAsync(
    ///     new IssueTokenParams { Scope = "scope", ExpiresIn = "expires_in" }
    /// );
    /// </code>
    /// </example>
    public async Task<IssueTokenResponse> IssueTokenAsync(
        IssueTokenParams request,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = "/auth/issue-token",
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
                return JsonUtils.Deserialize<IssueTokenResponse>(responseBody)!;
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
}
