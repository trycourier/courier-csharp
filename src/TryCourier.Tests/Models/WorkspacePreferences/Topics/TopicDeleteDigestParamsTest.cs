using System;
using TryCourier.Models.WorkspacePreferences.Topics;

namespace TryCourier.Tests.Models.WorkspacePreferences.Topics;

public class TopicDeleteDigestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopicDeleteDigestParams
        {
            SectionID = "section_id",
            TopicID = "topic_id",
        };

        string expectedSectionID = "section_id";
        string expectedTopicID = "topic_id";

        Assert.Equal(expectedSectionID, parameters.SectionID);
        Assert.Equal(expectedTopicID, parameters.TopicID);
    }

    [Fact]
    public void Url_Works()
    {
        TopicDeleteDigestParams parameters = new()
        {
            SectionID = "section_id",
            TopicID = "topic_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.courier.com/preferences/sections/section_id/topics/topic_id/digest"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TopicDeleteDigestParams
        {
            SectionID = "section_id",
            TopicID = "topic_id",
        };

        TopicDeleteDigestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
