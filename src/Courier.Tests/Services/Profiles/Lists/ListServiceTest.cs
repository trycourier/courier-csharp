using System.Collections.Generic;
using System.Threading.Tasks;
using Models = Courier.Models;

namespace Courier.Tests.Services.Profiles.Lists;

public class ListServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var list = await this.client.Profiles.Lists.Retrieve(new() { UserID = "user_id" });
        list.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var list = await this.client.Profiles.Lists.Delete(new() { UserID = "user_id" });
        list.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Subscribe_Works()
    {
        var response = await this.client.Profiles.Lists.Subscribe(
            new()
            {
                UserID = "user_id",
                Lists =
                [
                    new()
                    {
                        ListID = "listId",
                        Preferences = new()
                        {
                            Categories = new Dictionary<
                                string,
                                Models::NotificationPreferenceDetails
                            >()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = Models::PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(Models::ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                    }
                                },
                            },
                            Notifications = new Dictionary<
                                string,
                                Models::NotificationPreferenceDetails
                            >()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = Models::PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(Models::ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                    }
                                },
                            },
                        },
                    },
                ],
            }
        );
        response.Validate();
    }
}
