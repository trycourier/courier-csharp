using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<MessageContext, MessageContextFromRaw>))]
public sealed record class MessageContext : ModelBase
{
    /// <summary>
    /// Tenant id used to load brand/default preferences/context.
    /// </summary>
    public string? TenantID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "tenant_id"); }
        init { ModelBase.Set(this._rawData, "tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TenantID;
    }

    public MessageContext() { }

    public MessageContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageContextFromRaw.FromRawUnchecked"/>
    public static MessageContext FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageContextFromRaw : IFromRaw<MessageContext>
{
    /// <inheritdoc/>
    public MessageContext FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageContext.FromRawUnchecked(rawData);
}
