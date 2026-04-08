using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.Notifications;

namespace Courier.Models.RoutingStrategies;

/// <summary>
/// Paginated list of notification templates associated with a routing strategy.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AssociatedNotificationListResponse,
        AssociatedNotificationListResponseFromRaw
    >)
)]
public sealed record class AssociatedNotificationListResponse : JsonModel
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

    public required IReadOnlyList<NotificationTemplateSummary> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<NotificationTemplateSummary>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<NotificationTemplateSummary>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public AssociatedNotificationListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssociatedNotificationListResponse(
        AssociatedNotificationListResponse associatedNotificationListResponse
    )
        : base(associatedNotificationListResponse) { }
#pragma warning restore CS8618

    public AssociatedNotificationListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AssociatedNotificationListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AssociatedNotificationListResponseFromRaw.FromRawUnchecked"/>
    public static AssociatedNotificationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AssociatedNotificationListResponseFromRaw : IFromRawJson<AssociatedNotificationListResponse>
{
    /// <inheritdoc/>
    public AssociatedNotificationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AssociatedNotificationListResponse.FromRawUnchecked(rawData);
}
