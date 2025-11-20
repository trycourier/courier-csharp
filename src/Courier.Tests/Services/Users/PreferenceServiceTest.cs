using System.Threading.Tasks;
using Courier.Models;

namespace Courier.Tests.Services.Users;

public class PreferenceServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var preference = await this.client.Users.Preferences.Retrieve("user_id");
        preference.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveTopic_Works()
    {
        var response = await this.client.Users.Preferences.RetrieveTopic(
            "topic_id",
            new() { UserID = "user_id" }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UpdateOrCreateTopic_Works()
    {
        var response = await this.client.Users.Preferences.UpdateOrCreateTopic(
            "topic_id",
            new()
            {
                UserID = "user_id",
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
