using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyRunStepsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyRunStepsResponse
        {
            Steps =
            [
                new()
                {
                    Action = "action",
                    Status = "status",
                    CreatedAt = "created_at",
                    MessageID = "message_id",
                    NodeID = "node_id",
                    UpdatedAt = "updated_at",
                },
            ],
        };

        List<JourneyRunStep> expectedSteps =
        [
            new()
            {
                Action = "action",
                Status = "status",
                CreatedAt = "created_at",
                MessageID = "message_id",
                NodeID = "node_id",
                UpdatedAt = "updated_at",
            },
        ];

        Assert.Equal(expectedSteps.Count, model.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], model.Steps[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyRunStepsResponse
        {
            Steps =
            [
                new()
                {
                    Action = "action",
                    Status = "status",
                    CreatedAt = "created_at",
                    MessageID = "message_id",
                    NodeID = "node_id",
                    UpdatedAt = "updated_at",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyRunStepsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyRunStepsResponse
        {
            Steps =
            [
                new()
                {
                    Action = "action",
                    Status = "status",
                    CreatedAt = "created_at",
                    MessageID = "message_id",
                    NodeID = "node_id",
                    UpdatedAt = "updated_at",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyRunStepsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JourneyRunStep> expectedSteps =
        [
            new()
            {
                Action = "action",
                Status = "status",
                CreatedAt = "created_at",
                MessageID = "message_id",
                NodeID = "node_id",
                UpdatedAt = "updated_at",
            },
        ];

        Assert.Equal(expectedSteps.Count, deserialized.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], deserialized.Steps[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyRunStepsResponse
        {
            Steps =
            [
                new()
                {
                    Action = "action",
                    Status = "status",
                    CreatedAt = "created_at",
                    MessageID = "message_id",
                    NodeID = "node_id",
                    UpdatedAt = "updated_at",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyRunStepsResponse
        {
            Steps =
            [
                new()
                {
                    Action = "action",
                    Status = "status",
                    CreatedAt = "created_at",
                    MessageID = "message_id",
                    NodeID = "node_id",
                    UpdatedAt = "updated_at",
                },
            ],
        };

        JourneyRunStepsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
