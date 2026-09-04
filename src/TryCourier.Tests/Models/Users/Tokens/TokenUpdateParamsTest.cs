using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Users.Tokens;

namespace TryCourier.Tests.Models.Users.Tokens;

public class TokenUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TokenUpdateParams
        {
            UserID = "user_id",
            Token = "token",
            Patch =
            [
                new()
                {
                    Op = "replace",
                    Path = "/expiry_date",
                    Value = "2024-12-31T00:00:00.000Z",
                },
            ],
        };

        string expectedUserID = "user_id";
        string expectedToken = "token";
        List<Patch> expectedPatch =
        [
            new()
            {
                Op = "replace",
                Path = "/expiry_date",
                Value = "2024-12-31T00:00:00.000Z",
            },
        ];

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedToken, parameters.Token);
        Assert.Equal(expectedPatch.Count, parameters.Patch.Count);
        for (int i = 0; i < expectedPatch.Count; i++)
        {
            Assert.Equal(expectedPatch[i], parameters.Patch[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        TokenUpdateParams parameters = new()
        {
            UserID = "user_id",
            Token = "token",
            Patch =
            [
                new()
                {
                    Op = "replace",
                    Path = "/expiry_date",
                    Value = "2024-12-31T00:00:00.000Z",
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/users/user_id/tokens/token"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TokenUpdateParams
        {
            UserID = "user_id",
            Token = "token",
            Patch =
            [
                new()
                {
                    Op = "replace",
                    Path = "/expiry_date",
                    Value = "2024-12-31T00:00:00.000Z",
                },
            ],
        };

        TokenUpdateParams copied = new(parameters);

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
            Op = "op",
            Path = "path",
            Value = "string",
        };

        string expectedOp = "op";
        string expectedPath = "path";
        PatchValue expectedValue = "string";

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
            Value = "string",
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
            Op = "op",
            Path = "path",
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Patch>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedOp = "op";
        string expectedPath = "path";
        PatchValue expectedValue = "string";

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
            Value = "string",
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Patch
        {
            Op = "op",
            Path = "path",
            Value = "string",
        };

        Patch copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PatchValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        PatchValue value = "string";
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        PatchValue value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks()
    {
        PatchValue value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        PatchValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PatchValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        PatchValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PatchValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        PatchValue value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PatchValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
