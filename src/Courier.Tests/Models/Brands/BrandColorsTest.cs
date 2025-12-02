using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandColorsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandColors { Primary = "primary", Secondary = "secondary" };

        string expectedPrimary = "primary";
        string expectedSecondary = "secondary";

        Assert.Equal(expectedPrimary, model.Primary);
        Assert.Equal(expectedSecondary, model.Secondary);
    }
}
