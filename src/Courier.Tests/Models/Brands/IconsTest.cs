using System.Text.Json;
using Courier.Core;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class IconsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Icons { Bell = "bell", Message = "message" };

        string expectedBell = "bell";
        string expectedMessage = "message";

        Assert.Equal(expectedBell, model.Bell);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Icons { Bell = "bell", Message = "message" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Icons>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Icons { Bell = "bell", Message = "message" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Icons>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedBell = "bell";
        string expectedMessage = "message";

        Assert.Equal(expectedBell, deserialized.Bell);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Icons { Bell = "bell", Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Icons { };

        Assert.Null(model.Bell);
        Assert.False(model.RawData.ContainsKey("bell"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Icons { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Icons { Bell = null, Message = null };

        Assert.Null(model.Bell);
        Assert.True(model.RawData.ContainsKey("bell"));
        Assert.Null(model.Message);
        Assert.True(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Icons { Bell = null, Message = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Icons { Bell = "bell", Message = "message" };

        Icons copied = new(model);

        Assert.Equal(model, copied);
    }
}
