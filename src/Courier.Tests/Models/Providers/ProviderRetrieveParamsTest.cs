using System;
using Courier.Models.Providers;

namespace Courier.Tests.Models.Providers;

public class ProviderRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProviderRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProviderRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/providers/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProviderRetrieveParams { ID = "id" };

        ProviderRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
