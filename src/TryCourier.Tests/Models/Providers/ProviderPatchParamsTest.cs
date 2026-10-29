using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Providers;

namespace TryCourier.Tests.Models.Providers;

public class ProviderPatchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProviderPatchParams
        {
            ID = "id",
            Patch =
            [
                new()
                {
                    Op = Op.Replace,
                    Path = "/title",
                    From = "from",
                    Value = JsonSerializer.SerializeToElement("Production SendGrid"),
                },
                new()
                {
                    Op = Op.Replace,
                    Path = "/settings/api_key",
                    From = "from",
                    Value = JsonSerializer.SerializeToElement("SG.xxxxxxxx"),
                },
            ],
        };

        string expectedID = "id";
        List<Patch> expectedPatch =
        [
            new()
            {
                Op = Op.Replace,
                Path = "/title",
                From = "from",
                Value = JsonSerializer.SerializeToElement("Production SendGrid"),
            },
            new()
            {
                Op = Op.Replace,
                Path = "/settings/api_key",
                From = "from",
                Value = JsonSerializer.SerializeToElement("SG.xxxxxxxx"),
            },
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedPatch.Count, parameters.Patch.Count);
        for (int i = 0; i < expectedPatch.Count; i++)
        {
            Assert.Equal(expectedPatch[i], parameters.Patch[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        ProviderPatchParams parameters = new()
        {
            ID = "id",
            Patch =
            [
                new()
                {
                    Op = Op.Replace,
                    Path = "/title",
                    From = "from",
                    Value = JsonSerializer.SerializeToElement("Production SendGrid"),
                },
                new()
                {
                    Op = Op.Replace,
                    Path = "/settings/api_key",
                    From = "from",
                    Value = JsonSerializer.SerializeToElement("SG.xxxxxxxx"),
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/providers/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProviderPatchParams
        {
            ID = "id",
            Patch =
            [
                new()
                {
                    Op = Op.Replace,
                    Path = "/title",
                    From = "from",
                    Value = JsonSerializer.SerializeToElement("Production SendGrid"),
                },
                new()
                {
                    Op = Op.Replace,
                    Path = "/settings/api_key",
                    From = "from",
                    Value = JsonSerializer.SerializeToElement("SG.xxxxxxxx"),
                },
            ],
        };

        ProviderPatchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PatchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Patch
        {
            Op = Op.Add,
            Path = "path",
            From = "from",
            Value = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ApiEnum<string, Op> expectedOp = Op.Add;
        string expectedPath = "path";
        string expectedFrom = "from";
        JsonElement expectedValue = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedOp, model.Op);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedFrom, model.From);
        Assert.NotNull(model.Value);
        Assert.True(JsonElement.DeepEquals(expectedValue, model.Value.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Patch
        {
            Op = Op.Add,
            Path = "path",
            From = "from",
            Value = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Patch>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Patch
        {
            Op = Op.Add,
            Path = "path",
            From = "from",
            Value = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Patch>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Op> expectedOp = Op.Add;
        string expectedPath = "path";
        string expectedFrom = "from";
        JsonElement expectedValue = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedOp, deserialized.Op);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.NotNull(deserialized.Value);
        Assert.True(JsonElement.DeepEquals(expectedValue, deserialized.Value.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Patch
        {
            Op = Op.Add,
            Path = "path",
            From = "from",
            Value = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Patch { Op = Op.Add, Path = "path" };

        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Patch { Op = Op.Add, Path = "path" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Patch
        {
            Op = Op.Add,
            Path = "path",

            // Null should be interpreted as omitted for these properties
            From = null,
            Value = null,
        };

        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Patch
        {
            Op = Op.Add,
            Path = "path",

            // Null should be interpreted as omitted for these properties
            From = null,
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Patch
        {
            Op = Op.Add,
            Path = "path",
            From = "from",
            Value = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Patch copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OpTest : TestBase
{
    [Theory]
    [InlineData(Op.Add)]
    [InlineData(Op.Remove)]
    [InlineData(Op.Replace)]
    [InlineData(Op.Move)]
    [InlineData(Op.Copy)]
    [InlineData(Op.Test)]
    public void Validation_Works(Op rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Op> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Op>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Op.Add)]
    [InlineData(Op.Remove)]
    [InlineData(Op.Replace)]
    [InlineData(Op.Move)]
    [InlineData(Op.Copy)]
    [InlineData(Op.Test)]
    public void SerializationRoundtrip_Works(Op rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Op> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Op>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Op>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Op>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
