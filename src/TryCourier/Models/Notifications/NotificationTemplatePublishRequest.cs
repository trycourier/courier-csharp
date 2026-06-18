using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications;

/// <summary>
/// Optional request body for publishing a notification template. Omit or send an
/// empty object to publish the current draft.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NotificationTemplatePublishRequest,
        NotificationTemplatePublishRequestFromRaw
    >)
)]
public sealed record class NotificationTemplatePublishRequest : JsonModel
{
    /// <summary>
    /// Historical version to publish (e.g. "v001"). Omit to publish the current draft.
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Version;
    }

    public NotificationTemplatePublishRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplatePublishRequest(
        NotificationTemplatePublishRequest notificationTemplatePublishRequest
    )
        : base(notificationTemplatePublishRequest) { }
#pragma warning restore CS8618

    public NotificationTemplatePublishRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplatePublishRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplatePublishRequestFromRaw.FromRawUnchecked"/>
    public static NotificationTemplatePublishRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplatePublishRequestFromRaw : IFromRawJson<NotificationTemplatePublishRequest>
{
    /// <inheritdoc/>
    public NotificationTemplatePublishRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplatePublishRequest.FromRawUnchecked(rawData);
}
