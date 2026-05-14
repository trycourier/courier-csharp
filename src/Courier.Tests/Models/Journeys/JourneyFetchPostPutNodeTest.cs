using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyFetchPostPutNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyFetchPostPutNode
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",
            ID = "x",
            Body = "body",
            Conditions = new(["string", "string"]),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            QueryParams = new Dictionary<string, string>() { { "foo", "string" } },
            ResponseSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        ApiEnum<string, JourneyMergeStrategy> expectedMergeStrategy =
            JourneyMergeStrategy.Overwrite;
        ApiEnum<string, JourneyFetchPostPutNodeMethod> expectedMethod =
            JourneyFetchPostPutNodeMethod.Post;
        ApiEnum<string, JourneyFetchPostPutNodeType> expectedType =
            JourneyFetchPostPutNodeType.Fetch;
        string expectedUrl = "x";
        string expectedID = "x";
        string expectedBody = "body";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        Dictionary<string, string> expectedQueryParams = new() { { "foo", "string" } };
        Dictionary<string, JsonElement> expectedResponseSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedMergeStrategy, model.MergeStrategy);
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedConditions, model.Conditions);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.NotNull(model.QueryParams);
        Assert.Equal(expectedQueryParams.Count, model.QueryParams.Count);
        foreach (var item in expectedQueryParams)
        {
            Assert.True(model.QueryParams.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.QueryParams[item.Key]);
        }
        Assert.NotNull(model.ResponseSchema);
        Assert.Equal(expectedResponseSchema.Count, model.ResponseSchema.Count);
        foreach (var item in expectedResponseSchema)
        {
            Assert.True(model.ResponseSchema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ResponseSchema[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyFetchPostPutNode
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",
            ID = "x",
            Body = "body",
            Conditions = new(["string", "string"]),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            QueryParams = new Dictionary<string, string>() { { "foo", "string" } },
            ResponseSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyFetchPostPutNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyFetchPostPutNode
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",
            ID = "x",
            Body = "body",
            Conditions = new(["string", "string"]),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            QueryParams = new Dictionary<string, string>() { { "foo", "string" } },
            ResponseSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyFetchPostPutNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, JourneyMergeStrategy> expectedMergeStrategy =
            JourneyMergeStrategy.Overwrite;
        ApiEnum<string, JourneyFetchPostPutNodeMethod> expectedMethod =
            JourneyFetchPostPutNodeMethod.Post;
        ApiEnum<string, JourneyFetchPostPutNodeType> expectedType =
            JourneyFetchPostPutNodeType.Fetch;
        string expectedUrl = "x";
        string expectedID = "x";
        string expectedBody = "body";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        Dictionary<string, string> expectedQueryParams = new() { { "foo", "string" } };
        Dictionary<string, JsonElement> expectedResponseSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedMergeStrategy, deserialized.MergeStrategy);
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedConditions, deserialized.Conditions);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.NotNull(deserialized.QueryParams);
        Assert.Equal(expectedQueryParams.Count, deserialized.QueryParams.Count);
        foreach (var item in expectedQueryParams)
        {
            Assert.True(deserialized.QueryParams.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.QueryParams[item.Key]);
        }
        Assert.NotNull(deserialized.ResponseSchema);
        Assert.Equal(expectedResponseSchema.Count, deserialized.ResponseSchema.Count);
        foreach (var item in expectedResponseSchema)
        {
            Assert.True(deserialized.ResponseSchema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.ResponseSchema[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyFetchPostPutNode
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",
            ID = "x",
            Body = "body",
            Conditions = new(["string", "string"]),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            QueryParams = new Dictionary<string, string>() { { "foo", "string" } },
            ResponseSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyFetchPostPutNode
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.QueryParams);
        Assert.False(model.RawData.ContainsKey("query_params"));
        Assert.Null(model.ResponseSchema);
        Assert.False(model.RawData.ContainsKey("response_schema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyFetchPostPutNode
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyFetchPostPutNode
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Body = null,
            Conditions = null,
            Headers = null,
            QueryParams = null,
            ResponseSchema = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.QueryParams);
        Assert.False(model.RawData.ContainsKey("query_params"));
        Assert.Null(model.ResponseSchema);
        Assert.False(model.RawData.ContainsKey("response_schema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyFetchPostPutNode
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Body = null,
            Conditions = null,
            Headers = null,
            QueryParams = null,
            ResponseSchema = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyFetchPostPutNode
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",
            ID = "x",
            Body = "body",
            Conditions = new(["string", "string"]),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            QueryParams = new Dictionary<string, string>() { { "foo", "string" } },
            ResponseSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        JourneyFetchPostPutNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyFetchPostPutNodeMethodTest : TestBase
{
    [Theory]
    [InlineData(JourneyFetchPostPutNodeMethod.Post)]
    [InlineData(JourneyFetchPostPutNodeMethod.Put)]
    public void Validation_Works(JourneyFetchPostPutNodeMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyFetchPostPutNodeMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyFetchPostPutNodeMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyFetchPostPutNodeMethod.Post)]
    [InlineData(JourneyFetchPostPutNodeMethod.Put)]
    public void SerializationRoundtrip_Works(JourneyFetchPostPutNodeMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyFetchPostPutNodeMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyFetchPostPutNodeMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyFetchPostPutNodeMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyFetchPostPutNodeMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class JourneyFetchPostPutNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyFetchPostPutNodeType.Fetch)]
    public void Validation_Works(JourneyFetchPostPutNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyFetchPostPutNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyFetchPostPutNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyFetchPostPutNodeType.Fetch)]
    public void SerializationRoundtrip_Works(JourneyFetchPostPutNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyFetchPostPutNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyFetchPostPutNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyFetchPostPutNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyFetchPostPutNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
