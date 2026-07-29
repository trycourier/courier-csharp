using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Users.Preferences;

namespace TryCourier.Services.Users;

/// <summary>
/// Read and write a single user's notification preferences, per topic and per channel.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Returns a user's preference overrides with paging, one entry per subscription
    /// topic they have set a choice for.
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
    /// Replaces a user's entire set of preference overrides. Any topic you leave out is
    /// reset to its default, so send the full set rather than a subset.
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
    /// Adds or updates a user's preferences for several subscription topics at once.
    /// Topics you leave out keep whatever they were set to before.
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
    /// Removes a user's override for one subscription topic, resetting it to the
    /// effective default from the tenant or workspace.
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
    /// Returns a user's opt-in status and channel choices for one subscription topic,
    /// or the effective default if they have set no override.
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
    /// Sets a user's opt-in status and channel choices for one subscription topic,
    /// overriding the tenant default for that topic only.
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
