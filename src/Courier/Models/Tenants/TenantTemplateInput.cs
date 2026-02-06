using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Tenants;

/// <summary>
/// Template configuration for creating or updating a tenant notification template
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TenantTemplateInput, TenantTemplateInputFromRaw>))]
public sealed record class TenantTemplateInput : JsonModel
{
    /// <summary>
    /// Template content configuration including blocks, elements, and message structure
    /// </summary>
    public required ElementalContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ElementalContent>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Channel-specific delivery configuration (email, SMS, push, etc.)
    /// </summary>
    public IReadOnlyDictionary<string, ChannelsItem>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, ChannelsItem>>(
                "channels"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, ChannelsItem>?>(
                "channels",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Provider-specific delivery configuration for routing to specific email/SMS providers
    /// </summary>
    public IReadOnlyDictionary<string, ProvidersItem>? Providers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, ProvidersItem>>(
                "providers"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, ProvidersItem>?>(
                "providers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Message routing configuration for multi-channel delivery strategies
    /// </summary>
    public MessageRouting? Routing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageRouting>("routing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("routing", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        if (this.Channels != null)
        {
            foreach (var item in this.Channels.Values)
            {
                item.Validate();
            }
        }
        if (this.Providers != null)
        {
            foreach (var item in this.Providers.Values)
            {
                item.Validate();
            }
        }
        this.Routing?.Validate();
    }

    public TenantTemplateInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenantTemplateInput(TenantTemplateInput tenantTemplateInput)
        : base(tenantTemplateInput) { }
#pragma warning restore CS8618

    public TenantTemplateInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenantTemplateInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TenantTemplateInputFromRaw.FromRawUnchecked"/>
    public static TenantTemplateInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TenantTemplateInput(ElementalContent content)
        : this()
    {
        this.Content = content;
    }
}

class TenantTemplateInputFromRaw : IFromRawJson<TenantTemplateInput>
{
    /// <inheritdoc/>
    public TenantTemplateInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TenantTemplateInput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ChannelsItem, ChannelsItemFromRaw>))]
public sealed record class ChannelsItem : JsonModel
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

    public ChannelsItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelsItem(ChannelsItem channelsItem)
        : base(channelsItem) { }
#pragma warning restore CS8618

    public ChannelsItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelsItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelsItemFromRaw.FromRawUnchecked"/>
    public static ChannelsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelsItemFromRaw : IFromRawJson<ChannelsItem>
{
    /// <inheritdoc/>
    public ChannelsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelsItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    public Utm? Utm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Utm>("utm");
        }
        init { this._rawData.Set("utm", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Utm?.Validate();
    }

    public Metadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metadata(Metadata metadata)
        : base(metadata) { }
#pragma warning restore CS8618

    public Metadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFromRaw.FromRawUnchecked"/>
    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRawJson<Metadata>
{
    /// <inheritdoc/>
    public Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metadata.FromRawUnchecked(rawData);
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

[JsonConverter(typeof(JsonModelConverter<Timeouts, TimeoutsFromRaw>))]
public sealed record class Timeouts : JsonModel
{
    public long? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    public long? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.Provider;
    }

    public Timeouts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Timeouts(Timeouts timeouts)
        : base(timeouts) { }
#pragma warning restore CS8618

    public Timeouts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeouts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeoutsFromRaw.FromRawUnchecked"/>
    public static Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeoutsFromRaw : IFromRawJson<Timeouts>
{
    /// <inheritdoc/>
    public Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Timeouts.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProvidersItem, ProvidersItemFromRaw>))]
public sealed record class ProvidersItem : JsonModel
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

    public ProvidersItemMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProvidersItemMetadata>("metadata");
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

    public ProvidersItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProvidersItem(ProvidersItem providersItem)
        : base(providersItem) { }
#pragma warning restore CS8618

    public ProvidersItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProvidersItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProvidersItemFromRaw.FromRawUnchecked"/>
    public static ProvidersItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProvidersItemFromRaw : IFromRawJson<ProvidersItem>
{
    /// <inheritdoc/>
    public ProvidersItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProvidersItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProvidersItemMetadata, ProvidersItemMetadataFromRaw>))]
public sealed record class ProvidersItemMetadata : JsonModel
{
    public Utm? Utm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Utm>("utm");
        }
        init { this._rawData.Set("utm", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Utm?.Validate();
    }

    public ProvidersItemMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProvidersItemMetadata(ProvidersItemMetadata providersItemMetadata)
        : base(providersItemMetadata) { }
#pragma warning restore CS8618

    public ProvidersItemMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProvidersItemMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProvidersItemMetadataFromRaw.FromRawUnchecked"/>
    public static ProvidersItemMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProvidersItemMetadataFromRaw : IFromRawJson<ProvidersItemMetadata>
{
    /// <inheritdoc/>
    public ProvidersItemMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProvidersItemMetadata.FromRawUnchecked(rawData);
}
