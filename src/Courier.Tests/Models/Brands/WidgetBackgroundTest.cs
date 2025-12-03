using System.Text.Json;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class WidgetBackgroundTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WidgetBackground { BottomColor = "bottomColor", TopColor = "topColor" };

        string expectedBottomColor = "bottomColor";
        string expectedTopColor = "topColor";

        Assert.Equal(expectedBottomColor, model.BottomColor);
        Assert.Equal(expectedTopColor, model.TopColor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WidgetBackground { BottomColor = "bottomColor", TopColor = "topColor" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WidgetBackground>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WidgetBackground { BottomColor = "bottomColor", TopColor = "topColor" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WidgetBackground>(json);
        Assert.NotNull(deserialized);

        string expectedBottomColor = "bottomColor";
        string expectedTopColor = "topColor";

        Assert.Equal(expectedBottomColor, deserialized.BottomColor);
        Assert.Equal(expectedTopColor, deserialized.TopColor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WidgetBackground { BottomColor = "bottomColor", TopColor = "topColor" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WidgetBackground { };

        Assert.Null(model.BottomColor);
        Assert.False(model.RawData.ContainsKey("bottomColor"));
        Assert.Null(model.TopColor);
        Assert.False(model.RawData.ContainsKey("topColor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WidgetBackground { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WidgetBackground { BottomColor = null, TopColor = null };

        Assert.Null(model.BottomColor);
        Assert.True(model.RawData.ContainsKey("bottomColor"));
        Assert.Null(model.TopColor);
        Assert.True(model.RawData.ContainsKey("topColor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WidgetBackground { BottomColor = null, TopColor = null };

        model.Validate();
    }
}
