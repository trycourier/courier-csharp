using System.Net.Http;
using System.Text.Json;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

public class TenantsClient
{
    private RawClient _client;

    public TenantsClient(RawClient client)
    {
        _client = client;
    }

    public async Task<Tenant> CreateOrReplaceAsync(
        string tenantId,
        TenantCreateOrReplaceParams request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/tenants/{tenantId}",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<Tenant>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task<Tenant> GetAsync(string tenantId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Get, Path = $"/tenants/{tenantId}" }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<Tenant>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task<TenantListResponse> ListAsync(ListTenantParams request)
    {
        var _query = new Dictionary<string, object>() { };
        if (request.ParentTenantId != null)
        {
            _query["parent_tenant_id"] = request.ParentTenantId;
        }
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
                Path = "/tenants",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<TenantListResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task DeleteAsync(string tenantId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"/tenants/{tenantId}"
            }
        );
    }

    public async Task<ListUsersForTenantResponse> GetUsersByTenantAsync(
        string tenantId,
        ListUsersForTenantParams request
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
                Path = $"/tenants/{tenantId}/users",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<ListUsersForTenantResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    public async Task CreateOrReplaceDefaultPreferencesForTopicAsync(
        string tenantId,
        string topicId,
        SubscriptionTopicNew request
    )
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/tenants/{tenantId}/default_preferences/items/{topicId}",
                Body = request
            }
        );
    }

    public async Task RemoveDefaultPreferencesForTopicAsync(string tenantId, string topicId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"/tenants/{tenantId}/default_preferences/items/{topicId}"
            }
        );
    }
}
