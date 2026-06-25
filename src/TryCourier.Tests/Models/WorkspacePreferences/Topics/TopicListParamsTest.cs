using System;
using TryCourier.Models.WorkspacePreferences.Topics;

namespace TryCourier.Tests.Models.WorkspacePreferences.Topics;

public class TopicListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopicListParams { SectionID = "section_id" };

        string expectedSectionID = "section_id";

        Assert.Equal(expectedSectionID, parameters.SectionID);
    }

    [Fact]
    public void Url_Works()
    {
        TopicListParams parameters = new() { SectionID = "section_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/preferences/sections/section_id/topics"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TopicListParams { SectionID = "section_id" };

        TopicListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
