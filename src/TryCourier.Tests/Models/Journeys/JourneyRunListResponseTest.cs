using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyRunListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyRunListResponse
        {
            Runs =
            [
                new()
                {
                    RunID = "run_id",
                    Source = ["string"],
                    CreatedAt = "created_at",
                    Status = "status",
                    TemplateID = "template_id",
                },
            ],
            NextCursor = "next_cursor",
            PrevCursor = "prev_cursor",
        };

        List<JourneyRunListItem> expectedRuns =
        [
            new()
            {
                RunID = "run_id",
                Source = ["string"],
                CreatedAt = "created_at",
                Status = "status",
                TemplateID = "template_id",
            },
        ];
        string expectedNextCursor = "next_cursor";
        string expectedPrevCursor = "prev_cursor";

        Assert.Equal(expectedRuns.Count, model.Runs.Count);
        for (int i = 0; i < expectedRuns.Count; i++)
        {
            Assert.Equal(expectedRuns[i], model.Runs[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.Equal(expectedPrevCursor, model.PrevCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyRunListResponse
        {
            Runs =
            [
                new()
                {
                    RunID = "run_id",
                    Source = ["string"],
                    CreatedAt = "created_at",
                    Status = "status",
                    TemplateID = "template_id",
                },
            ],
            NextCursor = "next_cursor",
            PrevCursor = "prev_cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyRunListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyRunListResponse
        {
            Runs =
            [
                new()
                {
                    RunID = "run_id",
                    Source = ["string"],
                    CreatedAt = "created_at",
                    Status = "status",
                    TemplateID = "template_id",
                },
            ],
            NextCursor = "next_cursor",
            PrevCursor = "prev_cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyRunListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JourneyRunListItem> expectedRuns =
        [
            new()
            {
                RunID = "run_id",
                Source = ["string"],
                CreatedAt = "created_at",
                Status = "status",
                TemplateID = "template_id",
            },
        ];
        string expectedNextCursor = "next_cursor";
        string expectedPrevCursor = "prev_cursor";

        Assert.Equal(expectedRuns.Count, deserialized.Runs.Count);
        for (int i = 0; i < expectedRuns.Count; i++)
        {
            Assert.Equal(expectedRuns[i], deserialized.Runs[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.Equal(expectedPrevCursor, deserialized.PrevCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyRunListResponse
        {
            Runs =
            [
                new()
                {
                    RunID = "run_id",
                    Source = ["string"],
                    CreatedAt = "created_at",
                    Status = "status",
                    TemplateID = "template_id",
                },
            ],
            NextCursor = "next_cursor",
            PrevCursor = "prev_cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyRunListResponse
        {
            Runs =
            [
                new()
                {
                    RunID = "run_id",
                    Source = ["string"],
                    CreatedAt = "created_at",
                    Status = "status",
                    TemplateID = "template_id",
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
        Assert.Null(model.PrevCursor);
        Assert.False(model.RawData.ContainsKey("prev_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyRunListResponse
        {
            Runs =
            [
                new()
                {
                    RunID = "run_id",
                    Source = ["string"],
                    CreatedAt = "created_at",
                    Status = "status",
                    TemplateID = "template_id",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyRunListResponse
        {
            Runs =
            [
                new()
                {
                    RunID = "run_id",
                    Source = ["string"],
                    CreatedAt = "created_at",
                    Status = "status",
                    TemplateID = "template_id",
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
            PrevCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
        Assert.Null(model.PrevCursor);
        Assert.False(model.RawData.ContainsKey("prev_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyRunListResponse
        {
            Runs =
            [
                new()
                {
                    RunID = "run_id",
                    Source = ["string"],
                    CreatedAt = "created_at",
                    Status = "status",
                    TemplateID = "template_id",
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
            PrevCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyRunListResponse
        {
            Runs =
            [
                new()
                {
                    RunID = "run_id",
                    Source = ["string"],
                    CreatedAt = "created_at",
                    Status = "status",
                    TemplateID = "template_id",
                },
            ],
            NextCursor = "next_cursor",
            PrevCursor = "prev_cursor",
        };

        JourneyRunListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
