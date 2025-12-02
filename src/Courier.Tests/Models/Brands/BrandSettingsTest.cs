using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandSettings
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Email = new()
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
            },
            Inapp = new()
            {
                Colors = new() { Primary = "primary", Secondary = "secondary" },
                Icons = new() { Bell = "bell", Message = "message" },
                WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
                BorderRadius = "borderRadius",
                DisableMessageIcon = true,
                FontFamily = "fontFamily",
                Placement = Placement.Top,
            },
        };

        BrandColors expectedColors = new() { Primary = "primary", Secondary = "secondary" };
        BrandSettingsEmail expectedEmail = new()
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
        BrandSettingsInApp expectedInapp = new()
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Icons = new() { Bell = "bell", Message = "message" },
            WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
            BorderRadius = "borderRadius",
            DisableMessageIcon = true,
            FontFamily = "fontFamily",
            Placement = Placement.Top,
        };

        Assert.Equal(expectedColors, model.Colors);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedInapp, model.Inapp);
    }
}
