using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Tenants.Templates;

[JsonConverter(typeof(ModelConverter<TemplateListResponse, TemplateListResponseFromRaw>))]
public sealed record class TemplateListResponse : ModelBase
{
    /// <summary>
    /// Set to true when there are more pages that can be retrieved.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            if (!this._rawData.TryGetValue("has_more", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'has_more' cannot be null",
                    new System::ArgumentOutOfRangeException("has_more", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["has_more"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Always set to `list`. Represents the type of this object.
    /// </summary>
    public required ApiEnum<string, global::Courier.Models.Tenants.Templates.Type> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Courier.Models.Tenants.Templates.Type>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A url that may be used to generate these results.
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this._rawData.TryGetValue("url", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentNullException("url")
                );
        }
        init
        {
            this._rawData["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A pointer to the next page of results. Defined  only when `has_more` is set
    /// to true
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this._rawData.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<global::Courier.Models.Tenants.Templates.Item>? Items
    {
        get
        {
            if (!this._rawData.TryGetValue("items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<global::Courier.Models.Tenants.Templates.Item>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A url that may be used to generate fetch the next set of results.  Defined
    /// only when `has_more` is set to true
    /// </summary>
    public string? NextURL
    {
        get
        {
            if (!this._rawData.TryGetValue("next_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["next_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.HasMore;
        this.Type.Validate();
        _ = this.URL;
        _ = this.Cursor;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.NextURL;
    }

    public TemplateListResponse() { }

    public TemplateListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static TemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateListResponseFromRaw : IFromRaw<TemplateListResponse>
{
    public TemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Always set to `list`. Represents the type of this object.
/// </summary>
[JsonConverter(typeof(global::Courier.Models.Tenants.Templates.TypeConverter))]
public enum Type
{
    List,
}

sealed class TypeConverter : JsonConverter<global::Courier.Models.Tenants.Templates.Type>
{
    public override global::Courier.Models.Tenants.Templates.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => global::Courier.Models.Tenants.Templates.Type.List,
            _ => (global::Courier.Models.Tenants.Templates.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Tenants.Templates.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Tenants.Templates.Type.List => "list",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Courier.Models.Tenants.Templates.Item,
        global::Courier.Models.Tenants.Templates.ItemFromRaw
    >)
)]
public sealed record class Item : ModelBase
{
    /// <summary>
    /// The template's id
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp at which the template was created
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentNullException("created_at")
                );
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp at which the template was published
    /// </summary>
    public required string PublishedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("published_at", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'published_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "published_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'published_at' cannot be null",
                    new System::ArgumentNullException("published_at")
                );
        }
        init
        {
            this._rawData["published_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp at which the template was last updated
    /// </summary>
    public required string UpdatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("updated_at", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'updated_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "updated_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'updated_at' cannot be null",
                    new System::ArgumentNullException("updated_at")
                );
        }
        init
        {
            this._rawData["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The version of the template
    /// </summary>
    public required string Version
    {
        get
        {
            if (!this._rawData.TryGetValue("version", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'version' cannot be null",
                    new System::ArgumentOutOfRangeException("version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'version' cannot be null",
                    new System::ArgumentNullException("version")
                );
        }
        init
        {
            this._rawData["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The template's data containing it's routing configs
    /// </summary>
    public required Data Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentNullException("data")
                );
        }
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator BaseTemplateTenantAssociation(
        global::Courier.Models.Tenants.Templates.Item item
    ) =>
        new()
        {
            ID = item.ID,
            CreatedAt = item.CreatedAt,
            PublishedAt = item.PublishedAt,
            UpdatedAt = item.UpdatedAt,
            Version = item.Version,
        };

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.PublishedAt;
        _ = this.UpdatedAt;
        _ = this.Version;
        this.Data.Validate();
    }

    public Item() { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Courier.Models.Tenants.Templates.Item FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRaw<global::Courier.Models.Tenants.Templates.Item>
{
    public global::Courier.Models.Tenants.Templates.Item FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Tenants.Templates.Item.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Courier.Models.Tenants.Templates.IntersectionMember1,
        global::Courier.Models.Tenants.Templates.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : ModelBase
{
    /// <summary>
    /// The template's data containing it's routing configs
    /// </summary>
    public required Data Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentNullException("data")
                );
        }
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Data.Validate();
    }

    public IntersectionMember1() { }

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Courier.Models.Tenants.Templates.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntersectionMember1(Data data)
        : this()
    {
        this.Data = data;
    }
}

class IntersectionMember1FromRaw
    : IFromRaw<global::Courier.Models.Tenants.Templates.IntersectionMember1>
{
    public global::Courier.Models.Tenants.Templates.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Tenants.Templates.IntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The template's data containing it's routing configs
/// </summary>
[JsonConverter(typeof(ModelConverter<Data, DataFromRaw>))]
public sealed record class Data : ModelBase
{
    public required MessageRouting Routing
    {
        get
        {
            if (!this._rawData.TryGetValue("routing", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'routing' cannot be null",
                    new System::ArgumentOutOfRangeException("routing", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MessageRouting>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'routing' cannot be null",
                    new System::ArgumentNullException("routing")
                );
        }
        init
        {
            this._rawData["routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Routing.Validate();
    }

    public Data() { }

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Data(MessageRouting routing)
        : this()
    {
        this.Routing = routing;
    }
}

class DataFromRaw : IFromRaw<Data>
{
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
