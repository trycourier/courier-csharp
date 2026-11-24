using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications;

/// <summary>
/// Elemental content of a notification template. Template variables read the data
/// sent with the message through the `data.` prefix, as in `{{data.name}}`, and the
/// recipient's profile through `profile.`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<NotificationTemplateContent, NotificationTemplateContentFromRaw>)
)]
public sealed record class NotificationTemplateContent : JsonModel
{
    public required IReadOnlyList<ElementalNode> Elements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ElementalNode>>("elements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ElementalNode>>(
                "elements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// For example, "2022-01-01"
    /// </summary>
    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        _ = this.Version;
    }

    public NotificationTemplateContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateContent(NotificationTemplateContent notificationTemplateContent)
        : base(notificationTemplateContent) { }
#pragma warning restore CS8618

    public NotificationTemplateContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateContentFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateContentFromRaw : IFromRawJson<NotificationTemplateContent>
{
    /// <inheritdoc/>
    public NotificationTemplateContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateContent.FromRawUnchecked(rawData);
}
