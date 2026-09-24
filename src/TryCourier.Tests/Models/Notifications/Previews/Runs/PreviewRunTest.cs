using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Tests.Models.Notifications.Previews.Runs;

public class PreviewRunTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreviewRun
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Status = PreviewRunStatus.Pending,
            TemplateID = "template_id",
            FailureReason = PreviewRunFailureReason.TemplateNotSupported,
            TemplateVersion = "template_version",
        };

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        List<string> expectedDeviceIds = ["string"];
        ApiEnum<string, PreviewRunStatus> expectedStatus = PreviewRunStatus.Pending;
        string expectedTemplateID = "template_id";
        ApiEnum<string, PreviewRunFailureReason> expectedFailureReason =
            PreviewRunFailureReason.TemplateNotSupported;
        string expectedTemplateVersion = "template_version";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeviceIds.Count, model.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], model.DeviceIds[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedFailureReason, model.FailureReason);
        Assert.Equal(expectedTemplateVersion, model.TemplateVersion);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreviewRun
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Status = PreviewRunStatus.Pending,
            TemplateID = "template_id",
            FailureReason = PreviewRunFailureReason.TemplateNotSupported,
            TemplateVersion = "template_version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewRun>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreviewRun
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Status = PreviewRunStatus.Pending,
            TemplateID = "template_id",
            FailureReason = PreviewRunFailureReason.TemplateNotSupported,
            TemplateVersion = "template_version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewRun>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        List<string> expectedDeviceIds = ["string"];
        ApiEnum<string, PreviewRunStatus> expectedStatus = PreviewRunStatus.Pending;
        string expectedTemplateID = "template_id";
        ApiEnum<string, PreviewRunFailureReason> expectedFailureReason =
            PreviewRunFailureReason.TemplateNotSupported;
        string expectedTemplateVersion = "template_version";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeviceIds.Count, deserialized.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], deserialized.DeviceIds[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
        Assert.Equal(expectedTemplateVersion, deserialized.TemplateVersion);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreviewRun
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Status = PreviewRunStatus.Pending,
            TemplateID = "template_id",
            FailureReason = PreviewRunFailureReason.TemplateNotSupported,
            TemplateVersion = "template_version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PreviewRun
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Status = PreviewRunStatus.Pending,
            TemplateID = "template_id",
        };

        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failure_reason"));
        Assert.Null(model.TemplateVersion);
        Assert.False(model.RawData.ContainsKey("template_version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PreviewRun
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Status = PreviewRunStatus.Pending,
            TemplateID = "template_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PreviewRun
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Status = PreviewRunStatus.Pending,
            TemplateID = "template_id",

            // Null should be interpreted as omitted for these properties
            FailureReason = null,
            TemplateVersion = null,
        };

        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failure_reason"));
        Assert.Null(model.TemplateVersion);
        Assert.False(model.RawData.ContainsKey("template_version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PreviewRun
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Status = PreviewRunStatus.Pending,
            TemplateID = "template_id",

            // Null should be interpreted as omitted for these properties
            FailureReason = null,
            TemplateVersion = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreviewRun
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Status = PreviewRunStatus.Pending,
            TemplateID = "template_id",
            FailureReason = PreviewRunFailureReason.TemplateNotSupported,
            TemplateVersion = "template_version",
        };

        PreviewRun copied = new(model);

        Assert.Equal(model, copied);
    }
}
