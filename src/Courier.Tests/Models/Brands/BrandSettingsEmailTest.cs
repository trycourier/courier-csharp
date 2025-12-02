using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandSettingsEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandSettingsEmail
        {
            Footer = new() { Content = "content", InheritDefault = true },
            Head = new() { InheritDefault = true, Content = "content" },
            Header = new()
            {
                Logo = new() { Href = "href", Image = "image" },
                BarColor = "barColor",
                InheritDefault = true,
            },
            TemplateOverride = new()
            {
                Enabled = true,
                BackgroundColor = "backgroundColor",
                BlocksBackgroundColor = "blocksBackgroundColor",
                Footer = "footer",
                Head = "head",
                Header = "header",
                Width = "width",
                Mjml = new()
                {
                    Enabled = true,
                    BackgroundColor = "backgroundColor",
                    BlocksBackgroundColor = "blocksBackgroundColor",
                    Footer = "footer",
                    Head = "head",
                    Header = "header",
                    Width = "width",
                },
                FooterBackgroundColor = "footerBackgroundColor",
                FooterFullWidth = true,
            },
        };

        EmailFooter expectedFooter = new() { Content = "content", InheritDefault = true };
        EmailHead expectedHead = new() { InheritDefault = true, Content = "content" };
        EmailHeader expectedHeader = new()
        {
            Logo = new() { Href = "href", Image = "image" },
            BarColor = "barColor",
            InheritDefault = true,
        };
        TemplateOverride expectedTemplateOverride = new()
        {
            Enabled = true,
            BackgroundColor = "backgroundColor",
            BlocksBackgroundColor = "blocksBackgroundColor",
            Footer = "footer",
            Head = "head",
            Header = "header",
            Width = "width",
            Mjml = new()
            {
                Enabled = true,
                BackgroundColor = "backgroundColor",
                BlocksBackgroundColor = "blocksBackgroundColor",
                Footer = "footer",
                Head = "head",
                Header = "header",
                Width = "width",
            },
            FooterBackgroundColor = "footerBackgroundColor",
            FooterFullWidth = true,
        };

        Assert.Equal(expectedFooter, model.Footer);
        Assert.Equal(expectedHead, model.Head);
        Assert.Equal(expectedHeader, model.Header);
        Assert.Equal(expectedTemplateOverride, model.TemplateOverride);
    }
}

public class TemplateOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateOverride
        {
            Enabled = true,
            BackgroundColor = "backgroundColor",
            BlocksBackgroundColor = "blocksBackgroundColor",
            Footer = "footer",
            Head = "head",
            Header = "header",
            Width = "width",
            Mjml = new()
            {
                Enabled = true,
                BackgroundColor = "backgroundColor",
                BlocksBackgroundColor = "blocksBackgroundColor",
                Footer = "footer",
                Head = "head",
                Header = "header",
                Width = "width",
            },
            FooterBackgroundColor = "footerBackgroundColor",
            FooterFullWidth = true,
        };

        bool expectedEnabled = true;
        string expectedBackgroundColor = "backgroundColor";
        string expectedBlocksBackgroundColor = "blocksBackgroundColor";
        string expectedFooter = "footer";
        string expectedHead = "head";
        string expectedHeader = "header";
        string expectedWidth = "width";
        BrandTemplate expectedMjml = new()
        {
            Enabled = true,
            BackgroundColor = "backgroundColor",
            BlocksBackgroundColor = "blocksBackgroundColor",
            Footer = "footer",
            Head = "head",
            Header = "header",
            Width = "width",
        };
        string expectedFooterBackgroundColor = "footerBackgroundColor";
        bool expectedFooterFullWidth = true;

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedBackgroundColor, model.BackgroundColor);
        Assert.Equal(expectedBlocksBackgroundColor, model.BlocksBackgroundColor);
        Assert.Equal(expectedFooter, model.Footer);
        Assert.Equal(expectedHead, model.Head);
        Assert.Equal(expectedHeader, model.Header);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedMjml, model.Mjml);
        Assert.Equal(expectedFooterBackgroundColor, model.FooterBackgroundColor);
        Assert.Equal(expectedFooterFullWidth, model.FooterFullWidth);
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            Mjml = new()
            {
                Enabled = true,
                BackgroundColor = "backgroundColor",
                BlocksBackgroundColor = "blocksBackgroundColor",
                Footer = "footer",
                Head = "head",
                Header = "header",
                Width = "width",
            },
            FooterBackgroundColor = "footerBackgroundColor",
            FooterFullWidth = true,
        };

        BrandTemplate expectedMjml = new()
        {
            Enabled = true,
            BackgroundColor = "backgroundColor",
            BlocksBackgroundColor = "blocksBackgroundColor",
            Footer = "footer",
            Head = "head",
            Header = "header",
            Width = "width",
        };
        string expectedFooterBackgroundColor = "footerBackgroundColor";
        bool expectedFooterFullWidth = true;

        Assert.Equal(expectedMjml, model.Mjml);
        Assert.Equal(expectedFooterBackgroundColor, model.FooterBackgroundColor);
        Assert.Equal(expectedFooterFullWidth, model.FooterFullWidth);
    }
}
