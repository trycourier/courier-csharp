using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// Optional page metadata to apply when publishing the workspace's preferences page.
/// All fields are optional; omitted fields fall back to the page defaults (and the
/// workspace default brand).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PublishPreferencesRequest, PublishPreferencesRequestFromRaw>)
)]
public sealed record class PublishPreferencesRequest : JsonModel
{
    /// <summary>
    /// Brand for the hosted page - "default" (workspace default brand), "none" (no
    /// brand), or a specific brand id. Defaults to "default".
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
    /// Description shown under the heading on the hosted preferences page.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Heading shown at the top of the hosted preferences page.
    /// </summary>
    public string? Heading
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("heading");
        }
        init { this._rawData.Set("heading", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.Description;
        _ = this.Heading;
    }

    public PublishPreferencesRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PublishPreferencesRequest(PublishPreferencesRequest publishPreferencesRequest)
        : base(publishPreferencesRequest) { }
#pragma warning restore CS8618

    public PublishPreferencesRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PublishPreferencesRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PublishPreferencesRequestFromRaw.FromRawUnchecked"/>
    public static PublishPreferencesRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PublishPreferencesRequestFromRaw : IFromRawJson<PublishPreferencesRequest>
{
    /// <inheritdoc/>
    public PublishPreferencesRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PublishPreferencesRequest.FromRawUnchecked(rawData);
}
