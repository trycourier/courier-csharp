using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Tenants = Courier.Models.Users.Tenants;

namespace Courier.Services.Users.Tenants;

public interface ITenantService
{
    ITenantService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a paginated list of user tenant associations.
    /// </summary>
    Task<Tenants::TenantListResponse> List(
        Tenants::TenantListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to add a user to multiple tenants in one call. A custom
    /// profile can also be supplied for each tenant.  This profile will be merged
    /// with the user's main  profile when sending to the user with that tenant.
    /// </summary>
    Task AddMultiple(
        Tenants::TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to add a single tenant.
    ///
    /// <para>A custom profile can also be supplied with the tenant.  This profile
    /// will be merged with the user's main profile  when sending to the user with
    /// that tenant.</para>
    /// </summary>
    Task AddSingle(
        Tenants::TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a user from any tenants they may have been associated with.
    /// </summary>
    Task RemoveAll(
        Tenants::TenantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a user from the supplied tenant.
    /// </summary>
    Task RemoveSingle(
        Tenants::TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    );
}
