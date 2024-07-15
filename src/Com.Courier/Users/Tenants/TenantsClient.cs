using System.Net.Http;
using System.Text.Json;
using Com.Courier.Core;
using Com.Courier.Users;

#nullable enable

namespace Com.Courier.Users;

public class TenantsClient
{
    private RawClient _client;

    public TenantsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// This endpoint is used to add a user to
    /// multiple tenants in one call.
    /// A custom profile can also be supplied for each tenant.
    /// This profile will be merged with the user's main
    /// profile when sending to the user with that tenant.
    /// </summary>
    public async Task AddMultpleAsync(string userId, AddUserToMultipleTenantsParams request)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"users/{userId}/tenants",
                Body = request
            }
        );
    }

    /// <summary>
    /// This endpoint is used to add a single tenant.
    ///
    /// A custom profile can also be supplied with the tenant.
    /// This profile will be merged with the user's main profile
    /// when sending to the user with that tenant.
    /// </summary>
    public async Task AddAsync(string userId, string tenantId, AddUserToSingleTenantsParams request)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"users/{userId}/tenants/{tenantId}",
                Body = request
            }
        );
    }

    /// <summary>
    /// Removes a user from any tenants they may have been associated with.
    /// </summary>
    public async Task RemoveAllAsync(string userId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"users/{userId}/tenants"
            }
        );
    }

    /// <summary>
    /// Removes a user from the supplied tenant.
    /// </summary>
    public async Task RemoveAsync(string userId, string tenantId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"users/{userId}/tenants/{tenantId}"
            }
        );
    }

    /// <summary>
    /// Returns a paginated list of user tenant associations.
    /// </summary>
    public async Task<ListTenantsForUserResponse> ListAsync(
        string userId,
        ListTenantsForUserParams request
    )
    {
        var _query = new Dictionary<string, object>() { };
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"users/{userId}/tenants",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<ListTenantsForUserResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
