using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudienceDeleteParams { AudienceID = "audience_id" };

        string expectedAudienceID = "audience_id";

        Assert.Equal(expectedAudienceID, parameters.AudienceID);
    }
}
