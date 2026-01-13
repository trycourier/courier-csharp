using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Tenants;

[JsonConverter(typeof(JsonModelConverter<Tenant, TenantFromRaw>))]
public sealed record class Tenant : JsonModel
{
    /// <summary>
    /// Id of the tenant.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Name of the tenant.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Brand to be used for the account when one is not specified by the send call.
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
    /// Defines the preferences used for the account when the user hasn't specified
    /// their own.
    /// </summary>
    public DefaultPreferences? DefaultPreferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DefaultPreferences>("default_preferences");
        }
        init { this._rawData.Set("default_preferences", value); }
    }

    /// <summary>
    /// Tenant's parent id (if any).
    /// </summary>
    public string? ParentTenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parent_tenant_id");
        }
        init { this._rawData.Set("parent_tenant_id", value); }
    }

    /// <summary>
    /// Arbitrary properties accessible to a template.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "properties",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A user profile object merged with user profile on send.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? UserProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "user_profile"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "user_profile",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tenant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TenantFromRaw.FromRawUnchecked"/>
    public static Tenant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TenantFromRaw : IFromRawJson<Tenant>
{
    /// <inheritdoc/>
    public Tenant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tenant.FromRawUnchecked(rawData);
}
