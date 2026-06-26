using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.WorkspacePreferences;
using TryCourier.Services.WorkspacePreferences;

namespace TryCourier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWorkspacePreferenceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWorkspacePreferenceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkspacePreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITopicService Topics { get; }

    /// <summary>
    /// Create a workspace preference. The workspace preference id is generated and
    /// returned. Topics are created inside a workspace preference via POST
    /// /preferences/sections/{section_id}/topics.
    /// </summary>
    Task<WorkspacePreferenceGetResponse> Create(
        WorkspacePreferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a workspace preference by id, including its topics.
    /// </summary>
    Task<WorkspacePreferenceGetResponse> Retrieve(
        WorkspacePreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WorkspacePreferenceRetrieveParams, CancellationToken)"/>
    Task<WorkspacePreferenceGetResponse> Retrieve(
        string sectionID,
        WorkspacePreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the workspace's preferences. Each workspace preference embeds its topics.
    /// Scoped to the workspace of the API key.
    /// </summary>
    Task<WorkspacePreferenceListResponse> List(
        WorkspacePreferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a workspace preference. The workspace preference must be empty: delete
    /// its topics first, otherwise the request fails with 409.
    /// </summary>
    Task Archive(
        WorkspacePreferenceArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(WorkspacePreferenceArchiveParams, CancellationToken)"/>
    Task Archive(
        string sectionID,
        WorkspacePreferenceArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publish the workspace's preferences page. Takes a snapshot of every workspace
    /// preference with its topics under a new published version, making the current
    /// state visible on the hosted preferences page (non-draft).
    /// </summary>
    Task<PublishPreferencesResponse> Publish(
        WorkspacePreferencePublishParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace a workspace preference. Full document replacement; missing optional
    /// fields are cleared. Topics attached to the workspace preference are unaffected.
    /// </summary>
    Task<WorkspacePreferenceGetResponse> Replace(
        WorkspacePreferenceReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(WorkspacePreferenceReplaceParams, CancellationToken)"/>
    Task<WorkspacePreferenceGetResponse> Replace(
        string sectionID,
        WorkspacePreferenceReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWorkspacePreferenceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWorkspacePreferenceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkspacePreferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    ITopicServiceWithRawResponse Topics { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /preferences/sections</c>, but is otherwise the
    /// same as <see cref="IWorkspacePreferenceService.Create(WorkspacePreferenceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspacePreferenceGetResponse>> Create(
        WorkspacePreferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /preferences/sections/{section_id}</c>, but is otherwise the
    /// same as <see cref="IWorkspacePreferenceService.Retrieve(WorkspacePreferenceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspacePreferenceGetResponse>> Retrieve(
        WorkspacePreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WorkspacePreferenceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WorkspacePreferenceGetResponse>> Retrieve(
        string sectionID,
        WorkspacePreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /preferences/sections</c>, but is otherwise the
    /// same as <see cref="IWorkspacePreferenceService.List(WorkspacePreferenceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspacePreferenceListResponse>> List(
        WorkspacePreferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /preferences/sections/{section_id}</c>, but is otherwise the
    /// same as <see cref="IWorkspacePreferenceService.Archive(WorkspacePreferenceArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        WorkspacePreferenceArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(WorkspacePreferenceArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string sectionID,
        WorkspacePreferenceArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /preferences/publish</c>, but is otherwise the
    /// same as <see cref="IWorkspacePreferenceService.Publish(WorkspacePreferencePublishParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PublishPreferencesResponse>> Publish(
        WorkspacePreferencePublishParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /preferences/sections/{section_id}</c>, but is otherwise the
    /// same as <see cref="IWorkspacePreferenceService.Replace(WorkspacePreferenceReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspacePreferenceGetResponse>> Replace(
        WorkspacePreferenceReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(WorkspacePreferenceReplaceParams, CancellationToken)"/>
    Task<HttpResponse<WorkspacePreferenceGetResponse>> Replace(
        string sectionID,
        WorkspacePreferenceReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}
