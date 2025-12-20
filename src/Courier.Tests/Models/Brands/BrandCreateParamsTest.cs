using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandCreateParams
        {
            Name = "name",
            ID = "id",
            Settings = new()
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
            },
            Snippets = new() { Items = [new() { Name = "name", Value = "value" }] },
        };

        string expectedName = "name";
        string expectedID = "id";
        BrandSettings expectedSettings = new()
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
        BrandSnippets expectedSnippets = new()
        {
            Items = [new() { Name = "name", Value = "value" }],
        };

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSettings, parameters.Settings);
        Assert.Equal(expectedSnippets, parameters.Snippets);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandCreateParams { Name = "name" };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Settings);
        Assert.False(parameters.RawBodyData.ContainsKey("settings"));
        Assert.Null(parameters.Snippets);
        Assert.False(parameters.RawBodyData.ContainsKey("snippets"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BrandCreateParams
        {
            Name = "name",

            ID = null,
            Settings = null,
            Snippets = null,
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Settings);
        Assert.False(parameters.RawBodyData.ContainsKey("settings"));
        Assert.Null(parameters.Snippets);
        Assert.False(parameters.RawBodyData.ContainsKey("snippets"));
    }
}
