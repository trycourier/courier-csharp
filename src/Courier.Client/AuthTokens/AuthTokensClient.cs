using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;

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
    /// <example><code>
    /// await client.AuthTokens.IssueTokenAsync(
    ///     new IssueTokenParams { Scope = "scope", ExpiresIn = "expires_in" }
    /// );
    /// </code></example>
    public async Task<IssueTokenResponse> IssueTokenAsync(
        IssueTokenParams request,
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
                    Path = "/auth/issue-token",
                    Body = request,
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
                return JsonUtils.Deserialize<IssueTokenResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
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
}
