using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Audiences;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAudienceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAudienceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudienceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the specified audience by id.
    /// </summary>
    Task<Audience> Retrieve(
        AudienceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AudienceRetrieveParams, CancellationToken)"/>
    Task<Audience> Retrieve(
        string audienceID,
        AudienceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates audience.
    /// </summary>
    Task<AudienceUpdateResponse> Update(
        AudienceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AudienceUpdateParams, CancellationToken)"/>
    Task<AudienceUpdateResponse> Update(
        string audienceID,
        AudienceUpdateParams? parameters = null,
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

    /// <inheritdoc cref="Delete(AudienceDeleteParams, CancellationToken)"/>
    Task Delete(
        string audienceID,
        AudienceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get list of members of an audience.
    /// </summary>
    Task<AudienceListMembersResponse> ListMembers(
        AudienceListMembersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListMembers(AudienceListMembersParams, CancellationToken)"/>
    Task<AudienceListMembersResponse> ListMembers(
        string audienceID,
        AudienceListMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAudienceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAudienceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudienceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /audiences/{audience_id}`, but is otherwise the
    /// same as <see cref="IAudienceService.Retrieve(AudienceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Audience>> Retrieve(
        AudienceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AudienceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Audience>> Retrieve(
        string audienceID,
        AudienceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /audiences/{audience_id}`, but is otherwise the
    /// same as <see cref="IAudienceService.Update(AudienceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AudienceUpdateResponse>> Update(
        AudienceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AudienceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AudienceUpdateResponse>> Update(
        string audienceID,
        AudienceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /audiences`, but is otherwise the
    /// same as <see cref="IAudienceService.List(AudienceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AudienceListResponse>> List(
        AudienceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /audiences/{audience_id}`, but is otherwise the
    /// same as <see cref="IAudienceService.Delete(AudienceDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        AudienceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AudienceDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string audienceID,
        AudienceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /audiences/{audience_id}/members`, but is otherwise the
    /// same as <see cref="IAudienceService.ListMembers(AudienceListMembersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AudienceListMembersResponse>> ListMembers(
        AudienceListMembersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListMembers(AudienceListMembersParams, CancellationToken)"/>
    Task<HttpResponse<AudienceListMembersResponse>> ListMembers(
        string audienceID,
        AudienceListMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
