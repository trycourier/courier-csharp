using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandRetrieveParams { BrandID = "brand_id" };

        string expectedBrandID = "brand_id";

        Assert.Equal(expectedBrandID, parameters.BrandID);
    }
}
