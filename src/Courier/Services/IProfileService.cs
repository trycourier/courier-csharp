using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Profiles;
using Profiles = Courier.Services.Profiles;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProfileService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Profiles::IListService Lists { get; }

    /// <summary>
    /// Merge the supplied values with an existing profile or create a new profile
    /// if one doesn't already exist.
    /// </summary>
    Task<ProfileCreateResponse> Create(
        ProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ProfileCreateParams, CancellationToken)"/>
    Task<ProfileCreateResponse> Create(
        string userID,
        ProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the specified user profile.
    /// </summary>
    Task<ProfileRetrieveResponse> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProfileRetrieveParams, CancellationToken)"/>
    Task<ProfileRetrieveResponse> Retrieve(
        string userID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a profile
    /// </summary>
    Task Update(ProfileUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(ProfileUpdateParams, CancellationToken)"/>
    Task Update(
        string userID,
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the specified user profile.
    /// </summary>
    Task Delete(ProfileDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ProfileDeleteParams, CancellationToken)"/>
    Task Delete(
        string userID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// When using `PUT`, be sure to include all the key-value pairs required by the
    /// recipient's profile.  Any key-value pairs that exist in the profile but fail
    /// to be included in the `PUT` request will be  removed from the profile. Remember,
    /// a `PUT` update is a full replacement of the data. For partial updates,  use
    /// the [Patch](https://www.courier.com/docs/reference/profiles/patch/) request.
    /// </summary>
    Task<ProfileReplaceResponse> Replace(
        ProfileReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(ProfileReplaceParams, CancellationToken)"/>
    Task<ProfileReplaceResponse> Replace(
        string userID,
        ProfileReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}
