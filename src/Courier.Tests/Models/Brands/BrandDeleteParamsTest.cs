using System;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandDeleteParams { BrandID = "brand_id" };

        string expectedBrandID = "brand_id";

        Assert.Equal(expectedBrandID, parameters.BrandID);
    }

    [Fact]
    public void Url_Works()
    {
        BrandDeleteParams parameters = new() { BrandID = "brand_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/brands/brand_id"), url);
    }
}
