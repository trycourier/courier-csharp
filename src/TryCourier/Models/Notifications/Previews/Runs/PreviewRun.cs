using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications.Previews.Runs;

/// <summary>
/// One render of a template across a set of devices. Billable.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PreviewRun, PreviewRunFromRaw>))]
public sealed record class PreviewRun : JsonModel
{
    /// <summary>
    /// Unique identifier for the preview run.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// ISO-8601 timestamp of when the run was created.
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The devices this run was submitted for, snapshotted when the run was created.
    /// </summary>
    public required IReadOnlyList<string> DeviceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("device_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "device_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Where the run itself has got to. `PENDING` and `RENDERED` mean Courier is
    /// still preparing the email, `SUBMITTED` means it is with the rendering service,
    /// and `COMPLETED` means every device has reported. `FAILED` is the run as a
    /// whole failing — an individual device failing never fails the run.
    /// </summary>
    public required ApiEnum<string, PreviewRunStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PreviewRunStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The template that was rendered.
    /// </summary>
    public required string TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("template_id");
        }
        init { this._rawData.Set("template_id", value); }
    }

    /// <summary>
    /// Why the run failed, when `status` is `FAILED`. `NO_EMAIL_CHANNEL` and `TEMPLATE_NOT_SUPPORTED`
    /// mean there was nothing to render; `ALL_DEVICES_UNSUPPORTED` means every requested
    /// device has been retired and the request can be fixed by choosing others.
    /// </summary>
    public ApiEnum<string, PreviewRunFailureReason>? FailureReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PreviewRunFailureReason>>(
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

    /// <summary>
    /// The version of the template that was rendered — `draft`, or a zero-padded
    /// published version such as `v002`. Absent until the render settles.
    /// </summary>
    public string? TemplateVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template_version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DeviceIds;
        this.Status.Validate();
        _ = this.TemplateID;
        this.FailureReason?.Validate();
        _ = this.TemplateVersion;
    }

    public PreviewRun() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreviewRun(PreviewRun previewRun)
        : base(previewRun) { }
#pragma warning restore CS8618

    public PreviewRun(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreviewRun(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreviewRunFromRaw.FromRawUnchecked"/>
    public static PreviewRun FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreviewRunFromRaw : IFromRawJson<PreviewRun>
{
    /// <inheritdoc/>
    public PreviewRun FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PreviewRun.FromRawUnchecked(rawData);
}
