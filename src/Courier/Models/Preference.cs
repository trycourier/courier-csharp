using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<Preference, PreferenceFromRaw>))]
public sealed record class Preference : ModelBase
{
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, PreferenceStatus>>(
                this.RawData,
                "status"
            );
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public IReadOnlyList<ChannelPreference>? ChannelPreferences
    {
        get
        {
            return ModelBase.GetNullableClass<List<ChannelPreference>>(
                this.RawData,
                "channel_preferences"
            );
        }
        init { ModelBase.Set(this._rawData, "channel_preferences", value); }
    }

    public IReadOnlyList<Rule>? Rules
    {
        get { return ModelBase.GetNullableClass<List<Rule>>(this.RawData, "rules"); }
        init { ModelBase.Set(this._rawData, "rules", value); }
    }

    public ApiEnum<string, Source>? Source
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Source>>(this.RawData, "source"); }
        init { ModelBase.Set(this._rawData, "source", value); }
    }

    /// <inheritdoc/>
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

    public Preference(Preference preference)
        : base(preference) { }

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

    /// <inheritdoc cref="PreferenceFromRaw.FromRawUnchecked"/>
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

class PreferenceFromRaw : IFromRaw<Preference>
{
    /// <inheritdoc/>
    public Preference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Preference.FromRawUnchecked(rawData);
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
