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
}
