using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Users.Preferences;

namespace Courier.Services.Users.Preferences;

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
    /// Fetch user preferences for a specific subscription topic.
    /// </summary>
    Task<PreferenceRetrieveTopicResponse> RetrieveTopic(
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
}
