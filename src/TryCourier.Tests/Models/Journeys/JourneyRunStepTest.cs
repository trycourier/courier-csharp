using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyRunStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyRunStep
        {
            Action = "action",
            Error = new("message"),
            SkipReason = "skip_reason",
            Status = "status",
            CreatedAt = "created_at",
            MessageID = "message_id",
            NodeID = "node_id",
            UpdatedAt = "updated_at",
        };

        string expectedAction = "action";
        Error expectedError = new("message");
        string expectedSkipReason = "skip_reason";
        string expectedStatus = "status";
        string expectedCreatedAt = "created_at";
        string expectedMessageID = "message_id";
        string expectedNodeID = "node_id";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedSkipReason, model.SkipReason);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedNodeID, model.NodeID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyRunStep
        {
            Action = "action",
            Error = new("message"),
            SkipReason = "skip_reason",
            Status = "status",
            CreatedAt = "created_at",
            MessageID = "message_id",
            NodeID = "node_id",
            UpdatedAt = "updated_at",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyRunStep>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyRunStep
        {
            Action = "action",
            Error = new("message"),
            SkipReason = "skip_reason",
            Status = "status",
            CreatedAt = "created_at",
            MessageID = "message_id",
            NodeID = "node_id",
            UpdatedAt = "updated_at",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyRunStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAction = "action";
        Error expectedError = new("message");
        string expectedSkipReason = "skip_reason";
        string expectedStatus = "status";
        string expectedCreatedAt = "created_at";
        string expectedMessageID = "message_id";
        string expectedNodeID = "node_id";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedSkipReason, deserialized.SkipReason);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedNodeID, deserialized.NodeID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyRunStep
        {
            Action = "action",
            Error = new("message"),
            SkipReason = "skip_reason",
            Status = "status",
            CreatedAt = "created_at",
            MessageID = "message_id",
            NodeID = "node_id",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyRunStep
        {
            Action = "action",
            Error = new("message"),
            SkipReason = "skip_reason",
            Status = "status",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.NodeID);
        Assert.False(model.RawData.ContainsKey("node_id"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyRunStep
        {
            Action = "action",
            Error = new("message"),
            SkipReason = "skip_reason",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyRunStep
        {
            Action = "action",
            Error = new("message"),
            SkipReason = "skip_reason",
            Status = "status",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            MessageID = null,
            NodeID = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("message_id"));
        Assert.Null(model.NodeID);
        Assert.False(model.RawData.ContainsKey("node_id"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyRunStep
        {
            Action = "action",
            Error = new("message"),
            SkipReason = "skip_reason",
            Status = "status",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            MessageID = null,
            NodeID = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyRunStep
        {
            Action = "action",
            Error = new("message"),
            SkipReason = "skip_reason",
            Status = "status",
            CreatedAt = "created_at",
            MessageID = "message_id",
            NodeID = "node_id",
            UpdatedAt = "updated_at",
        };

        JourneyRunStep copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Error { Message = "message" };

        string expectedMessage = "message";

        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error { Message = "message" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error { Message = "message" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedMessage = "message";

        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error { Message = "message" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error { Message = "message" };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}
