using System.Text.Json;
using Courier.Core;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandTemplate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandTemplate>(
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

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedBackgroundColor, deserialized.BackgroundColor);
        Assert.Equal(expectedBlocksBackgroundColor, deserialized.BlocksBackgroundColor);
        Assert.Equal(expectedFooter, deserialized.Footer);
        Assert.Equal(expectedHead, deserialized.Head);
        Assert.Equal(expectedHeader, deserialized.Header);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandTemplate { Enabled = true };

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
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandTemplate { Enabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandTemplate
        {
            Enabled = true,

            BackgroundColor = null,
            BlocksBackgroundColor = null,
            Footer = null,
            Head = null,
            Header = null,
            Width = null,
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
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandTemplate
        {
            Enabled = true,

            BackgroundColor = null,
            BlocksBackgroundColor = null,
            Footer = null,
            Head = null,
            Header = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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

        BrandTemplate copied = new(model);

        Assert.Equal(model, copied);
    }
}
