using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Profiles;
using Profiles = TryCourier.Services.Profiles;

namespace TryCourier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Profiles::IListService Lists { get; }

    /// <summary>
    /// Merges the supplied values into a user's profile, creating it if absent and
    /// leaving any key you omit untouched. Prefer this for everyday writes.
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
    /// Returns a user's stored profile and preferences, including the email address,
    /// phone number, and push tokens Courier can reach them on.
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
    /// Applies a JSON Patch to a user profile, adding, removing, or replacing
    /// individual fields without sending the whole object.
    /// </summary>
    Task Update(ProfileUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(ProfileUpdateParams, CancellationToken)"/>
    Task Update(
        string userID,
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a user's profile and stored contact details. List subscriptions and
    /// preferences are separate resources, so remove those too if required.
    /// </summary>
    Task Delete(ProfileDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ProfileDeleteParams, CancellationToken)"/>
    Task Delete(
        string userID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Overwrites a user profile in full, removing any key absent from the request
    /// body. Use the patch endpoint when changing a single field.
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

/// <summary>
/// A view of <see cref="IProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Profiles::IListServiceWithRawResponse Lists { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /profiles/{user_id}</c>, but is otherwise the
    /// same as <see cref="IProfileService.Create(ProfileCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProfileCreateResponse>> Create(
        ProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ProfileCreateParams, CancellationToken)"/>
    Task<HttpResponse<ProfileCreateResponse>> Create(
        string userID,
        ProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /profiles/{user_id}</c>, but is otherwise the
    /// same as <see cref="IProfileService.Retrieve(ProfileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProfileRetrieveResponse>> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ProfileRetrieveResponse>> Retrieve(
        string userID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /profiles/{user_id}</c>, but is otherwise the
    /// same as <see cref="IProfileService.Update(ProfileUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string userID,
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /profiles/{user_id}</c>, but is otherwise the
    /// same as <see cref="IProfileService.Delete(ProfileDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string userID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /profiles/{user_id}</c>, but is otherwise the
    /// same as <see cref="IProfileService.Replace(ProfileReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProfileReplaceResponse>> Replace(
        ProfileReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(ProfileReplaceParams, CancellationToken)"/>
    Task<HttpResponse<ProfileReplaceResponse>> Replace(
        string userID,
        ProfileReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}
