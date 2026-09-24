using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Tests.Models.Notifications.Previews.Runs;

public class PreviewResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreviewResult
        {
            DeviceID = "device_id",
            ScreenshotUrl = "screenshot_url",
            Status = PreviewResultStatus.Pending,
            ThumbnailUrl = "thumbnail_url",
            FailureReason = PreviewResultFailureReason.DeliveryFailed,
        };

        string expectedDeviceID = "device_id";
        string expectedScreenshotUrl = "screenshot_url";
        ApiEnum<string, PreviewResultStatus> expectedStatus = PreviewResultStatus.Pending;
        string expectedThumbnailUrl = "thumbnail_url";
        ApiEnum<string, PreviewResultFailureReason> expectedFailureReason =
            PreviewResultFailureReason.DeliveryFailed;

        Assert.Equal(expectedDeviceID, model.DeviceID);
        Assert.Equal(expectedScreenshotUrl, model.ScreenshotUrl);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedThumbnailUrl, model.ThumbnailUrl);
        Assert.Equal(expectedFailureReason, model.FailureReason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreviewResult
        {
            DeviceID = "device_id",
            ScreenshotUrl = "screenshot_url",
            Status = PreviewResultStatus.Pending,
            ThumbnailUrl = "thumbnail_url",
            FailureReason = PreviewResultFailureReason.DeliveryFailed,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreviewResult
        {
            DeviceID = "device_id",
            ScreenshotUrl = "screenshot_url",
            Status = PreviewResultStatus.Pending,
            ThumbnailUrl = "thumbnail_url",
            FailureReason = PreviewResultFailureReason.DeliveryFailed,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDeviceID = "device_id";
        string expectedScreenshotUrl = "screenshot_url";
        ApiEnum<string, PreviewResultStatus> expectedStatus = PreviewResultStatus.Pending;
        string expectedThumbnailUrl = "thumbnail_url";
        ApiEnum<string, PreviewResultFailureReason> expectedFailureReason =
            PreviewResultFailureReason.DeliveryFailed;

        Assert.Equal(expectedDeviceID, deserialized.DeviceID);
        Assert.Equal(expectedScreenshotUrl, deserialized.ScreenshotUrl);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedThumbnailUrl, deserialized.ThumbnailUrl);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreviewResult
        {
            DeviceID = "device_id",
            ScreenshotUrl = "screenshot_url",
            Status = PreviewResultStatus.Pending,
            ThumbnailUrl = "thumbnail_url",
            FailureReason = PreviewResultFailureReason.DeliveryFailed,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PreviewResult
        {
            DeviceID = "device_id",
            ScreenshotUrl = "screenshot_url",
            Status = PreviewResultStatus.Pending,
            ThumbnailUrl = "thumbnail_url",
        };

        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failure_reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PreviewResult
        {
            DeviceID = "device_id",
            ScreenshotUrl = "screenshot_url",
            Status = PreviewResultStatus.Pending,
            ThumbnailUrl = "thumbnail_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PreviewResult
        {
            DeviceID = "device_id",
            ScreenshotUrl = "screenshot_url",
            Status = PreviewResultStatus.Pending,
            ThumbnailUrl = "thumbnail_url",

            // Null should be interpreted as omitted for these properties
            FailureReason = null,
        };

        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failure_reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PreviewResult
        {
            DeviceID = "device_id",
            ScreenshotUrl = "screenshot_url",
            Status = PreviewResultStatus.Pending,
            ThumbnailUrl = "thumbnail_url",

            // Null should be interpreted as omitted for these properties
            FailureReason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreviewResult
        {
            DeviceID = "device_id",
            ScreenshotUrl = "screenshot_url",
            Status = PreviewResultStatus.Pending,
            ThumbnailUrl = "thumbnail_url",
            FailureReason = PreviewResultFailureReason.DeliveryFailed,
        };

        PreviewResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
