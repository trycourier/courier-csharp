using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.Users.Preferences;

namespace TryCourier.Tests.Models.Users.Preferences;

public class PreferenceBulkReplaceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreferenceBulkReplaceParams
        {
            UserID = "user_id",
            Topics =
            [
                new()
                {
                    Status = Status.OptedIn,
                    TopicID = "74Q4QGFBEX481DP6JRPMV751H4XT",
                    CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                    HasCustomRouting = true,
                },
            ],
            TenantID = "tenant_id",
        };

        string expectedUserID = "user_id";
        List<Topic> expectedTopics =
        [
            new()
            {
                Status = Status.OptedIn,
                TopicID = "74Q4QGFBEX481DP6JRPMV751H4XT",
                CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                HasCustomRouting = true,
            },
        ];
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedTopics.Count, parameters.Topics.Count);
        for (int i = 0; i < expectedTopics.Count; i++)
        {
            Assert.Equal(expectedTopics[i], parameters.Topics[i]);
        }
        Assert.Equal(expectedTenantID, parameters.TenantID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PreferenceBulkReplaceParams
        {
            UserID = "user_id",
            Topics =
            [
                new()
                {
                    Status = Status.OptedIn,
                    TopicID = "74Q4QGFBEX481DP6JRPMV751H4XT",
                    CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                    HasCustomRouting = true,
                },
            ],
        };

        Assert.Null(parameters.TenantID);
        Assert.False(parameters.RawQueryData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PreferenceBulkReplaceParams
        {
            UserID = "user_id",
            Topics =
            [
                new()
                {
                    Status = Status.OptedIn,
                    TopicID = "74Q4QGFBEX481DP6JRPMV751H4XT",
                    CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                    HasCustomRouting = true,
                },
            ],

            TenantID = null,
        };

        Assert.Null(parameters.TenantID);
        Assert.True(parameters.RawQueryData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void Url_Works()
    {
        PreferenceBulkReplaceParams parameters = new()
        {
            UserID = "user_id",
            Topics =
            [
                new()
                {
                    Status = Status.OptedIn,
                    TopicID = "74Q4QGFBEX481DP6JRPMV751H4XT",
                    CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                    HasCustomRouting = true,
                },
            ],
            TenantID = "tenant_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/users/user_id/preferences?tenant_id=tenant_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PreferenceBulkReplaceParams
        {
            UserID = "user_id",
            Topics =
            [
                new()
                {
                    Status = Status.OptedIn,
                    TopicID = "74Q4QGFBEX481DP6JRPMV751H4XT",
                    CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                    HasCustomRouting = true,
                },
            ],
            TenantID = "tenant_id",
        };

        PreferenceBulkReplaceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TopicTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Topic
        {
            Status = Status.OptedIn,
            TopicID = "topic_id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        ApiEnum<string, Status> expectedStatus = Status.OptedIn;
        string expectedTopicID = "topic_id";
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTopicID, model.TopicID);
        Assert.NotNull(model.CustomRouting);
        Assert.Equal(expectedCustomRouting.Count, model.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], model.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Topic
        {
            Status = Status.OptedIn,
            TopicID = "topic_id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Topic>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Topic
        {
            Status = Status.OptedIn,
            TopicID = "topic_id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Topic>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.OptedIn;
        string expectedTopicID = "topic_id";
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTopicID, deserialized.TopicID);
        Assert.NotNull(deserialized.CustomRouting);
        Assert.Equal(expectedCustomRouting.Count, deserialized.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], deserialized.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, deserialized.HasCustomRouting);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Topic
        {
            Status = Status.OptedIn,
            TopicID = "topic_id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Topic { Status = Status.OptedIn, TopicID = "topic_id" };

        Assert.Null(model.CustomRouting);
        Assert.False(model.RawData.ContainsKey("custom_routing"));
        Assert.Null(model.HasCustomRouting);
        Assert.False(model.RawData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Topic { Status = Status.OptedIn, TopicID = "topic_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Topic
        {
            Status = Status.OptedIn,
            TopicID = "topic_id",

            // Null should be interpreted as omitted for these properties
            CustomRouting = null,
            HasCustomRouting = null,
        };

        Assert.Null(model.CustomRouting);
        Assert.False(model.RawData.ContainsKey("custom_routing"));
        Assert.Null(model.HasCustomRouting);
        Assert.False(model.RawData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Topic
        {
            Status = Status.OptedIn,
            TopicID = "topic_id",

            // Null should be interpreted as omitted for these properties
            CustomRouting = null,
            HasCustomRouting = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Topic
        {
            Status = Status.OptedIn,
            TopicID = "topic_id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        Topic copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.OptedIn)]
    [InlineData(Status.OptedOut)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.OptedIn)]
    [InlineData(Status.OptedOut)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
