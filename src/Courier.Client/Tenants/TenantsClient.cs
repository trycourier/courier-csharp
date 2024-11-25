using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class TenantsClient
{
    private RawClient _client;

    internal TenantsClient(RawClient client)
    {
        _client = client;
    }

    /// <example>
    /// <code>
    /// await client.Tenants.CreateOrReplaceAsync(
    ///     "tenant_id",
    ///     new TenantCreateOrReplaceParams
    ///     {
    ///         Name = "name",
    ///         ParentTenantId = null,
    ///         DefaultPreferences = null,
    ///         Properties = null,
    ///         UserProfile = null,
    ///         BrandId = null,
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<Tenant> CreateOrReplaceAsync(
        string tenantId,
        TenantCreateOrReplaceParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"/tenants/{tenantId}",
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
                return JsonUtils.Deserialize<Tenant>(responseBody)!;
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
    /// await client.Tenants.GetAsync("tenant_id");
    /// </code>
    /// </example>
    public async Task<Tenant> GetAsync(
        string tenantId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/tenants/{tenantId}",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<Tenant>(responseBody)!;
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
    /// await client.Tenants.ListAsync(new ListTenantParams());
    /// </code>
    /// </example>
    public async Task<TenantListResponse> ListAsync(
        ListTenantParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
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
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = "/tenants",
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
                return JsonUtils.Deserialize<TenantListResponse>(responseBody)!;
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

    /// <example>
    /// <code>
    /// await client.Tenants.DeleteAsync("tenant_id");
    /// </code>
    /// </example>
    public async Task DeleteAsync(
        string tenantId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Delete,
                Path = $"/tenants/{tenantId}",
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

    /// <example>
    /// <code>
    /// await client.Tenants.GetUsersByTenantAsync("tenant_id", new ListUsersForTenantParams());
    /// </code>
    /// </example>
    public async Task<ListUsersForTenantResponse> GetUsersByTenantAsync(
        string tenantId,
        ListUsersForTenantParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
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
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/tenants/{tenantId}/users",
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
                return JsonUtils.Deserialize<ListUsersForTenantResponse>(responseBody)!;
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
    /// await client.Tenants.CreateOrReplaceDefaultPreferencesForTopicAsync(
    ///     "tenantABC",
    ///     "HB529N49MD4D5PMX9WR5P4JH78NA",
    ///     new SubscriptionTopicNew
    ///     {
    ///         Status = SubscriptionTopicStatus.OptedIn,
    ///         HasCustomRouting = true,
    ///         CustomRouting = new List&lt;ChannelClassification&gt;() { ChannelClassification.Inbox },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task CreateOrReplaceDefaultPreferencesForTopicAsync(
        string tenantId,
        string topicId,
        SubscriptionTopicNew request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"/tenants/{tenantId}/default_preferences/items/{topicId}",
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
        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <example>
    /// <code>
    /// await client.Tenants.RemoveDefaultPreferencesForTopicAsync("tenant_id", "topic_id");
    /// </code>
    /// </example>
    public async Task RemoveDefaultPreferencesForTopicAsync(
        string tenantId,
        string topicId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Delete,
                Path = $"/tenants/{tenantId}/default_preferences/items/{topicId}",
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
