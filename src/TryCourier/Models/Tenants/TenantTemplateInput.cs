using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Tenants;

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
    public IReadOnlyDictionary<string, Channel>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, Channel>>("channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, Channel>?>(
                "channels",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Provider-specific delivery configuration for routing to specific email/SMS providers
    /// </summary>
    public IReadOnlyDictionary<string, MessageProvidersType>? Providers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, MessageProvidersType>>(
                "providers"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, MessageProvidersType>?>(
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
