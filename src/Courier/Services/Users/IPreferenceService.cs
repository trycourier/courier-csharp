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
    IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Fetch all user preferences.
    /// </summary>
    Task<PreferenceRetrieveResponse> Retrieve(
        PreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch all user preferences.
    /// </summary>
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

    /// <summary>
    /// Fetch user preferences for a specific subscription topic.
    /// </summary>
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

    /// <summary>
    /// Update or Create user preferences for a specific subscription topic.
    /// </summary>
    Task<PreferenceUpdateOrCreateTopicResponse> UpdateOrCreateTopic(
        string topicID,
        PreferenceUpdateOrCreateTopicParams parameters,
        CancellationToken cancellationToken = default
    );
}
