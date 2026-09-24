using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Tests.Models.Notifications.Previews.Runs;

public class PreviewRunListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreviewRunListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    DeviceIds = ["string"],
                    Status = PreviewRunStatus.Pending,
                    TemplateID = "template_id",
                    FailureReason = PreviewRunFailureReason.TemplateNotSupported,
                    TemplateVersion = "template_version",
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<PreviewRun> expectedResults =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                DeviceIds = ["string"],
                Status = PreviewRunStatus.Pending,
                TemplateID = "template_id",
                FailureReason = PreviewRunFailureReason.TemplateNotSupported,
                TemplateVersion = "template_version",
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
        var model = new PreviewRunListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    DeviceIds = ["string"],
                    Status = PreviewRunStatus.Pending,
                    TemplateID = "template_id",
                    FailureReason = PreviewRunFailureReason.TemplateNotSupported,
                    TemplateVersion = "template_version",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewRunListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreviewRunListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    DeviceIds = ["string"],
                    Status = PreviewRunStatus.Pending,
                    TemplateID = "template_id",
                    FailureReason = PreviewRunFailureReason.TemplateNotSupported,
                    TemplateVersion = "template_version",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewRunListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<PreviewRun> expectedResults =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                DeviceIds = ["string"],
                Status = PreviewRunStatus.Pending,
                TemplateID = "template_id",
                FailureReason = PreviewRunFailureReason.TemplateNotSupported,
                TemplateVersion = "template_version",
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
        var model = new PreviewRunListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    DeviceIds = ["string"],
                    Status = PreviewRunStatus.Pending,
                    TemplateID = "template_id",
                    FailureReason = PreviewRunFailureReason.TemplateNotSupported,
                    TemplateVersion = "template_version",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreviewRunListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    DeviceIds = ["string"],
                    Status = PreviewRunStatus.Pending,
                    TemplateID = "template_id",
                    FailureReason = PreviewRunFailureReason.TemplateNotSupported,
                    TemplateVersion = "template_version",
                },
            ],
        };

        PreviewRunListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
