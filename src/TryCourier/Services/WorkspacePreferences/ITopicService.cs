using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.WorkspacePreferences;
using TryCourier.Models.WorkspacePreferences.Topics;

namespace TryCourier.Services.WorkspacePreferences;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITopicService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITopicServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITopicService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a subscription preference topic inside a workspace preference. Fails with
    /// 404 if the workspace preference does not exist. The topic id is generated and
    /// returned.
    /// </summary>
    Task<WorkspacePreferenceTopicGetResponse> Create(
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TopicCreateParams, CancellationToken)"/>
    Task<WorkspacePreferenceTopicGetResponse> Create(
        string sectionID,
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a topic within a workspace preference. Returns 404 if the workspace
    /// preference does not exist, the topic does not exist, or the topic belongs to a
    /// different workspace preference.
    /// </summary>
    Task<WorkspacePreferenceTopicGetResponse> Retrieve(
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TopicRetrieveParams, CancellationToken)"/>
    Task<WorkspacePreferenceTopicGetResponse> Retrieve(
        string topicID,
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the topics in a workspace preference.
    /// </summary>
    Task<WorkspacePreferenceTopicListResponse> List(
        TopicListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TopicListParams, CancellationToken)"/>
    Task<WorkspacePreferenceTopicListResponse> List(
        string sectionID,
        TopicListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a topic and remove it from its workspace preference. Same 404 rules as
    /// GET.
    /// </summary>
    Task Archive(TopicArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(TopicArchiveParams, CancellationToken)"/>
    Task Archive(
        string topicID,
        TopicArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace a topic within a workspace preference. Full document replacement;
    /// missing optional fields are cleared. Same 404 rules as GET.
    /// </summary>
    Task<WorkspacePreferenceTopicGetResponse> Replace(
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(TopicReplaceParams, CancellationToken)"/>
    Task<WorkspacePreferenceTopicGetResponse> Replace(
        string topicID,
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITopicService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITopicServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITopicServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /preferences/sections/{section_id}/topics</c>, but is otherwise the
    /// same as <see cref="ITopicService.Create(TopicCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Create(
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TopicCreateParams, CancellationToken)"/>
    Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Create(
        string sectionID,
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /preferences/sections/{section_id}/topics/{topic_id}</c>, but is otherwise the
    /// same as <see cref="ITopicService.Retrieve(TopicRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Retrieve(
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TopicRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Retrieve(
        string topicID,
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /preferences/sections/{section_id}/topics</c>, but is otherwise the
    /// same as <see cref="ITopicService.List(TopicListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspacePreferenceTopicListResponse>> List(
        TopicListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TopicListParams, CancellationToken)"/>
    Task<HttpResponse<WorkspacePreferenceTopicListResponse>> List(
        string sectionID,
        TopicListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /preferences/sections/{section_id}/topics/{topic_id}</c>, but is otherwise the
    /// same as <see cref="ITopicService.Archive(TopicArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        TopicArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(TopicArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string topicID,
        TopicArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /preferences/sections/{section_id}/topics/{topic_id}</c>, but is otherwise the
    /// same as <see cref="ITopicService.Replace(TopicReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Replace(
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(TopicReplaceParams, CancellationToken)"/>
    Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Replace(
        string topicID,
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}
