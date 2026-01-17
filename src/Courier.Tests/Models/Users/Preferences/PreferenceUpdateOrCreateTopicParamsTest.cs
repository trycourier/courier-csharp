using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.Users.Preferences;

namespace Courier.Tests.Models.Users.Preferences;

public class PreferenceUpdateOrCreateTopicParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreferenceUpdateOrCreateTopicParams
        {
            UserID = "user_id",
            TopicID = "topic_id",
            Topic = new()
            {
                Status = PreferenceStatus.OptedIn,
                CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                HasCustomRouting = true,
            },
            TenantID = "tenant_id",
        };

        string expectedUserID = "user_id";
        string expectedTopicID = "topic_id";
        Topic expectedTopic = new()
        {
            Status = PreferenceStatus.OptedIn,
            CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
            HasCustomRouting = true,
        };
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedTopicID, parameters.TopicID);
        Assert.Equal(expectedTopic, parameters.Topic);
        Assert.Equal(expectedTenantID, parameters.TenantID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PreferenceUpdateOrCreateTopicParams
        {
            UserID = "user_id",
            TopicID = "topic_id",
            Topic = new()
            {
                Status = PreferenceStatus.OptedIn,
                CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                HasCustomRouting = true,
            },
        };

        Assert.Null(parameters.TenantID);
        Assert.False(parameters.RawQueryData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PreferenceUpdateOrCreateTopicParams
        {
            UserID = "user_id",
            TopicID = "topic_id",
            Topic = new()
            {
                Status = PreferenceStatus.OptedIn,
                CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                HasCustomRouting = true,
            },

            TenantID = null,
        };

        Assert.Null(parameters.TenantID);
        Assert.True(parameters.RawQueryData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void Url_Works()
    {
        PreferenceUpdateOrCreateTopicParams parameters = new()
        {
            UserID = "user_id",
            TopicID = "topic_id",
            Topic = new()
            {
                Status = PreferenceStatus.OptedIn,
                CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                HasCustomRouting = true,
            },
            TenantID = "tenant_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.courier.com/users/user_id/preferences/topic_id?tenant_id=tenant_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PreferenceUpdateOrCreateTopicParams
        {
            UserID = "user_id",
            TopicID = "topic_id",
            Topic = new()
            {
                Status = PreferenceStatus.OptedIn,
                CustomRouting = [ChannelClassification.Inbox, ChannelClassification.Email],
                HasCustomRouting = true,
            },
            TenantID = "tenant_id",
        };

        PreferenceUpdateOrCreateTopicParams copied = new(parameters);

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
            Status = PreferenceStatus.OptedIn,
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;

        Assert.Equal(expectedStatus, model.Status);
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
            Status = PreferenceStatus.OptedIn,
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
            Status = PreferenceStatus.OptedIn,
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Topic>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;

        Assert.Equal(expectedStatus, deserialized.Status);
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
            Status = PreferenceStatus.OptedIn,
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Topic { Status = PreferenceStatus.OptedIn };

        Assert.Null(model.CustomRouting);
        Assert.False(model.RawData.ContainsKey("custom_routing"));
        Assert.Null(model.HasCustomRouting);
        Assert.False(model.RawData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Topic { Status = PreferenceStatus.OptedIn };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Topic
        {
            Status = PreferenceStatus.OptedIn,

            CustomRouting = null,
            HasCustomRouting = null,
        };

        Assert.Null(model.CustomRouting);
        Assert.True(model.RawData.ContainsKey("custom_routing"));
        Assert.Null(model.HasCustomRouting);
        Assert.True(model.RawData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Topic
        {
            Status = PreferenceStatus.OptedIn,

            CustomRouting = null,
            HasCustomRouting = null,
        };

        model.Validate();
    }
}
