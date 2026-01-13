using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<MsTeamsBaseProperties, MsTeamsBasePropertiesFromRaw>))]
public sealed record class MsTeamsBaseProperties : JsonModel
{
    public required string ServiceUrl
    {
        get { return this._rawData.GetNotNullClass<string>("service_url"); }
        init { this._rawData.Set("service_url", value); }
    }

    public required string TenantID
    {
        get { return this._rawData.GetNotNullClass<string>("tenant_id"); }
        init { this._rawData.Set("tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ServiceUrl;
        _ = this.TenantID;
    }

    public MsTeamsBaseProperties() { }

    public MsTeamsBaseProperties(MsTeamsBaseProperties msTeamsBaseProperties)
        : base(msTeamsBaseProperties) { }

    public MsTeamsBaseProperties(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MsTeamsBaseProperties(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MsTeamsBasePropertiesFromRaw.FromRawUnchecked"/>
    public static MsTeamsBaseProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MsTeamsBasePropertiesFromRaw : IFromRawJson<MsTeamsBaseProperties>
{
    /// <inheritdoc/>
    public MsTeamsBaseProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MsTeamsBaseProperties.FromRawUnchecked(rawData);
}
