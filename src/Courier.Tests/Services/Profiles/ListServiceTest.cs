using System.Collections.Generic;
using System.Threading.Tasks;
using Courier.Models;

namespace Courier.Tests.Services.Profiles;

public class ListServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var list = await this.client.Profiles.Lists.Retrieve("user_id");
        list.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        var list = await this.client.Profiles.Lists.Delete("user_id");
        list.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Subscribe_Works()
    {
        var response = await this.client.Profiles.Lists.Subscribe(
            "user_id",
            new()
            {
                Lists =
                [
                    new()
                    {
                        ListID = "listId",
                        Preferences = new()
                        {
                            Categories = new Dictionary<string, NotificationPreferenceDetails>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                    }
                                },
                            },
                            Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(ChannelClassification.DirectMessage),
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
