using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Profiles;

/// <summary>
/// Update a profile
/// </summary>
public sealed record class ProfileUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? UserID { get; init; }

    /// <summary>
    /// List of patch operations to apply to the profile.
    /// </summary>
    public required List<Patch> Patch
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("patch", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'patch' cannot be null",
                    new ArgumentOutOfRangeException("patch", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Patch>>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'patch' cannot be null",
                    new ArgumentNullException("patch")
                );
        }
        init
        {
            this._rawBodyData["patch"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ProfileUpdateParams() { }

    public ProfileUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static ProfileUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/profiles/{0}", this.UserID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Patch, PatchFromRaw>))]
public sealed record class Patch : ModelBase
{
    /// <summary>
    /// The operation to perform.
    /// </summary>
    public required string Op
    {
        get
        {
            if (!this._rawData.TryGetValue("op", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'op' cannot be null",
                    new ArgumentOutOfRangeException("op", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'op' cannot be null",
                    new ArgumentNullException("op")
                );
        }
        init
        {
            this._rawData["op"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The JSON path specifying the part of the profile to operate on.
    /// </summary>
    public required string Path
    {
        get
        {
            if (!this._rawData.TryGetValue("path", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'path' cannot be null",
                    new ArgumentOutOfRangeException("path", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'path' cannot be null",
                    new ArgumentNullException("path")
                );
        }
        init
        {
            this._rawData["path"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The value for the operation.
    /// </summary>
    public required string Value
    {
        get
        {
            if (!this._rawData.TryGetValue("value", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'value' cannot be null",
                    new ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'value' cannot be null",
                    new ArgumentNullException("value")
                );
        }
        init
        {
            this._rawData["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Op;
        _ = this.Path;
        _ = this.Value;
    }

    public Patch() { }

    public Patch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Patch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Patch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PatchFromRaw : IFromRaw<Patch>
{
    public Patch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Patch.FromRawUnchecked(rawData);
}
