using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrandSettings>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrandSettings>(element);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedColors, deserialized.Colors);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedInapp, deserialized.Inapp);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandSettings { };

        Assert.Null(model.Colors);
        Assert.False(model.RawData.ContainsKey("colors"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Inapp);
        Assert.False(model.RawData.ContainsKey("inapp"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandSettings { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandSettings
        {
            Colors = null,
            Email = null,
            Inapp = null,
        };

        Assert.Null(model.Colors);
        Assert.True(model.RawData.ContainsKey("colors"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Inapp);
        Assert.True(model.RawData.ContainsKey("inapp"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandSettings
        {
            Colors = null,
            Email = null,
            Inapp = null,
        };

        model.Validate();
    }
}
