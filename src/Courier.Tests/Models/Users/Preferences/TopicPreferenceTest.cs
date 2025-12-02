using System.Collections.Generic;
using Courier.Core;
using Courier.Models;
using Courier.Models.Users.Preferences;

namespace Courier.Tests.Models.Users.Preferences;

public class TopicPreferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopicPreference
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        ApiEnum<string, PreferenceStatus> expectedDefaultStatus = PreferenceStatus.OptedIn;
        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        string expectedTopicID = "topic_id";
        string expectedTopicName = "topic_name";
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;

        Assert.Equal(expectedDefaultStatus, model.DefaultStatus);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTopicID, model.TopicID);
        Assert.Equal(expectedTopicName, model.TopicName);
        Assert.Equal(expectedCustomRouting.Count, model.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], model.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
    }
}
