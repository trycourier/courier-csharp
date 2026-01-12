using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Users.Preferences;

namespace Courier.Services.Users;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPreferenceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPreferenceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Fetch all user preferences.
    /// </summary>
    Task<PreferenceRetrieveResponse> Retrieve(
        PreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PreferenceRetrieveParams, CancellationToken)"/>
    Task<PreferenceRetrieveResponse> Retrieve(
        string userID,
        PreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch user preferences for a specific subscription topic.
    /// </summary>
    Task<PreferenceRetrieveTopicResponse> RetrieveTopic(
        PreferenceRetrieveTopicParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveTopic(PreferenceRetrieveTopicParams, CancellationToken)"/>
    Task<PreferenceRetrieveTopicResponse> RetrieveTopic(
        string topicID,
        PreferenceRetrieveTopicParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update or Create user preferences for a specific subscription topic.
    /// </summary>
    Task<PreferenceUpdateOrCreateTopicResponse> UpdateOrCreateTopic(
        PreferenceUpdateOrCreateTopicParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateOrCreateTopic(PreferenceUpdateOrCreateTopicParams, CancellationToken)"/>
    Task<PreferenceUpdateOrCreateTopicResponse> UpdateOrCreateTopic(
        string topicID,
        PreferenceUpdateOrCreateTopicParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPreferenceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPreferenceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreferenceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /users/{user_id}/preferences`, but is otherwise the
    /// same as <see cref="IPreferenceService.Retrieve(PreferenceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceRetrieveResponse>> Retrieve(
        PreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PreferenceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceRetrieveResponse>> Retrieve(
        string userID,
        PreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /users/{user_id}/preferences/{topic_id}`, but is otherwise the
    /// same as <see cref="IPreferenceService.RetrieveTopic(PreferenceRetrieveTopicParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceRetrieveTopicResponse>> RetrieveTopic(
        PreferenceRetrieveTopicParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveTopic(PreferenceRetrieveTopicParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceRetrieveTopicResponse>> RetrieveTopic(
        string topicID,
        PreferenceRetrieveTopicParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /users/{user_id}/preferences/{topic_id}`, but is otherwise the
    /// same as <see cref="IPreferenceService.UpdateOrCreateTopic(PreferenceUpdateOrCreateTopicParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceUpdateOrCreateTopicResponse>> UpdateOrCreateTopic(
        PreferenceUpdateOrCreateTopicParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateOrCreateTopic(PreferenceUpdateOrCreateTopicParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceUpdateOrCreateTopicResponse>> UpdateOrCreateTopic(
        string topicID,
        PreferenceUpdateOrCreateTopicParams parameters,
        CancellationToken cancellationToken = default
    );
}
