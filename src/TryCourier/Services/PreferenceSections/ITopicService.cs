using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.PreferenceSections;
using TryCourier.Models.PreferenceSections.Topics;

namespace TryCourier.Services.PreferenceSections;

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
    /// Create a subscription preference topic inside a section. Fails with 404 if the
    /// section does not exist. The topic id is generated and returned.
    /// </summary>
    Task<PreferenceTopicGetResponse> Create(
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TopicCreateParams, CancellationToken)"/>
    Task<PreferenceTopicGetResponse> Create(
        string sectionID,
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a topic within a section. Returns 404 if the section does not exist,
    /// the topic does not exist, or the topic belongs to a different section.
    /// </summary>
    Task<PreferenceTopicGetResponse> Retrieve(
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TopicRetrieveParams, CancellationToken)"/>
    Task<PreferenceTopicGetResponse> Retrieve(
        string topicID,
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the topics in a preference section.
    /// </summary>
    Task<PreferenceTopicListResponse> List(
        TopicListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TopicListParams, CancellationToken)"/>
    Task<PreferenceTopicListResponse> List(
        string sectionID,
        TopicListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a topic and remove it from its section. Same 404 rules as GET.
    /// </summary>
    Task Archive(TopicArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(TopicArchiveParams, CancellationToken)"/>
    Task Archive(
        string topicID,
        TopicArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace a topic within a section. Full document replacement; missing optional
    /// fields are cleared. Same 404 rules as GET.
    /// </summary>
    Task<PreferenceTopicGetResponse> Replace(
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(TopicReplaceParams, CancellationToken)"/>
    Task<PreferenceTopicGetResponse> Replace(
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
    Task<HttpResponse<PreferenceTopicGetResponse>> Create(
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TopicCreateParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceTopicGetResponse>> Create(
        string sectionID,
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /preferences/sections/{section_id}/topics/{topic_id}</c>, but is otherwise the
    /// same as <see cref="ITopicService.Retrieve(TopicRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceTopicGetResponse>> Retrieve(
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TopicRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceTopicGetResponse>> Retrieve(
        string topicID,
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /preferences/sections/{section_id}/topics</c>, but is otherwise the
    /// same as <see cref="ITopicService.List(TopicListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceTopicListResponse>> List(
        TopicListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TopicListParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceTopicListResponse>> List(
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
    Task<HttpResponse<PreferenceTopicGetResponse>> Replace(
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(TopicReplaceParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceTopicGetResponse>> Replace(
        string topicID,
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}
