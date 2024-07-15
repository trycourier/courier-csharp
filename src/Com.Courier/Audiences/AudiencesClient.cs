using System.Net.Http;
using System.Text.Json;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

public class AudiencesClient
{
    private RawClient _client;

    public AudiencesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns the specified audience by id.
    /// </summary>
    public async Task<Audience> GetAsync(string audienceId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"/audiences/{audienceId}"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<Audience>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Creates or updates audience.
    /// </summary>
    public async Task<AudienceUpdateResponse> UpdateAsync(
        string audienceId,
        AudienceUpdateParams request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/audiences/{audienceId}",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<AudienceUpdateResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Deletes the specified audience.
    /// </summary>
    public async Task DeleteAsync(string audienceId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"/audiences/{audienceId}"
            }
        );
    }

    /// <summary>
    /// Get list of members of an audience.
    /// </summary>
    public async Task<AudienceMemberListResponse> ListMembersAsync(
        string audienceId,
        AudienceMembersListParams request
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
                Path = $"/audiences/{audienceId}/members",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<AudienceMemberListResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Get the audiences associated with the authorization token.
    /// </summary>
    public async Task<AudienceListResponse> ListAudiencesAsync(AudiencesListParams request)
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
                Path = "/audiences",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<AudienceListResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
