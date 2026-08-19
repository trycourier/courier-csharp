using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyRunResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyRunResponse
        {
            Run = new()
            {
                RunID = "run_id",
                Source = ["string"],
                CreatedAt = "created_at",
                Status = "status",
                TemplateID = "template_id",
                UpdatedAt = "updated_at",
            },
        };

        JourneyRun expectedRun = new()
        {
            RunID = "run_id",
            Source = ["string"],
            CreatedAt = "created_at",
            Status = "status",
            TemplateID = "template_id",
            UpdatedAt = "updated_at",
        };

        Assert.Equal(expectedRun, model.Run);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyRunResponse
        {
            Run = new()
            {
                RunID = "run_id",
                Source = ["string"],
                CreatedAt = "created_at",
                Status = "status",
                TemplateID = "template_id",
                UpdatedAt = "updated_at",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyRunResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyRunResponse
        {
            Run = new()
            {
                RunID = "run_id",
                Source = ["string"],
                CreatedAt = "created_at",
                Status = "status",
                TemplateID = "template_id",
                UpdatedAt = "updated_at",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyRunResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JourneyRun expectedRun = new()
        {
            RunID = "run_id",
            Source = ["string"],
            CreatedAt = "created_at",
            Status = "status",
            TemplateID = "template_id",
            UpdatedAt = "updated_at",
        };

        Assert.Equal(expectedRun, deserialized.Run);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyRunResponse
        {
            Run = new()
            {
                RunID = "run_id",
                Source = ["string"],
                CreatedAt = "created_at",
                Status = "status",
                TemplateID = "template_id",
                UpdatedAt = "updated_at",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyRunResponse
        {
            Run = new()
            {
                RunID = "run_id",
                Source = ["string"],
                CreatedAt = "created_at",
                Status = "status",
                TemplateID = "template_id",
                UpdatedAt = "updated_at",
            },
        };

        JourneyRunResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
