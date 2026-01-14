using System.Text.Json;
using Courier.Core;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class EmailHeaderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailHeader
        {
            Logo = new() { Href = "href", Image = "image" },
            BarColor = "barColor",
            InheritDefault = true,
        };

        Logo expectedLogo = new() { Href = "href", Image = "image" };
        string expectedBarColor = "barColor";
        bool expectedInheritDefault = true;

        Assert.Equal(expectedLogo, model.Logo);
        Assert.Equal(expectedBarColor, model.BarColor);
        Assert.Equal(expectedInheritDefault, model.InheritDefault);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailHeader
        {
            Logo = new() { Href = "href", Image = "image" },
            BarColor = "barColor",
            InheritDefault = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailHeader>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailHeader
        {
            Logo = new() { Href = "href", Image = "image" },
            BarColor = "barColor",
            InheritDefault = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailHeader>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Logo expectedLogo = new() { Href = "href", Image = "image" };
        string expectedBarColor = "barColor";
        bool expectedInheritDefault = true;

        Assert.Equal(expectedLogo, deserialized.Logo);
        Assert.Equal(expectedBarColor, deserialized.BarColor);
        Assert.Equal(expectedInheritDefault, deserialized.InheritDefault);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailHeader
        {
            Logo = new() { Href = "href", Image = "image" },
            BarColor = "barColor",
            InheritDefault = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EmailHeader
        {
            Logo = new() { Href = "href", Image = "image" },
        };

        Assert.Null(model.BarColor);
        Assert.False(model.RawData.ContainsKey("barColor"));
        Assert.Null(model.InheritDefault);
        Assert.False(model.RawData.ContainsKey("inheritDefault"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EmailHeader
        {
            Logo = new() { Href = "href", Image = "image" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EmailHeader
        {
            Logo = new() { Href = "href", Image = "image" },

            BarColor = null,
            InheritDefault = null,
        };

        Assert.Null(model.BarColor);
        Assert.True(model.RawData.ContainsKey("barColor"));
        Assert.Null(model.InheritDefault);
        Assert.True(model.RawData.ContainsKey("inheritDefault"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EmailHeader
        {
            Logo = new() { Href = "href", Image = "image" },

            BarColor = null,
            InheritDefault = null,
        };

        model.Validate();
    }
}
