using System.Threading.Tasks;
using TryCourier.Models;
using TryCourier.Models.Users.Preferences;

namespace TryCourier.Tests.Services.Users;

public class PreferenceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var preference = await this.client.Users.Preferences.Retrieve(
            "user_id",
            new(),
            TestContext.Current.CancellationToken
        );
        preference.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task BulkReplace_Works()
    {
        var response = await this.client.Users.Preferences.BulkReplace(
            "user_id",
            new()
            {
                Topics =
                [
                    new()
                    {
                        Status = Status.OptedIn,
                        TopicID = "pt_01kx4h2jdafq8bk996nn92357r",
                        CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                        HasCustomRouting = true,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task BulkUpdate_Works()
    {
        var response = await this.client.Users.Preferences.BulkUpdate(
            "user_id",
            new()
            {
                Topics =
                [
                    new()
                    {
                        Status = PreferenceBulkUpdateParamsTopicStatus.OptedIn,
                        TopicID = "pt_01kx4h2jdafq8bk996nn92357r",
                        CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                        HasCustomRouting = true,
                    },
                    new()
                    {
                        Status = PreferenceBulkUpdateParamsTopicStatus.OptedOut,
                        TopicID = "pt_01kx4h2jdafq8bk99eyt3dx43x",
                        CustomRouting = [ChannelClassification.DirectMessage],
                        HasCustomRouting = true,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DeleteTopic_Works()
    {
        await this.client.Users.Preferences.DeleteTopic(
            "topic_id",
            new() { UserID = "user_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveTopic_Works()
    {
        var response = await this.client.Users.Preferences.RetrieveTopic(
            "topic_id",
            new() { UserID = "user_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
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
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
