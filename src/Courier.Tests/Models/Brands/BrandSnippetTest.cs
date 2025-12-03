using System.Text.Json;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandSnippetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandSnippet { Name = "name", Value = "value" };

        string expectedName = "name";
        string expectedValue = "value";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandSnippet { Name = "name", Value = "value" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrandSnippet>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandSnippet { Name = "name", Value = "value" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrandSnippet>(json);
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedValue = "value";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandSnippet { Name = "name", Value = "value" };

        model.Validate();
    }
}
