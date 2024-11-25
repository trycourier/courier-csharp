using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public partial class TenantsClient
{
    private RawClient _client;

    internal TenantsClient(RawClient client)
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
    /// <example>
    /// <code>
    /// await client.Users.Tenants.AddMultpleAsync(
    ///     "user_id",
    ///     new AddUserToMultipleTenantsParams
    ///     {
    ///         Tenants = new List&lt;UserTenantAssociation&gt;()
    ///         {
    ///             new UserTenantAssociation
    ///             {
    ///                 UserId = null,
    ///                 Type = null,
    ///                 TenantId = "tenant_id",
    ///                 Profile = null,
    ///             },
    ///             new UserTenantAssociation
    ///             {
    ///                 UserId = null,
    ///                 Type = null,
    ///                 TenantId = "tenant_id",
    ///                 Profile = null,
    ///             },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task AddMultpleAsync(
        string userId,
        AddUserToMultipleTenantsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"users/{userId}/tenants",
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

    /// <summary>
    /// This endpoint is used to add a single tenant.
    ///
    /// A custom profile can also be supplied with the tenant.
    /// This profile will be merged with the user's main profile
    /// when sending to the user with that tenant.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Tenants.AddAsync(
    ///     "user_id",
    ///     "tenant_id",
    ///     new AddUserToSingleTenantsParams { Profile = null }
    /// );
    /// </code>
    /// </example>
    public async Task AddAsync(
        string userId,
        string tenantId,
        AddUserToSingleTenantsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"users/{userId}/tenants/{tenantId}",
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

    /// <summary>
    /// Removes a user from any tenants they may have been associated with.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Tenants.RemoveAllAsync("user_id");
    /// </code>
    /// </example>
    public async Task RemoveAllAsync(
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Delete,
                Path = $"users/{userId}/tenants",
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

    /// <summary>
    /// Removes a user from the supplied tenant.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Tenants.RemoveAsync("user_id", "tenant_id");
    /// </code>
    /// </example>
    public async Task RemoveAsync(
        string userId,
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
                Path = $"users/{userId}/tenants/{tenantId}",
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

    /// <summary>
    /// Returns a paginated list of user tenant associations.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.Tenants.ListAsync("user_id", new ListTenantsForUserParams());
    /// </code>
    /// </example>
    public async Task<ListTenantsForUserResponse> ListAsync(
        string userId,
        ListTenantsForUserParams request,
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
                Path = $"users/{userId}/tenants",
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
                return JsonUtils.Deserialize<ListTenantsForUserResponse>(responseBody)!;
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
