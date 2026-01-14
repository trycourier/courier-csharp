using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Profiles;

namespace Courier.Tests.Models.Profiles;

public class ProfileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            UserID = "user_id",
            Patch =
            [
                new()
                {
                    Op = "op",
                    Path = "path",
                    Value = "value",
                },
            ],
        };

        string expectedUserID = "user_id";
        List<Patch> expectedPatch =
        [
            new()
            {
                Op = "op",
                Path = "path",
                Value = "value",
            },
        ];

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedPatch.Count, parameters.Patch.Count);
        for (int i = 0; i < expectedPatch.Count; i++)
        {
            Assert.Equal(expectedPatch[i], parameters.Patch[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        ProfileUpdateParams parameters = new()
        {
            UserID = "user_id",
            Patch =
            [
                new()
                {
                    Op = "op",
                    Path = "path",
                    Value = "value",
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/profiles/user_id"), url);
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
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Patch>(element, ModelBase.SerializerOptions);
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
}
