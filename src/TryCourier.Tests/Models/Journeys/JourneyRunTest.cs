using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyRunTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyRun
        {
            RunID = "run_id",
            Source = ["string"],
            CreatedAt = "created_at",
            Status = "status",
            TemplateID = "template_id",
            UpdatedAt = "updated_at",
        };

        string expectedRunID = "run_id";
        List<string> expectedSource = ["string"];
        string expectedCreatedAt = "created_at";
        string expectedStatus = "status";
        string expectedTemplateID = "template_id";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedRunID, model.RunID);
        Assert.Equal(expectedSource.Count, model.Source.Count);
        for (int i = 0; i < expectedSource.Count; i++)
        {
            Assert.Equal(expectedSource[i], model.Source[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyRun
        {
            RunID = "run_id",
            Source = ["string"],
            CreatedAt = "created_at",
            Status = "status",
            TemplateID = "template_id",
            UpdatedAt = "updated_at",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyRun>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyRun
        {
            RunID = "run_id",
            Source = ["string"],
            CreatedAt = "created_at",
            Status = "status",
            TemplateID = "template_id",
            UpdatedAt = "updated_at",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyRun>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRunID = "run_id";
        List<string> expectedSource = ["string"];
        string expectedCreatedAt = "created_at";
        string expectedStatus = "status";
        string expectedTemplateID = "template_id";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedRunID, deserialized.RunID);
        Assert.Equal(expectedSource.Count, deserialized.Source.Count);
        for (int i = 0; i < expectedSource.Count; i++)
        {
            Assert.Equal(expectedSource[i], deserialized.Source[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyRun
        {
            RunID = "run_id",
            Source = ["string"],
            CreatedAt = "created_at",
            Status = "status",
            TemplateID = "template_id",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyRun { RunID = "run_id", Source = ["string"] };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyRun { RunID = "run_id", Source = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyRun
        {
            RunID = "run_id",
            Source = ["string"],

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Status = null,
            TemplateID = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("template_id"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyRun
        {
            RunID = "run_id",
            Source = ["string"],

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Status = null,
            TemplateID = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyRun
        {
            RunID = "run_id",
            Source = ["string"],
            CreatedAt = "created_at",
            Status = "status",
            TemplateID = "template_id",
            UpdatedAt = "updated_at",
        };

        JourneyRun copied = new(model);

        Assert.Equal(model, copied);
    }
}
