using System;
using TryCourier.Models.PreferenceSections.Topics;

namespace TryCourier.Tests.Models.PreferenceSections.Topics;

public class TopicRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopicRetrieveParams { SectionID = "section_id", TopicID = "topic_id" };

        string expectedSectionID = "section_id";
        string expectedTopicID = "topic_id";

        Assert.Equal(expectedSectionID, parameters.SectionID);
        Assert.Equal(expectedTopicID, parameters.TopicID);
    }

    [Fact]
    public void Url_Works()
    {
        TopicRetrieveParams parameters = new() { SectionID = "section_id", TopicID = "topic_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/preferences/sections/section_id/topics/topic_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TopicRetrieveParams { SectionID = "section_id", TopicID = "topic_id" };

        TopicRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
