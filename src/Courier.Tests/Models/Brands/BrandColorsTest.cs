using System.Text.Json;
using Courier.Core;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandColorsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandColors { Primary = "primary", Secondary = "secondary" };

        string expectedPrimary = "primary";
        string expectedSecondary = "secondary";

        Assert.Equal(expectedPrimary, model.Primary);
        Assert.Equal(expectedSecondary, model.Secondary);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandColors { Primary = "primary", Secondary = "secondary" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandColors>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandColors { Primary = "primary", Secondary = "secondary" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandColors>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPrimary = "primary";
        string expectedSecondary = "secondary";

        Assert.Equal(expectedPrimary, deserialized.Primary);
        Assert.Equal(expectedSecondary, deserialized.Secondary);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandColors { Primary = "primary", Secondary = "secondary" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandColors { };

        Assert.Null(model.Primary);
        Assert.False(model.RawData.ContainsKey("primary"));
        Assert.Null(model.Secondary);
        Assert.False(model.RawData.ContainsKey("secondary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandColors { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrandColors
        {
            // Null should be interpreted as omitted for these properties
            Primary = null,
            Secondary = null,
        };

        Assert.Null(model.Primary);
        Assert.False(model.RawData.ContainsKey("primary"));
        Assert.Null(model.Secondary);
        Assert.False(model.RawData.ContainsKey("secondary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandColors
        {
            // Null should be interpreted as omitted for these properties
            Primary = null,
            Secondary = null,
        };

        model.Validate();
    }
}
