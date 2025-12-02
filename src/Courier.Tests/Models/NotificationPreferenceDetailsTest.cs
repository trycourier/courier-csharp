using System.Collections.Generic;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class NotificationPreferenceDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationPreferenceDetails
        {
            Status = PreferenceStatus.OptedIn,
            ChannelPreferences = [new(ChannelClassification.DirectMessage)],
            Rules = [new() { Until = "until", Start = "start" }],
        };

        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        List<ChannelPreference> expectedChannelPreferences =
        [
            new(ChannelClassification.DirectMessage),
        ];
        List<Rule> expectedRules = [new() { Until = "until", Start = "start" }];

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedChannelPreferences.Count, model.ChannelPreferences.Count);
        for (int i = 0; i < expectedChannelPreferences.Count; i++)
        {
            Assert.Equal(expectedChannelPreferences[i], model.ChannelPreferences[i]);
        }
        Assert.Equal(expectedRules.Count, model.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], model.Rules[i]);
        }
    }
}
