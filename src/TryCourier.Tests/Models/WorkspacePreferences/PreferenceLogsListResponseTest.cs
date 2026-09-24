using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class PreferenceLogsListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceLogsListResponse
        {
            Items =
            [
                new()
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
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        List<PreferenceChangeLogEntry> expectedItems =
        [
            new()
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
            },
        ];
        Paging expectedPaging = new() { More = true, Cursor = "cursor" };

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPaging, model.Paging);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceLogsListResponse
        {
            Items =
            [
                new()
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
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceLogsListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceLogsListResponse
        {
            Items =
            [
                new()
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
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceLogsListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PreferenceChangeLogEntry> expectedItems =
        [
            new()
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
            },
        ];
        Paging expectedPaging = new() { More = true, Cursor = "cursor" };

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedPaging, deserialized.Paging);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceLogsListResponse
        {
            Items =
            [
                new()
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
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferenceLogsListResponse
        {
            Items =
            [
                new()
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
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        PreferenceLogsListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
