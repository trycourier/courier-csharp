using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class EmailHeaderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailHeader
        {
            Logo = new() { Href = "href", Image = "image" },
            BarColor = "barColor",
            InheritDefault = true,
        };

        Logo expectedLogo = new() { Href = "href", Image = "image" };
        string expectedBarColor = "barColor";
        bool expectedInheritDefault = true;

        Assert.Equal(expectedLogo, model.Logo);
        Assert.Equal(expectedBarColor, model.BarColor);
        Assert.Equal(expectedInheritDefault, model.InheritDefault);
    }
}
