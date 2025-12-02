using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class LogoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Logo { Href = "href", Image = "image" };

        string expectedHref = "href";
        string expectedImage = "image";

        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedImage, model.Image);
    }
}
