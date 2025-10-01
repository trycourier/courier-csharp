using System.Threading.Tasks;
using Courier.Models.Users.Preferences;

namespace Courier.Services.Users.Preferences;

public interface IPreferenceService
{
    /// <summary>
    /// Fetch all user preferences.
    /// </summary>
    Task<PreferenceRetrieveResponse> Retrieve(PreferenceRetrieveParams parameters);

    /// <summary>
    /// Fetch user preferences for a specific subscription topic.
    /// </summary>
    Task<PreferenceRetrieveTopicResponse> RetrieveTopic(PreferenceRetrieveTopicParams parameters);

    /// <summary>
    /// Update or Create user preferences for a specific subscription topic.
    /// </summary>
    Task<PreferenceUpdateOrCreateTopicResponse> UpdateOrCreateTopic(
        PreferenceUpdateOrCreateTopicParams parameters
    );
}
