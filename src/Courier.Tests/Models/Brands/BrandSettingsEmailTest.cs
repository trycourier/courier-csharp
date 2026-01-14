using System.Text.Json;
using Courier.Core;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandSettingsEmail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandSettingsEmail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedFooter, deserialized.Footer);
        Assert.Equal(expectedHead, deserialized.Head);
        Assert.Equal(expectedHeader, deserialized.Header);
        Assert.Equal(expectedTemplateOverride, deserialized.TemplateOverride);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandSettingsEmail { };

        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Head);
        Assert.False(model.RawData.ContainsKey("head"));
        Assert.Null(model.Header);
        Assert.False(model.RawData.ContainsKey("header"));
        Assert.Null(model.TemplateOverride);
        Assert.False(model.RawData.ContainsKey("templateOverride"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandSettingsEmail { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandSettingsEmail
        {
            Footer = null,
            Head = null,
            Header = null,
            TemplateOverride = null,
        };

        Assert.Null(model.Footer);
        Assert.True(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Head);
        Assert.True(model.RawData.ContainsKey("head"));
        Assert.Null(model.Header);
        Assert.True(model.RawData.ContainsKey("header"));
        Assert.Null(model.TemplateOverride);
        Assert.True(model.RawData.ContainsKey("templateOverride"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandSettingsEmail
        {
            Footer = null,
            Head = null,
            Header = null,
            TemplateOverride = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateOverride>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedBackgroundColor, deserialized.BackgroundColor);
        Assert.Equal(expectedBlocksBackgroundColor, deserialized.BlocksBackgroundColor);
        Assert.Equal(expectedFooter, deserialized.Footer);
        Assert.Equal(expectedHead, deserialized.Head);
        Assert.Equal(expectedHeader, deserialized.Header);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedMjml, deserialized.Mjml);
        Assert.Equal(expectedFooterBackgroundColor, deserialized.FooterBackgroundColor);
        Assert.Equal(expectedFooterFullWidth, deserialized.FooterFullWidth);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateOverride
        {
            Enabled = true,
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
        };

        Assert.Null(model.BackgroundColor);
        Assert.False(model.RawData.ContainsKey("backgroundColor"));
        Assert.Null(model.BlocksBackgroundColor);
        Assert.False(model.RawData.ContainsKey("blocksBackgroundColor"));
        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Head);
        Assert.False(model.RawData.ContainsKey("head"));
        Assert.Null(model.Header);
        Assert.False(model.RawData.ContainsKey("header"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
        Assert.Null(model.FooterBackgroundColor);
        Assert.False(model.RawData.ContainsKey("footerBackgroundColor"));
        Assert.Null(model.FooterFullWidth);
        Assert.False(model.RawData.ContainsKey("footerFullWidth"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateOverride
        {
            Enabled = true,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateOverride
        {
            Enabled = true,
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

            BackgroundColor = null,
            BlocksBackgroundColor = null,
            Footer = null,
            Head = null,
            Header = null,
            Width = null,
            FooterBackgroundColor = null,
            FooterFullWidth = null,
        };

        Assert.Null(model.BackgroundColor);
        Assert.True(model.RawData.ContainsKey("backgroundColor"));
        Assert.Null(model.BlocksBackgroundColor);
        Assert.True(model.RawData.ContainsKey("blocksBackgroundColor"));
        Assert.Null(model.Footer);
        Assert.True(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Head);
        Assert.True(model.RawData.ContainsKey("head"));
        Assert.Null(model.Header);
        Assert.True(model.RawData.ContainsKey("header"));
        Assert.Null(model.Width);
        Assert.True(model.RawData.ContainsKey("width"));
        Assert.Null(model.FooterBackgroundColor);
        Assert.True(model.RawData.ContainsKey("footerBackgroundColor"));
        Assert.Null(model.FooterFullWidth);
        Assert.True(model.RawData.ContainsKey("footerFullWidth"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateOverride
        {
            Enabled = true,
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

            BackgroundColor = null,
            BlocksBackgroundColor = null,
            Footer = null,
            Head = null,
            Header = null,
            Width = null,
            FooterBackgroundColor = null,
            FooterFullWidth = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedMjml, deserialized.Mjml);
        Assert.Equal(expectedFooterBackgroundColor, deserialized.FooterBackgroundColor);
        Assert.Equal(expectedFooterFullWidth, deserialized.FooterFullWidth);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
        };

        Assert.Null(model.FooterBackgroundColor);
        Assert.False(model.RawData.ContainsKey("footerBackgroundColor"));
        Assert.Null(model.FooterFullWidth);
        Assert.False(model.RawData.ContainsKey("footerFullWidth"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            FooterBackgroundColor = null,
            FooterFullWidth = null,
        };

        Assert.Null(model.FooterBackgroundColor);
        Assert.True(model.RawData.ContainsKey("footerBackgroundColor"));
        Assert.Null(model.FooterFullWidth);
        Assert.True(model.RawData.ContainsKey("footerFullWidth"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

            FooterBackgroundColor = null,
            FooterFullWidth = null,
        };

        model.Validate();
    }
}
