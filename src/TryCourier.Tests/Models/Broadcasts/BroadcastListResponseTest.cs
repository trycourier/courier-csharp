using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BroadcastListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Channel = BroadcastChannel.Email,
                    CreatedAt = "created_at",
                    CreatedBy = "created_by",
                    Name = "name",
                    Status = Status.Draft,
                    UpdatedAt = "updated_at",
                    UpdatedBy = "updated_by",
                    ArchivedAt = "archived_at",
                    ArchivedBy = "archived_by",
                    Schedule = new()
                    {
                        RecipientID = "recipient_id",
                        RecipientType = BroadcastScheduleRecipientType.List,
                        ScheduledTo = "scheduled_to",
                        Timezone = "timezone",
                    },
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Broadcast> expectedResults =
        [
            new()
            {
                ID = "id",
                Channel = BroadcastChannel.Email,
                CreatedAt = "created_at",
                CreatedBy = "created_by",
                Name = "name",
                Status = Status.Draft,
                UpdatedAt = "updated_at",
                UpdatedBy = "updated_by",
                ArchivedAt = "archived_at",
                ArchivedBy = "archived_by",
                Schedule = new()
                {
                    RecipientID = "recipient_id",
                    RecipientType = BroadcastScheduleRecipientType.List,
                    ScheduledTo = "scheduled_to",
                    Timezone = "timezone",
                },
            },
        ];

        Assert.Equal(expectedPaging, model.Paging);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BroadcastListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Channel = BroadcastChannel.Email,
                    CreatedAt = "created_at",
                    CreatedBy = "created_by",
                    Name = "name",
                    Status = Status.Draft,
                    UpdatedAt = "updated_at",
                    UpdatedBy = "updated_by",
                    ArchivedAt = "archived_at",
                    ArchivedBy = "archived_by",
                    Schedule = new()
                    {
                        RecipientID = "recipient_id",
                        RecipientType = BroadcastScheduleRecipientType.List,
                        ScheduledTo = "scheduled_to",
                        Timezone = "timezone",
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BroadcastListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Channel = BroadcastChannel.Email,
                    CreatedAt = "created_at",
                    CreatedBy = "created_by",
                    Name = "name",
                    Status = Status.Draft,
                    UpdatedAt = "updated_at",
                    UpdatedBy = "updated_by",
                    ArchivedAt = "archived_at",
                    ArchivedBy = "archived_by",
                    Schedule = new()
                    {
                        RecipientID = "recipient_id",
                        RecipientType = BroadcastScheduleRecipientType.List,
                        ScheduledTo = "scheduled_to",
                        Timezone = "timezone",
                    },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Broadcast> expectedResults =
        [
            new()
            {
                ID = "id",
                Channel = BroadcastChannel.Email,
                CreatedAt = "created_at",
                CreatedBy = "created_by",
                Name = "name",
                Status = Status.Draft,
                UpdatedAt = "updated_at",
                UpdatedBy = "updated_by",
                ArchivedAt = "archived_at",
                ArchivedBy = "archived_by",
                Schedule = new()
                {
                    RecipientID = "recipient_id",
                    RecipientType = BroadcastScheduleRecipientType.List,
                    ScheduledTo = "scheduled_to",
                    Timezone = "timezone",
                },
            },
        ];

        Assert.Equal(expectedPaging, deserialized.Paging);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BroadcastListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Channel = BroadcastChannel.Email,
                    CreatedAt = "created_at",
                    CreatedBy = "created_by",
                    Name = "name",
                    Status = Status.Draft,
                    UpdatedAt = "updated_at",
                    UpdatedBy = "updated_by",
                    ArchivedAt = "archived_at",
                    ArchivedBy = "archived_by",
                    Schedule = new()
                    {
                        RecipientID = "recipient_id",
                        RecipientType = BroadcastScheduleRecipientType.List,
                        ScheduledTo = "scheduled_to",
                        Timezone = "timezone",
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BroadcastListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Channel = BroadcastChannel.Email,
                    CreatedAt = "created_at",
                    CreatedBy = "created_by",
                    Name = "name",
                    Status = Status.Draft,
                    UpdatedAt = "updated_at",
                    UpdatedBy = "updated_by",
                    ArchivedAt = "archived_at",
                    ArchivedBy = "archived_by",
                    Schedule = new()
                    {
                        RecipientID = "recipient_id",
                        RecipientType = BroadcastScheduleRecipientType.List,
                        ScheduledTo = "scheduled_to",
                        Timezone = "timezone",
                    },
                },
            ],
        };

        BroadcastListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
