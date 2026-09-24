using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications.Previews.Runs;

/// <summary>
/// Request body for creating a preview run of the template in the path. Provide
/// exactly one of `device_set_id` or `device_ids`. The template is the path's `{id}`;
/// a `template_id` here is an unknown key and a 400.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreatePreviewRunRequest, CreatePreviewRunRequestFromRaw>))]
public sealed record class CreatePreviewRunRequest : JsonModel
{
    /// <summary>
    /// Template variables to render with, the same shape as the `data` object on
    /// a send.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The devices to render on, by `PreviewDevice.id`, for a one-off run. Mutually
    /// exclusive with `device_set_id`.
    /// </summary>
    public IReadOnlyList<string>? DeviceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("device_ids");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "device_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A saved device set naming the devices to render on. Mutually exclusive with `device_ids`.
    /// </summary>
    public string? DeviceSetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("device_set_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("device_set_id", value);
        }
    }

    /// <summary>
    /// Render the template's content for this locale, e.g. "fr-FR".
    /// </summary>
    public string? Locale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locale", value);
        }
    }

    /// <summary>
    /// Which version of the template to render. Omit for the latest saved draft,
    /// which always exists and is what the editor shows. `published` renders the
    /// live version; a zero-padded `v002` renders that specific publish. Versions
    /// are 1-based, so `v000` is not a version, and the unpadded `v2` is rejected
    /// — that spelling belongs to journeys' AutomationVersionId, a different scheme
    /// in which `v0` means published.
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
        _ = this.Data;
        _ = this.DeviceIds;
        _ = this.DeviceSetID;
        _ = this.Locale;
        _ = this.TemplateVersion;
    }

    public CreatePreviewRunRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatePreviewRunRequest(CreatePreviewRunRequest createPreviewRunRequest)
        : base(createPreviewRunRequest) { }
#pragma warning restore CS8618

    public CreatePreviewRunRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatePreviewRunRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatePreviewRunRequestFromRaw.FromRawUnchecked"/>
    public static CreatePreviewRunRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatePreviewRunRequestFromRaw : IFromRawJson<CreatePreviewRunRequest>
{
    /// <inheritdoc/>
    public CreatePreviewRunRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreatePreviewRunRequest.FromRawUnchecked(rawData);
}
