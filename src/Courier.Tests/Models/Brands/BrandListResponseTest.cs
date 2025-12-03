using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Name = "name",
                    Updated = 0,
                    Published = 0,
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
                            WidgetBackground = new()
                            {
                                BottomColor = "bottomColor",
                                TopColor = "topColor",
                            },
                            BorderRadius = "borderRadius",
                            DisableMessageIcon = true,
                            FontFamily = "fontFamily",
                            Placement = Placement.Top,
                        },
                    },
                    Snippets = new() { Items = [new() { Name = "name", Value = "value" }] },
                    Version = "version",
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Brand> expectedResults =
        [
            new()
            {
                ID = "id",
                Created = 0,
                Name = "name",
                Updated = 0,
                Published = 0,
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
                        WidgetBackground = new()
                        {
                            BottomColor = "bottomColor",
                            TopColor = "topColor",
                        },
                        BorderRadius = "borderRadius",
                        DisableMessageIcon = true,
                        FontFamily = "fontFamily",
                        Placement = Placement.Top,
                    },
                },
                Snippets = new() { Items = [new() { Name = "name", Value = "value" }] },
                Version = "version",
            },
        ];

        Assert.Equal(expectedPaging, model.Paging);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Name = "name",
                    Updated = 0,
                    Published = 0,
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
                            WidgetBackground = new()
                            {
                                BottomColor = "bottomColor",
                                TopColor = "topColor",
                            },
                            BorderRadius = "borderRadius",
                            DisableMessageIcon = true,
                            FontFamily = "fontFamily",
                            Placement = Placement.Top,
                        },
                    },
                    Snippets = new() { Items = [new() { Name = "name", Value = "value" }] },
                    Version = "version",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrandListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Name = "name",
                    Updated = 0,
                    Published = 0,
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
                            WidgetBackground = new()
                            {
                                BottomColor = "bottomColor",
                                TopColor = "topColor",
                            },
                            BorderRadius = "borderRadius",
                            DisableMessageIcon = true,
                            FontFamily = "fontFamily",
                            Placement = Placement.Top,
                        },
                    },
                    Snippets = new() { Items = [new() { Name = "name", Value = "value" }] },
                    Version = "version",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrandListResponse>(json);
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Brand> expectedResults =
        [
            new()
            {
                ID = "id",
                Created = 0,
                Name = "name",
                Updated = 0,
                Published = 0,
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
                        WidgetBackground = new()
                        {
                            BottomColor = "bottomColor",
                            TopColor = "topColor",
                        },
                        BorderRadius = "borderRadius",
                        DisableMessageIcon = true,
                        FontFamily = "fontFamily",
                        Placement = Placement.Top,
                    },
                },
                Snippets = new() { Items = [new() { Name = "name", Value = "value" }] },
                Version = "version",
            },
        ];

        Assert.Equal(expectedPaging, deserialized.Paging);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Name = "name",
                    Updated = 0,
                    Published = 0,
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
                            WidgetBackground = new()
                            {
                                BottomColor = "bottomColor",
                                TopColor = "topColor",
                            },
                            BorderRadius = "borderRadius",
                            DisableMessageIcon = true,
                            FontFamily = "fontFamily",
                            Placement = Placement.Top,
                        },
                    },
                    Snippets = new() { Items = [new() { Name = "name", Value = "value" }] },
                    Version = "version",
                },
            ],
        };

        model.Validate();
    }
}
