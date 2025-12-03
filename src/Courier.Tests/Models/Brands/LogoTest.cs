using System.Text.Json;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class LogoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Logo { Href = "href", Image = "image" };

        string expectedHref = "href";
        string expectedImage = "image";

        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedImage, model.Image);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Logo { Href = "href", Image = "image" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Logo>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Logo { Href = "href", Image = "image" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Logo>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "href";
        string expectedImage = "image";

        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedImage, deserialized.Image);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Logo { Href = "href", Image = "image" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Logo { };

        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Image);
        Assert.False(model.RawData.ContainsKey("image"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Logo { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Logo { Href = null, Image = null };

        Assert.Null(model.Href);
        Assert.True(model.RawData.ContainsKey("href"));
        Assert.Null(model.Image);
        Assert.True(model.RawData.ContainsKey("image"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Logo { Href = null, Image = null };

        model.Validate();
    }
}
