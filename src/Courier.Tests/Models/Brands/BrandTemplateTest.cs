using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandTemplateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandTemplate
        {
            Enabled = true,
            BackgroundColor = "backgroundColor",
            BlocksBackgroundColor = "blocksBackgroundColor",
            Footer = "footer",
            Head = "head",
            Header = "header",
            Width = "width",
        };

        bool expectedEnabled = true;
        string expectedBackgroundColor = "backgroundColor";
        string expectedBlocksBackgroundColor = "blocksBackgroundColor";
        string expectedFooter = "footer";
        string expectedHead = "head";
        string expectedHeader = "header";
        string expectedWidth = "width";

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedBackgroundColor, model.BackgroundColor);
        Assert.Equal(expectedBlocksBackgroundColor, model.BlocksBackgroundColor);
        Assert.Equal(expectedFooter, model.Footer);
        Assert.Equal(expectedHead, model.Head);
        Assert.Equal(expectedHeader, model.Header);
        Assert.Equal(expectedWidth, model.Width);
    }
}
