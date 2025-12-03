using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalContentSugarTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalContentSugar { Body = "body", Title = "title" };

        string expectedBody = "body";
        string expectedTitle = "title";

        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalContentSugar { Body = "body", Title = "title" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ElementalContentSugar>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalContentSugar { Body = "body", Title = "title" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ElementalContentSugar>(json);
        Assert.NotNull(deserialized);

        string expectedBody = "body";
        string expectedTitle = "title";

        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalContentSugar { Body = "body", Title = "title" };

        model.Validate();
    }
}
