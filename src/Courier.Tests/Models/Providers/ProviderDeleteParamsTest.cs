using System;
using Courier.Models.Providers;

namespace Courier.Tests.Models.Providers;

public class ProviderDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProviderDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProviderDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/providers/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProviderDeleteParams { ID = "id" };

        ProviderDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
