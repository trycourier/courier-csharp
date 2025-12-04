using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Tenants;

[JsonConverter(typeof(ModelConverter<Tenant, TenantFromRaw>))]
public sealed record class Tenant : ModelBase
{
    /// <summary>
    /// Id of the tenant.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Name of the tenant.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Brand to be used for the account when one is not specified by the send call.
    /// </summary>
    public string? BrandID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "brand_id"); }
        init { ModelBase.Set(this._rawData, "brand_id", value); }
    }

    /// <summary>
    /// Defines the preferences used for the account when the user hasn't specified
    /// their own.
    /// </summary>
    public DefaultPreferences? DefaultPreferences
    {
        get
        {
            return ModelBase.GetNullableClass<DefaultPreferences>(
                this.RawData,
                "default_preferences"
            );
        }
        init { ModelBase.Set(this._rawData, "default_preferences", value); }
    }

    /// <summary>
    /// Tenant's parent id (if any).
    /// </summary>
    public string? ParentTenantID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "parent_tenant_id"); }
        init { ModelBase.Set(this._rawData, "parent_tenant_id", value); }
    }

    /// <summary>
    /// Arbitrary properties accessible to a template.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Properties
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "properties"
            );
        }
        init { ModelBase.Set(this._rawData, "properties", value); }
    }

    /// <summary>
    /// A user profile object merged with user profile on send.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? UserProfile
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "user_profile"
            );
        }
        init { ModelBase.Set(this._rawData, "user_profile", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.BrandID;
        this.DefaultPreferences?.Validate();
        _ = this.ParentTenantID;
        _ = this.Properties;
        _ = this.UserProfile;
    }

    public Tenant() { }

    public Tenant(Tenant tenant)
        : base(tenant) { }

    public Tenant(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tenant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TenantFromRaw.FromRawUnchecked"/>
    public static Tenant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TenantFromRaw : IFromRaw<Tenant>
{
    /// <inheritdoc/>
    public Tenant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tenant.FromRawUnchecked(rawData);
}
