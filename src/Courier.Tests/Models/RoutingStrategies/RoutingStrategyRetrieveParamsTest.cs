using System;
using Courier.Models.RoutingStrategies;

namespace Courier.Tests.Models.RoutingStrategies;

public class RoutingStrategyRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RoutingStrategyRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        RoutingStrategyRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/routing-strategies/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RoutingStrategyRetrieveParams { ID = "id" };

        RoutingStrategyRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
