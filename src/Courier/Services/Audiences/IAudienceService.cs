using System.Threading.Tasks;
using Courier.Models;
using Courier.Models.Audiences;

namespace Courier.Services.Audiences;

public interface IAudienceService
{
    /// <summary>
    /// Returns the specified audience by id.
    /// </summary>
    Task<Audience> Retrieve(AudienceRetrieveParams parameters);

    /// <summary>
    /// Creates or updates audience.
    /// </summary>
    Task<AudienceUpdateResponse> Update(AudienceUpdateParams parameters);

    /// <summary>
    /// Get the audiences associated with the authorization token.
    /// </summary>
    Task<AudienceListResponse> List(AudienceListParams? parameters = null);

    /// <summary>
    /// Deletes the specified audience.
    /// </summary>
    Task Delete(AudienceDeleteParams parameters);

    /// <summary>
    /// Get list of members of an audience.
    /// </summary>
    Task<AudienceListMembersResponse> ListMembers(AudienceListMembersParams parameters);
}
