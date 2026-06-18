using System;
using TryCourier.Models.Brands;

namespace TryCourier.Tests.Models.Brands;

public class BrandCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandCreateParams
        {
            Name = "My Brand",
            Settings = new()
            {
                Colors = new() { Primary = "#9D3789", Secondary = "#FFFFFF" },
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
            ID = "id",
            Snippets = new() { Items = [new() { Name = "name", Value = "value" }] },
        };

        string expectedName = "My Brand";
        BrandSettings expectedSettings = new()
        {
            Colors = new() { Primary = "#9D3789", Secondary = "#FFFFFF" },
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
        string expectedID = "id";
        BrandSnippets expectedSnippets = new()
        {
            Items = [new() { Name = "name", Value = "value" }],
        };

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSettings, parameters.Settings);
        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSnippets, parameters.Snippets);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandCreateParams
        {
            Name = "My Brand",
            Settings = new()
            {
                Colors = new() { Primary = "#9D3789", Secondary = "#FFFFFF" },
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
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Snippets);
        Assert.False(parameters.RawBodyData.ContainsKey("snippets"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BrandCreateParams
        {
            Name = "My Brand",
            Settings = new()
            {
                Colors = new() { Primary = "#9D3789", Secondary = "#FFFFFF" },
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

            ID = null,
            Snippets = null,
        };

        Assert.Null(parameters.ID);
        Assert.True(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Snippets);
        Assert.True(parameters.RawBodyData.ContainsKey("snippets"));
    }

    [Fact]
    public void Url_Works()
    {
        BrandCreateParams parameters = new()
        {
            Name = "My Brand",
            Settings = new()
            {
                Colors = new() { Primary = "#9D3789", Secondary = "#FFFFFF" },
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
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/brands"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandCreateParams
        {
            Name = "My Brand",
            Settings = new()
            {
                Colors = new() { Primary = "#9D3789", Secondary = "#FFFFFF" },
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
            ID = "id",
            Snippets = new() { Items = [new() { Name = "name", Value = "value" }] },
        };

        BrandCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
