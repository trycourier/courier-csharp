using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

/// <summary>
/// Tenant context shared by every MS Teams send variant. Provide at least one of
/// `tenant_id` or `service_url`. If you provide both, they must agree — a `service_url`
/// pointing at a different Microsoft tenant than `tenant_id` is rejected.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MsTeamsBaseProperties, MsTeamsBasePropertiesFromRaw>))]
public sealed record class MsTeamsBaseProperties : JsonModel
{
    public string? ServiceUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("service_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("service_url", value);
        }
    }

    public string? TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tenant_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tenant_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ServiceUrl;
        _ = this.TenantID;
    }

    public MsTeamsBaseProperties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MsTeamsBaseProperties(MsTeamsBaseProperties msTeamsBaseProperties)
        : base(msTeamsBaseProperties) { }
#pragma warning restore CS8618

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
