using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications.Previews.Runs;

/// <summary>
/// One device's result within a preview run.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PreviewResult, PreviewResultFromRaw>))]
public sealed record class PreviewResult : JsonModel
{
    /// <summary>
    /// The device this result is for, by `PreviewDevice.id`.
    /// </summary>
    public required string DeviceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("device_id");
        }
        init { this._rawData.Set("device_id", value); }
    }

    /// <summary>
    /// Short-lived signed URL for the full-sized image. Null until the screenshot
    /// exists. Re-signed on every read, so fetch it rather than storing it.
    /// </summary>
    public required string? ScreenshotUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("screenshot_url");
        }
        init { this._rawData.Set("screenshot_url", value); }
    }

    /// <summary>
    /// One device's outcome. `COMPLETED` means the screenshot exists and its URLs
    /// are populated. `UNSUPPORTED`, `TIMED_OUT` and `FAILED` are all terminal,
    /// and none stands in for another — `UNSUPPORTED` means the device was retired
    /// at the vendor, `TIMED_OUT` means it did not report in time.
    /// </summary>
    public required ApiEnum<string, PreviewResultStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PreviewResultStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Short-lived signed URL for the grid-sized image. Null until the screenshot
    /// exists. Re-signed on every read, so fetch it rather than storing it.
    /// </summary>
    public required string? ThumbnailUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("thumbnail_url");
        }
        init { this._rawData.Set("thumbnail_url", value); }
    }

    /// <summary>
    /// Why one device's render failed, when its `status` is `FAILED` and the cause
    /// has a public name. `DELIVERY_FAILED` means the rendering service could not
    /// deliver the message to its own capture mailbox — infrastructure, not anything
    /// wrong with the template.
    /// </summary>
    public ApiEnum<string, PreviewResultFailureReason>? FailureReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PreviewResultFailureReason>>(
                "failure_reason"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("failure_reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeviceID;
        _ = this.ScreenshotUrl;
        this.Status.Validate();
        _ = this.ThumbnailUrl;
        this.FailureReason?.Validate();
    }

    public PreviewResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreviewResult(PreviewResult previewResult)
        : base(previewResult) { }
#pragma warning restore CS8618

    public PreviewResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreviewResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreviewResultFromRaw.FromRawUnchecked"/>
    public static PreviewResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreviewResultFromRaw : IFromRawJson<PreviewResult>
{
    /// <inheritdoc/>
    public PreviewResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PreviewResult.FromRawUnchecked(rawData);
}
