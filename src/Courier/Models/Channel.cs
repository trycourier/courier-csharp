using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<Channel, ChannelFromRaw>))]
public sealed record class Channel : JsonModel
{
    /// <summary>
    /// Brand id used for rendering.
    /// </summary>
    public string? BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

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

    public ChannelMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChannelMetadata>("metadata");
        }
        init { this._rawData.Set("metadata", value); }
    }

    /// <summary>
    /// Channel specific overrides.
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

    /// <summary>
    /// Providers enabled for this channel.
    /// </summary>
    public IReadOnlyList<string>? Providers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("providers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "providers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Defaults to `single`.
    /// </summary>
    public ApiEnum<string, RoutingMethod>? RoutingMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RoutingMethod>>("routing_method");
        }
        init { this._rawData.Set("routing_method", value); }
    }

    public Timeouts? Timeouts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Timeouts>("timeouts");
        }
        init { this._rawData.Set("timeouts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.If;
        this.Metadata?.Validate();
        _ = this.Override;
        _ = this.Providers;
        this.RoutingMethod?.Validate();
        this.Timeouts?.Validate();
    }

    public Channel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Channel(Channel channel)
        : base(channel) { }
#pragma warning restore CS8618

    public Channel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Channel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelFromRaw.FromRawUnchecked"/>
    public static Channel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelFromRaw : IFromRawJson<Channel>
{
    /// <inheritdoc/>
    public Channel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Channel.FromRawUnchecked(rawData);
}

/// <summary>
/// Defaults to `single`.
/// </summary>
[JsonConverter(typeof(RoutingMethodConverter))]
public enum RoutingMethod
{
    All,
    Single,
}

sealed class RoutingMethodConverter : JsonConverter<RoutingMethod>
{
    public override RoutingMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => RoutingMethod.All,
            "single" => RoutingMethod.Single,
            _ => (RoutingMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RoutingMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RoutingMethod.All => "all",
                RoutingMethod.Single => "single",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
