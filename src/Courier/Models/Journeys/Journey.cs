using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Journeys;

/// <summary>
/// A journey template representing an automation workflow.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Journey, JourneyFromRaw>))]
public sealed record class Journey : JsonModel
{
    /// <summary>
    /// The unique identifier of the journey.
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
    /// The name of the journey.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The version of the journey (published or draft).
    /// </summary>
    public required ApiEnum<string, JourneyVersion> Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyVersion>>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the journey was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the journey was last updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        this.Version.Validate();
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public Journey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Journey(Journey journey)
        : base(journey) { }
#pragma warning restore CS8618

    public Journey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Journey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyFromRaw.FromRawUnchecked"/>
    public static Journey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyFromRaw : IFromRawJson<Journey>
{
    /// <inheritdoc/>
    public Journey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Journey.FromRawUnchecked(rawData);
}

/// <summary>
/// The version of the journey (published or draft).
/// </summary>
[JsonConverter(typeof(JourneyVersionConverter))]
public enum JourneyVersion
{
    Published,
    Draft,
}

sealed class JourneyVersionConverter : JsonConverter<JourneyVersion>
{
    public override JourneyVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "published" => JourneyVersion.Published,
            "draft" => JourneyVersion.Draft,
            _ => (JourneyVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyVersion.Published => "published",
                JourneyVersion.Draft => "draft",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
