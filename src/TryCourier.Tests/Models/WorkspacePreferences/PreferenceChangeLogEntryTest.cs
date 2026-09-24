using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class PreferenceChangeLogEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceChangeLogEntry
        {
            ID = "id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
            Timestamp = "timestamp",
            TopicID = "topic_id",
            TopicName = "topic_name",
            UserID = "user_id",
            Previous = new()
            {
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
                Status = PreferenceStatus.OptedIn,
            },
            TenantID = "tenant_id",
        };

        string expectedID = "id";
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;
        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        string expectedTimestamp = "timestamp";
        string expectedTopicID = "topic_id";
        string expectedTopicName = "topic_name";
        string expectedUserID = "user_id";
        PreferenceChangeLogValue expectedPrevious = new()
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
        };
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCustomRouting.Count, model.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], model.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedTopicID, model.TopicID);
        Assert.Equal(expectedTopicName, model.TopicName);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedPrevious, model.Previous);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceChangeLogEntry
        {
            ID = "id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
            Timestamp = "timestamp",
            TopicID = "topic_id",
            TopicName = "topic_name",
            UserID = "user_id",
            Previous = new()
            {
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
                Status = PreferenceStatus.OptedIn,
            },
            TenantID = "tenant_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceChangeLogEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceChangeLogEntry
        {
            ID = "id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
            Timestamp = "timestamp",
            TopicID = "topic_id",
            TopicName = "topic_name",
            UserID = "user_id",
            Previous = new()
            {
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
                Status = PreferenceStatus.OptedIn,
            },
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceChangeLogEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;
        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        string expectedTimestamp = "timestamp";
        string expectedTopicID = "topic_id";
        string expectedTopicName = "topic_name";
        string expectedUserID = "user_id";
        PreferenceChangeLogValue expectedPrevious = new()
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
        };
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCustomRouting.Count, deserialized.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], deserialized.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, deserialized.HasCustomRouting);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedTopicID, deserialized.TopicID);
        Assert.Equal(expectedTopicName, deserialized.TopicName);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedPrevious, deserialized.Previous);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceChangeLogEntry
        {
            ID = "id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
            Timestamp = "timestamp",
            TopicID = "topic_id",
            TopicName = "topic_name",
            UserID = "user_id",
            Previous = new()
            {
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
                Status = PreferenceStatus.OptedIn,
            },
            TenantID = "tenant_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PreferenceChangeLogEntry
        {
            ID = "id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
            Timestamp = "timestamp",
            TopicID = "topic_id",
            TopicName = "topic_name",
            UserID = "user_id",
        };

        Assert.Null(model.Previous);
        Assert.False(model.RawData.ContainsKey("previous"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PreferenceChangeLogEntry
        {
            ID = "id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
            Timestamp = "timestamp",
            TopicID = "topic_id",
            TopicName = "topic_name",
            UserID = "user_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PreferenceChangeLogEntry
        {
            ID = "id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
            Timestamp = "timestamp",
            TopicID = "topic_id",
            TopicName = "topic_name",
            UserID = "user_id",

            // Null should be interpreted as omitted for these properties
            Previous = null,
            TenantID = null,
        };

        Assert.Null(model.Previous);
        Assert.False(model.RawData.ContainsKey("previous"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PreferenceChangeLogEntry
        {
            ID = "id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
            Timestamp = "timestamp",
            TopicID = "topic_id",
            TopicName = "topic_name",
            UserID = "user_id",

            // Null should be interpreted as omitted for these properties
            Previous = null,
            TenantID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferenceChangeLogEntry
        {
            ID = "id",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = PreferenceStatus.OptedIn,
            Timestamp = "timestamp",
            TopicID = "topic_id",
            TopicName = "topic_name",
            UserID = "user_id",
            Previous = new()
            {
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
                Status = PreferenceStatus.OptedIn,
            },
            TenantID = "tenant_id",
        };

        PreferenceChangeLogEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}
