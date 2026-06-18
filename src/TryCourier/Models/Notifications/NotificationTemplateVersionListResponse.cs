using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications;

[JsonConverter(
    typeof(JsonModelConverter<
        NotificationTemplateVersionListResponse,
        NotificationTemplateVersionListResponseFromRaw
    >)
)]
public sealed record class NotificationTemplateVersionListResponse : JsonModel
{
    public required Paging Paging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Paging>("paging");
        }
        init { this._rawData.Set("paging", value); }
    }

    public required IReadOnlyList<VersionNode> Versions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<VersionNode>>("versions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<VersionNode>>(
                "versions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Versions)
        {
            item.Validate();
        }
    }

    public NotificationTemplateVersionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateVersionListResponse(
        NotificationTemplateVersionListResponse notificationTemplateVersionListResponse
    )
        : base(notificationTemplateVersionListResponse) { }
#pragma warning restore CS8618

    public NotificationTemplateVersionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateVersionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateVersionListResponseFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateVersionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateVersionListResponseFromRaw
    : IFromRawJson<NotificationTemplateVersionListResponse>
{
    /// <inheritdoc/>
    public NotificationTemplateVersionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateVersionListResponse.FromRawUnchecked(rawData);
}
