using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

[JsonConverter(typeof(JsonModelConverter<MessageProvidersType, MessageProvidersTypeFromRaw>))]
public sealed record class MessageProvidersType : JsonModel
{
    /// <summary>
    /// JS conditional with access to data/profile.
    /// </summary>
    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public Metadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metadata>("metadata");
        }
        init { this._rawData.Set("metadata", value); }
    }

    /// <summary>
    /// Provider-specific overrides.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Override
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "override"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "override",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public long? Timeouts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("timeouts");
        }
        init { this._rawData.Set("timeouts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.If;
        this.Metadata?.Validate();
        _ = this.Override;
        _ = this.Timeouts;
    }

    public MessageProvidersType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageProvidersType(MessageProvidersType messageProvidersType)
        : base(messageProvidersType) { }
#pragma warning restore CS8618

    public MessageProvidersType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageProvidersType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageProvidersTypeFromRaw.FromRawUnchecked"/>
    public static MessageProvidersType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageProvidersTypeFromRaw : IFromRawJson<MessageProvidersType>
{
    /// <inheritdoc/>
    public MessageProvidersType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageProvidersType.FromRawUnchecked(rawData);
}
