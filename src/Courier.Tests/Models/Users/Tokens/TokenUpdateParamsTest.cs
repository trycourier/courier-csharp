using System.Text.Json;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class PatchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Patch
        {
            Op = "op",
            Path = "path",
            Value = "value",
        };

        string expectedOp = "op";
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOp, model.Op);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Patch
        {
            Op = "op",
            Path = "path",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Patch>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Patch
        {
            Op = "op",
            Path = "path",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Patch>(element);
        Assert.NotNull(deserialized);

        string expectedOp = "op";
        string expectedPath = "path";
        string expectedValue = "value";

        Assert.Equal(expectedOp, deserialized.Op);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Patch
        {
            Op = "op",
            Path = "path",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Patch { Op = "op", Path = "path" };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Patch { Op = "op", Path = "path" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Patch
        {
            Op = "op",
            Path = "path",

            Value = null,
        };

        Assert.Null(model.Value);
        Assert.True(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Patch
        {
            Op = "op",
            Path = "path",

            Value = null,
        };

        model.Validate();
    }
}
