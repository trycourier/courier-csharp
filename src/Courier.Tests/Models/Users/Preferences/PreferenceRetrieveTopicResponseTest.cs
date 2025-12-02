using Courier.Models;
using Courier.Models.Users.Preferences;

namespace Courier.Tests.Models.Users.Preferences;

public class PreferenceRetrieveTopicResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceRetrieveTopicResponse
        {
            Topic = new()
            {
                DefaultStatus = PreferenceStatus.OptedIn,
                Status = PreferenceStatus.OptedIn,
                TopicID = "topic_id",
                TopicName = "topic_name",
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
            },
        };

        TopicPreference expectedTopic = new()
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        Assert.Equal(expectedTopic, model.Topic);
    }
}
