using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Audiences;

namespace Courier.Services.Audiences;

public interface IAudienceService
{
    IAudienceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the specified audience by id.
    /// </summary>
    Task<Audience> Retrieve(
        AudienceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates audience.
    /// </summary>
    Task<AudienceUpdateResponse> Update(
        AudienceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the audiences associated with the authorization token.
    /// </summary>
    Task<AudienceListResponse> List(
        AudienceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the specified audience.
    /// </summary>
    Task Delete(AudienceDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get list of members of an audience.
    /// </summary>
    Task<AudienceListMembersResponse> ListMembers(
        AudienceListMembersParams parameters,
        CancellationToken cancellationToken = default
    );
}
