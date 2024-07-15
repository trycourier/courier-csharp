using System.Net.Http;
using System.Text.Json;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class AuthTokensClient
{
    private RawClient _client;

    public AuthTokensClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a new access token.
    /// </summary>
    public async Task<IssueTokenResponse> IssueTokenAsync(IssueTokenParams request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "/auth/issue-token",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IssueTokenResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
