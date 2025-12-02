using Courier.Models;

namespace Courier.Tests.Models;

public class UtmTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Utm
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        string expectedCampaign = "campaign";
        string expectedContent = "content";
        string expectedMedium = "medium";
        string expectedSource = "source";
        string expectedTerm = "term";

        Assert.Equal(expectedCampaign, model.Campaign);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedMedium, model.Medium);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTerm, model.Term);
    }
}
