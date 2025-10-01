using System.Threading.Tasks;
using Courier.Models.Users.Tenants;

namespace Courier.Services.Users.Tenants;

public interface ITenantService
{
    /// <summary>
    /// Returns a paginated list of user tenant associations.
    /// </summary>
    Task<TenantListResponse> List(TenantListParams parameters);

    /// <summary>
    /// This endpoint is used to add a user to multiple tenants in one call. A custom
    /// profile can also be supplied for each tenant.  This profile will be merged
    /// with the user's main  profile when sending to the user with that tenant.
    /// </summary>
    Task AddMultiple(TenantAddMultipleParams parameters);

    /// <summary>
    /// This endpoint is used to add a single tenant.
    ///
    /// A custom profile can also be supplied with the tenant.  This profile will
    /// be merged with the user's main profile  when sending to the user with that tenant.
    /// </summary>
    Task AddSingle(TenantAddSingleParams parameters);

    /// <summary>
    /// Removes a user from any tenants they may have been associated with.
    /// </summary>
    Task RemoveAll(TenantRemoveAllParams parameters);

    /// <summary>
    /// Removes a user from the supplied tenant.
    /// </summary>
    Task RemoveSingle(TenantRemoveSingleParams parameters);
}
