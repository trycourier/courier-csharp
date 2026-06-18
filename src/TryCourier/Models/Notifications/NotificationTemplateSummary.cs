using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Notifications;

/// <summary>
/// V2 (CDS) template summary returned in list responses.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<NotificationTemplateSummary, NotificationTemplateSummaryFromRaw>)
)]
public sealed record class NotificationTemplateSummary : JsonModel
{
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
    /// Epoch milliseconds when the template was created.
    /// </summary>
    public required long Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// User ID of the creator.
    /// </summary>
    public required string Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creator");
        }
        init { this._rawData.Set("creator", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, NotificationTemplateSummaryState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NotificationTemplateSummaryState>>(
                "state"
            );
        }
        init { this._rawData.Set("state", value); }
    }

    public required IReadOnlyList<string> Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "tags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Epoch milliseconds of last update.
    /// </summary>
    public long? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("updated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated", value);
        }
    }

    /// <summary>
    /// User ID of the last updater.
    /// </summary>
    public string? Updater
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updater");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updater", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        _ = this.Creator;
        _ = this.Name;
        this.State.Validate();
        _ = this.Tags;
        _ = this.Updated;
        _ = this.Updater;
    }

    public NotificationTemplateSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateSummary(NotificationTemplateSummary notificationTemplateSummary)
        : base(notificationTemplateSummary) { }
#pragma warning restore CS8618

    public NotificationTemplateSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateSummaryFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateSummaryFromRaw : IFromRawJson<NotificationTemplateSummary>
{
    /// <inheritdoc/>
    public NotificationTemplateSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateSummary.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NotificationTemplateSummaryStateConverter))]
public enum NotificationTemplateSummaryState
{
    Draft,
    Published,
}

sealed class NotificationTemplateSummaryStateConverter
    : JsonConverter<NotificationTemplateSummaryState>
{
    public override NotificationTemplateSummaryState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => NotificationTemplateSummaryState.Draft,
            "PUBLISHED" => NotificationTemplateSummaryState.Published,
            _ => (NotificationTemplateSummaryState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationTemplateSummaryState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotificationTemplateSummaryState.Draft => "DRAFT",
                NotificationTemplateSummaryState.Published => "PUBLISHED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
