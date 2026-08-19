using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Automations;

namespace TryCourier.Tests.Models.Automations;

public class AutomationRunStepsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationRunStepsResponse
        {
            Steps =
            [
                new()
                {
                    Action = "action",
                    Status = "status",
                    CreatedAt = "created_at",
                    MessageID = "message_id",
                    StepID = "step_id",
                    UpdatedAt = "updated_at",
                },
            ],
        };

        List<AutomationRunStep> expectedSteps =
        [
            new()
            {
                Action = "action",
                Status = "status",
                CreatedAt = "created_at",
                MessageID = "message_id",
                StepID = "step_id",
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
        var model = new AutomationRunStepsResponse
        {
            Steps =
            [
                new()
                {
                    Action = "action",
                    Status = "status",
                    CreatedAt = "created_at",
                    MessageID = "message_id",
                    StepID = "step_id",
                    UpdatedAt = "updated_at",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutomationRunStepsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutomationRunStepsResponse
        {
            Steps =
            [
                new()
                {
                    Action = "action",
                    Status = "status",
                    CreatedAt = "created_at",
                    MessageID = "message_id",
                    StepID = "step_id",
                    UpdatedAt = "updated_at",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutomationRunStepsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AutomationRunStep> expectedSteps =
        [
            new()
            {
                Action = "action",
                Status = "status",
                CreatedAt = "created_at",
                MessageID = "message_id",
                StepID = "step_id",
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
        var model = new AutomationRunStepsResponse
        {
            Steps =
            [
                new()
                {
                    Action = "action",
                    Status = "status",
                    CreatedAt = "created_at",
                    MessageID = "message_id",
                    StepID = "step_id",
                    UpdatedAt = "updated_at",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutomationRunStepsResponse
        {
            Steps =
            [
                new()
                {
                    Action = "action",
                    Status = "status",
                    CreatedAt = "created_at",
                    MessageID = "message_id",
                    StepID = "step_id",
                    UpdatedAt = "updated_at",
                },
            ],
        };

        AutomationRunStepsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
