using System;
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

    [Fact]
    public void Url_Works()
    {
        AudienceRetrieveParams parameters = new() { AudienceID = "audience_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/audiences/audience_id"), url);
    }
}
