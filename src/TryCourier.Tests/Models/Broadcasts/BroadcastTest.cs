using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Broadcast
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
        };

        string expectedID = "id";
        ApiEnum<string, BroadcastChannel> expectedChannel = BroadcastChannel.Email;
        string expectedCreatedAt = "created_at";
        string expectedCreatedBy = "created_by";
        string expectedName = "name";
        ApiEnum<string, Status> expectedStatus = Status.Draft;
        string expectedUpdatedAt = "updated_at";
        string expectedUpdatedBy = "updated_by";
        string expectedArchivedAt = "archived_at";
        string expectedArchivedBy = "archived_by";
        BroadcastSchedule expectedSchedule = new()
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUpdatedBy, model.UpdatedBy);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedArchivedBy, model.ArchivedBy);
        Assert.Equal(expectedSchedule, model.Schedule);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Broadcast
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Broadcast>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Broadcast
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Broadcast>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, BroadcastChannel> expectedChannel = BroadcastChannel.Email;
        string expectedCreatedAt = "created_at";
        string expectedCreatedBy = "created_by";
        string expectedName = "name";
        ApiEnum<string, Status> expectedStatus = Status.Draft;
        string expectedUpdatedAt = "updated_at";
        string expectedUpdatedBy = "updated_by";
        string expectedArchivedAt = "archived_at";
        string expectedArchivedBy = "archived_by";
        BroadcastSchedule expectedSchedule = new()
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUpdatedBy, deserialized.UpdatedBy);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedArchivedBy, deserialized.ArchivedBy);
        Assert.Equal(expectedSchedule, deserialized.Schedule);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Broadcast
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Broadcast
        {
            ID = "id",
            Channel = BroadcastChannel.Email,
            CreatedAt = "created_at",
            CreatedBy = "created_by",
            Name = "name",
            Status = Status.Draft,
            UpdatedAt = "updated_at",
            UpdatedBy = "updated_by",
        };

        Assert.Null(model.ArchivedAt);
        Assert.False(model.RawData.ContainsKey("archived_at"));
        Assert.Null(model.ArchivedBy);
        Assert.False(model.RawData.ContainsKey("archived_by"));
        Assert.Null(model.Schedule);
        Assert.False(model.RawData.ContainsKey("schedule"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Broadcast
        {
            ID = "id",
            Channel = BroadcastChannel.Email,
            CreatedAt = "created_at",
            CreatedBy = "created_by",
            Name = "name",
            Status = Status.Draft,
            UpdatedAt = "updated_at",
            UpdatedBy = "updated_by",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Broadcast
        {
            ID = "id",
            Channel = BroadcastChannel.Email,
            CreatedAt = "created_at",
            CreatedBy = "created_by",
            Name = "name",
            Status = Status.Draft,
            UpdatedAt = "updated_at",
            UpdatedBy = "updated_by",

            ArchivedAt = null,
            ArchivedBy = null,
            Schedule = null,
        };

        Assert.Null(model.ArchivedAt);
        Assert.True(model.RawData.ContainsKey("archived_at"));
        Assert.Null(model.ArchivedBy);
        Assert.True(model.RawData.ContainsKey("archived_by"));
        Assert.Null(model.Schedule);
        Assert.True(model.RawData.ContainsKey("schedule"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Broadcast
        {
            ID = "id",
            Channel = BroadcastChannel.Email,
            CreatedAt = "created_at",
            CreatedBy = "created_by",
            Name = "name",
            Status = Status.Draft,
            UpdatedAt = "updated_at",
            UpdatedBy = "updated_by",

            ArchivedAt = null,
            ArchivedBy = null,
            Schedule = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Broadcast
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
        };

        Broadcast copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BroadcastChannelTest : TestBase
{
    [Theory]
    [InlineData(BroadcastChannel.Email)]
    [InlineData(BroadcastChannel.Sms)]
    [InlineData(BroadcastChannel.Push)]
    [InlineData(BroadcastChannel.Inbox)]
    [InlineData(BroadcastChannel.Slack)]
    [InlineData(BroadcastChannel.Msteams)]
    public void Validation_Works(BroadcastChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BroadcastChannel.Email)]
    [InlineData(BroadcastChannel.Sms)]
    [InlineData(BroadcastChannel.Push)]
    [InlineData(BroadcastChannel.Inbox)]
    [InlineData(BroadcastChannel.Slack)]
    [InlineData(BroadcastChannel.Msteams)]
    public void SerializationRoundtrip_Works(BroadcastChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BroadcastChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BroadcastChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Scheduled)]
    [InlineData(Status.Sending)]
    [InlineData(Status.Sent)]
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
    [InlineData(Status.Draft)]
    [InlineData(Status.Scheduled)]
    [InlineData(Status.Sending)]
    [InlineData(Status.Sent)]
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
