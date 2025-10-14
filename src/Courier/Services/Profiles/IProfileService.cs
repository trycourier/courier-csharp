using System.Threading.Tasks;
using Courier.Models.Profiles;
using Courier.Services.Profiles.Lists;

namespace Courier.Services.Profiles;

public interface IProfileService
{
    IListService Lists { get; }

    /// <summary>
    /// Merge the supplied values with an existing profile or create a new profile
    /// if one doesn't already exist.
    /// </summary>
    Task<ProfileCreateResponse> Create(ProfileCreateParams parameters);

    /// <summary>
    /// Returns the specified user profile.
    /// </summary>
    Task<ProfileRetrieveResponse> Retrieve(ProfileRetrieveParams parameters);

    /// <summary>
    /// Update a profile
    /// </summary>
    Task Update(ProfileUpdateParams parameters);

    /// <summary>
    /// Deletes the specified user profile.
    /// </summary>
    Task Delete(ProfileDeleteParams parameters);

    /// <summary>
    /// When using `PUT`, be sure to include all the key-value pairs required by
    /// the recipient's profile.  Any key-value pairs that exist in the profile but
    /// fail to be included in the `PUT` request will be  removed from the profile.
    /// Remember, a `PUT` update is a full replacement of the data. For partial updates,
    ///  use the [Patch](https://www.courier.com/docs/reference/profiles/patch/) request.
    /// </summary>
    Task<ProfileReplaceResponse> Replace(ProfileReplaceParams parameters);
}
