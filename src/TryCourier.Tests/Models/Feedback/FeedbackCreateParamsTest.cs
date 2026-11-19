using System;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Feedback;

namespace TryCourier.Tests.Models.Feedback;

public class FeedbackCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FeedbackCreateParams
        {
            Category = Category.PossibleBug,
            Description =
                "GET /lists/{list_id}/subscriptions returned items: [] with paging.more set to true, and following the cursor returned the remaining subscribers.",
            Surface = Surface.Api,
            Title = "List subscriptions returns an empty page with a next cursor",
            ExpectedBehavior = "Every page before the last one contains at least one item.",
            Harness = "Claude Code",
            Location = "GET /lists/{list_id}/subscriptions",
            Model = "claude-opus-5-5",
            RequestID = "1-67f340b1-58b7b231d9485ef0cda0a38b",
        };

        ApiEnum<string, Category> expectedCategory = Category.PossibleBug;
        string expectedDescription =
            "GET /lists/{list_id}/subscriptions returned items: [] with paging.more set to true, and following the cursor returned the remaining subscribers.";
        ApiEnum<string, Surface> expectedSurface = Surface.Api;
        string expectedTitle = "List subscriptions returns an empty page with a next cursor";
        string expectedExpectedBehavior =
            "Every page before the last one contains at least one item.";
        string expectedHarness = "Claude Code";
        string expectedLocation = "GET /lists/{list_id}/subscriptions";
        string expectedModel = "claude-opus-5-5";
        string expectedRequestID = "1-67f340b1-58b7b231d9485ef0cda0a38b";

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedSurface, parameters.Surface);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedExpectedBehavior, parameters.ExpectedBehavior);
        Assert.Equal(expectedHarness, parameters.Harness);
        Assert.Equal(expectedLocation, parameters.Location);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedRequestID, parameters.RequestID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FeedbackCreateParams
        {
            Category = Category.PossibleBug,
            Description =
                "GET /lists/{list_id}/subscriptions returned items: [] with paging.more set to true, and following the cursor returned the remaining subscribers.",
            Surface = Surface.Api,
            Title = "List subscriptions returns an empty page with a next cursor",
        };

        Assert.Null(parameters.ExpectedBehavior);
        Assert.False(parameters.RawBodyData.ContainsKey("expected_behavior"));
        Assert.Null(parameters.Harness);
        Assert.False(parameters.RawBodyData.ContainsKey("harness"));
        Assert.Null(parameters.Location);
        Assert.False(parameters.RawBodyData.ContainsKey("location"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.RequestID);
        Assert.False(parameters.RawBodyData.ContainsKey("request_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FeedbackCreateParams
        {
            Category = Category.PossibleBug,
            Description =
                "GET /lists/{list_id}/subscriptions returned items: [] with paging.more set to true, and following the cursor returned the remaining subscribers.",
            Surface = Surface.Api,
            Title = "List subscriptions returns an empty page with a next cursor",

            // Null should be interpreted as omitted for these properties
            ExpectedBehavior = null,
            Harness = null,
            Location = null,
            Model = null,
            RequestID = null,
        };

        Assert.Null(parameters.ExpectedBehavior);
        Assert.False(parameters.RawBodyData.ContainsKey("expected_behavior"));
        Assert.Null(parameters.Harness);
        Assert.False(parameters.RawBodyData.ContainsKey("harness"));
        Assert.Null(parameters.Location);
        Assert.False(parameters.RawBodyData.ContainsKey("location"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.RequestID);
        Assert.False(parameters.RawBodyData.ContainsKey("request_id"));
    }

    [Fact]
    public void Url_Works()
    {
        FeedbackCreateParams parameters = new()
        {
            Category = Category.PossibleBug,
            Description =
                "GET /lists/{list_id}/subscriptions returned items: [] with paging.more set to true, and following the cursor returned the remaining subscribers.",
            Surface = Surface.Api,
            Title = "List subscriptions returns an empty page with a next cursor",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/feedback"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FeedbackCreateParams
        {
            Category = Category.PossibleBug,
            Description =
                "GET /lists/{list_id}/subscriptions returned items: [] with paging.more set to true, and following the cursor returned the remaining subscribers.",
            Surface = Surface.Api,
            Title = "List subscriptions returns an empty page with a next cursor",
            ExpectedBehavior = "Every page before the last one contains at least one item.",
            Harness = "Claude Code",
            Location = "GET /lists/{list_id}/subscriptions",
            Model = "claude-opus-5-5",
            RequestID = "1-67f340b1-58b7b231d9485ef0cda0a38b",
        };

        FeedbackCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.PossibleBug)]
    [InlineData(Category.ConfusingBehavior)]
    [InlineData(Category.FeatureRequest)]
    [InlineData(Category.Other)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.PossibleBug)]
    [InlineData(Category.ConfusingBehavior)]
    [InlineData(Category.FeatureRequest)]
    [InlineData(Category.Other)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SurfaceTest : TestBase
{
    [Theory]
    [InlineData(Surface.Api)]
    [InlineData(Surface.Sdk)]
    [InlineData(Surface.Mcp)]
    [InlineData(Surface.Ui)]
    [InlineData(Surface.Docs)]
    [InlineData(Surface.Other)]
    public void Validation_Works(Surface rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Surface> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Surface>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Surface.Api)]
    [InlineData(Surface.Sdk)]
    [InlineData(Surface.Mcp)]
    [InlineData(Surface.Ui)]
    [InlineData(Surface.Docs)]
    [InlineData(Surface.Other)]
    public void SerializationRoundtrip_Works(Surface rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Surface> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Surface>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Surface>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Surface>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
