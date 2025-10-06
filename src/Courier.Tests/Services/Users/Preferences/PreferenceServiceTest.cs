using System.Threading.Tasks;
using Courier.Models.Tenants.DefaultPreferences.Items;
using Courier.Models.Users.Preferences;

namespace Courier.Tests.Services.Users.Preferences;

public class PreferenceServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var preference = await this.client.Users.Preferences.Retrieve(new() { UserID = "user_id" });
        preference.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveTopic_Works()
    {
        var response = await this.client.Users.Preferences.RetrieveTopic(
            new() { UserID = "user_id", TopicID = "topic_id" }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UpdateOrCreateTopic_Works()
    {
        var response = await this.client.Users.Preferences.UpdateOrCreateTopic(
            new()
            {
                UserID = "user_id",
                TopicID = "topic_id",
                Topic = new()
                {
                    Status = PreferenceStatus.OptedIn,
                    CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                    HasCustomRouting = true,
                },
            }
        );
        response.Validate();
    }
}
