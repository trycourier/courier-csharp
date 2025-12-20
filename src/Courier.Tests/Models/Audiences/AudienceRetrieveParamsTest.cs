using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudienceRetrieveParams { AudienceID = "audience_id" };

        string expectedAudienceID = "audience_id";

        Assert.Equal(expectedAudienceID, parameters.AudienceID);
    }
}
