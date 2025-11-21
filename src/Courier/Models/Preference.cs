using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<Preference>))]
public sealed record class Preference : ModelBase, IFromRaw<Preference>
{
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<ChannelPreference>? ChannelPreferences
    {
        get
        {
            if (!this._rawData.TryGetValue("channel_preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ChannelPreference>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["channel_preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<Rule>? Rules
    {
        get
        {
            if (!this._rawData.TryGetValue("rules", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Rule>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["rules"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Source>? Source
    {
        get
        {
            if (!this._rawData.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Source>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Status.Validate();
        foreach (var item in this.ChannelPreferences ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Rules ?? [])
        {
            item.Validate();
        }
        this.Source?.Validate();
    }

    public Preference() { }

    public Preference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Preference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Preference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Preference(ApiEnum<string, PreferenceStatus> status)
        : this()
    {
        this.Status = status;
    }
}

[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Subscription,
    List,
    Recipient,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription" => Source.Subscription,
            "list" => Source.List,
            "recipient" => Source.Recipient,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Subscription => "subscription",
                Source.List => "list",
                Source.Recipient => "recipient",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
