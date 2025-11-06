using System;
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
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string UserID;

    /// <summary>
    /// List of patch operations to apply to the profile.
    /// </summary>
    public required List<Patch> Patch
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("patch", out JsonElement element))
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
        set
        {
            this.BodyProperties["patch"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/profiles/{0}", this.UserID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ICourierClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Patch>))]
public sealed record class Patch : ModelBase, IFromRaw<Patch>
{
    /// <summary>
    /// The operation to perform.
    /// </summary>
    public required string Op
    {
        get
        {
            if (!this.Properties.TryGetValue("op", out JsonElement element))
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
        set
        {
            this.Properties["op"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("path", out JsonElement element))
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
        set
        {
            this.Properties["path"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("value", out JsonElement element))
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
        set
        {
            this.Properties["value"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Patch(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Patch FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
