using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Users.Preferences;

namespace TryCourier.Services.Users;

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
    /// Replace a user's complete set of preference overrides in a single request. The
    /// topics in the request body become the recipient's entire set of overrides:
    /// listed topics are created or updated, and every existing override that is not
    /// included in the body is reset to its topic default. Submitting an empty `topics`
    /// array is a valid clear-all that resets every existing override.
    ///
    /// <para>This operation is validation-atomic (all-or-nothing): structural
    /// validation fails fast with a single `400`, and if any topic is semantically
    /// invalid (an unknown topic, a `REQUIRED` topic that cannot be opted out, or a
    /// custom routing request that is not available on the workspace's plan) the
    /// request returns a single `400` aggregating every failure in `errors` and writes
    /// nothing. On success it returns `200` with `items` (the complete resulting
    /// override set) and `deleted` (the ids of the overrides that were reset to
    /// default).</para>
    ///
    /// <para>Every `topic_id` in the response — in `items`, `deleted`, and any `errors`
    /// — is returned in Courier's canonical topic id form, regardless of the form
    /// supplied in the request.</para>
    /// </summary>
    Task<PreferenceBulkReplaceResponse> BulkReplace(
        PreferenceBulkReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="BulkReplace(PreferenceBulkReplaceParams, CancellationToken)"/>
    Task<PreferenceBulkReplaceResponse> BulkReplace(
        string userID,
        PreferenceBulkReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Additively create or update a user's preferences for one or more subscription
    /// topics in a single request. Only the topics included in the request body are
    /// created or updated; any existing overrides for topics not listed are left
    /// untouched.
    ///
    /// <para>Structural validation of the request body fails fast with a single `400`.
    /// Beyond that, each topic is processed independently (partial-success, not
    /// all-or-nothing): valid topics are written and returned in `items`, while topics
    /// that cannot be applied are collected in `errors` with a per-topic `reason` (for
    /// example an unknown topic, a `REQUIRED` topic that cannot be opted out, a custom
    /// routing request that is not available on the workspace's plan, or a write
    /// failure). The request therefore returns `200` with both lists whenever the body
    /// is structurally valid.</para>
    ///
    /// <para>Every `topic_id` in the response — in both `items` and `errors` — is
    /// returned in Courier's canonical topic id form, regardless of the form supplied
    /// in the request.</para>
    /// </summary>
    Task<PreferenceBulkUpdateResponse> BulkUpdate(
        PreferenceBulkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="BulkUpdate(PreferenceBulkUpdateParams, CancellationToken)"/>
    Task<PreferenceBulkUpdateResponse> BulkUpdate(
        string userID,
        PreferenceBulkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a user's preferences for a specific subscription topic, resetting the
    /// topic to its effective default. This operation is idempotent: deleting a
    /// preference that does not exist succeeds with no error.
    /// </summary>
    Task DeleteTopic(
        PreferenceDeleteTopicParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteTopic(PreferenceDeleteTopicParams, CancellationToken)"/>
    Task DeleteTopic(
        string topicID,
        PreferenceDeleteTopicParams parameters,
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
    /// Returns a raw HTTP response for <c>get /users/{user_id}/preferences</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>put /users/{user_id}/preferences</c>, but is otherwise the
    /// same as <see cref="IPreferenceService.BulkReplace(PreferenceBulkReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceBulkReplaceResponse>> BulkReplace(
        PreferenceBulkReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="BulkReplace(PreferenceBulkReplaceParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceBulkReplaceResponse>> BulkReplace(
        string userID,
        PreferenceBulkReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /users/{user_id}/preferences</c>, but is otherwise the
    /// same as <see cref="IPreferenceService.BulkUpdate(PreferenceBulkUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceBulkUpdateResponse>> BulkUpdate(
        PreferenceBulkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="BulkUpdate(PreferenceBulkUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceBulkUpdateResponse>> BulkUpdate(
        string userID,
        PreferenceBulkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /users/{user_id}/preferences/{topic_id}</c>, but is otherwise the
    /// same as <see cref="IPreferenceService.DeleteTopic(PreferenceDeleteTopicParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> DeleteTopic(
        PreferenceDeleteTopicParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteTopic(PreferenceDeleteTopicParams, CancellationToken)"/>
    Task<HttpResponse> DeleteTopic(
        string topicID,
        PreferenceDeleteTopicParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /users/{user_id}/preferences/{topic_id}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>put /users/{user_id}/preferences/{topic_id}</c>, but is otherwise the
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
