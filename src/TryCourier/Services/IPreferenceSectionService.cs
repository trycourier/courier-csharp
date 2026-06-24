using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.PreferenceSections;
using TryCourier.Services.PreferenceSections;

namespace TryCourier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPreferenceSectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPreferenceSectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreferenceSectionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITopicService Topics { get; }

    /// <summary>
    /// Create a preference section in your workspace. The section id is generated and
    /// returned. Topics are created inside a section via POST
    /// /preferences/sections/{section_id}/topics.
    /// </summary>
    Task<PreferenceSectionGetResponse> Create(
        PreferenceSectionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a preference section by id, including its topics.
    /// </summary>
    Task<PreferenceSectionGetResponse> Retrieve(
        PreferenceSectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PreferenceSectionRetrieveParams, CancellationToken)"/>
    Task<PreferenceSectionGetResponse> Retrieve(
        string sectionID,
        PreferenceSectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the workspace's preference sections. Each section embeds its topics. Scoped
    /// to the workspace of the API key.
    /// </summary>
    Task<PreferenceSectionListResponse> List(
        PreferenceSectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a preference section. The section must be empty: delete its topics
    /// first, otherwise the request fails with 409.
    /// </summary>
    Task Archive(
        PreferenceSectionArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(PreferenceSectionArchiveParams, CancellationToken)"/>
    Task Archive(
        string sectionID,
        PreferenceSectionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publish the workspace's preferences page. Takes a snapshot of every section with
    /// its topics under a new published version, making the current state visible on
    /// the hosted preferences page (non-draft).
    /// </summary>
    Task<PublishPreferencesResponse> Publish(
        PreferenceSectionPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace a preference section. Full document replacement; missing optional fields
    /// are cleared. Topics attached to the section are unaffected.
    /// </summary>
    Task<PreferenceSectionGetResponse> Replace(
        PreferenceSectionReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(PreferenceSectionReplaceParams, CancellationToken)"/>
    Task<PreferenceSectionGetResponse> Replace(
        string sectionID,
        PreferenceSectionReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPreferenceSectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPreferenceSectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreferenceSectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    ITopicServiceWithRawResponse Topics { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /preferences/sections</c>, but is otherwise the
    /// same as <see cref="IPreferenceSectionService.Create(PreferenceSectionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceSectionGetResponse>> Create(
        PreferenceSectionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /preferences/sections/{section_id}</c>, but is otherwise the
    /// same as <see cref="IPreferenceSectionService.Retrieve(PreferenceSectionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceSectionGetResponse>> Retrieve(
        PreferenceSectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PreferenceSectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceSectionGetResponse>> Retrieve(
        string sectionID,
        PreferenceSectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /preferences/sections</c>, but is otherwise the
    /// same as <see cref="IPreferenceSectionService.List(PreferenceSectionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceSectionListResponse>> List(
        PreferenceSectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /preferences/sections/{section_id}</c>, but is otherwise the
    /// same as <see cref="IPreferenceSectionService.Archive(PreferenceSectionArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        PreferenceSectionArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(PreferenceSectionArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string sectionID,
        PreferenceSectionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /preferences/publish</c>, but is otherwise the
    /// same as <see cref="IPreferenceSectionService.Publish(PreferenceSectionPublishParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PublishPreferencesResponse>> Publish(
        PreferenceSectionPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /preferences/sections/{section_id}</c>, but is otherwise the
    /// same as <see cref="IPreferenceSectionService.Replace(PreferenceSectionReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceSectionGetResponse>> Replace(
        PreferenceSectionReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(PreferenceSectionReplaceParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceSectionGetResponse>> Replace(
        string sectionID,
        PreferenceSectionReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}
