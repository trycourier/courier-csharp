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
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "has_more"); }
        init { ModelBase.Set(this._rawData, "has_more", value); }
    }

    /// <summary>
    /// Always set to `list`. Represents the type of this object.
    /// </summary>
    public required ApiEnum<string, global::Courier.Models.Tenants.Templates.Type> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Tenants.Templates.Type>
            >(this.RawData, "type");
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// A url that may be used to generate these results.
    /// </summary>
    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    /// <summary>
    /// A pointer to the next page of results. Defined  only when `has_more` is set
    /// to true
    /// </summary>
    public string? Cursor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "cursor"); }
        init { ModelBase.Set(this._rawData, "cursor", value); }
    }

    public IReadOnlyList<global::Courier.Models.Tenants.Templates.Item>? Items
    {
        get
        {
            return ModelBase.GetNullableClass<List<global::Courier.Models.Tenants.Templates.Item>>(
                this.RawData,
                "items"
            );
        }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    /// <summary>
    /// A url that may be used to generate fetch the next set of results.  Defined
    /// only when `has_more` is set to true
    /// </summary>
    public string? NextURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "next_url"); }
        init { ModelBase.Set(this._rawData, "next_url", value); }
    }

    /// <inheritdoc/>
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

    public TemplateListResponse(TemplateListResponse templateListResponse)
        : base(templateListResponse) { }

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

    /// <inheritdoc cref="TemplateListResponseFromRaw.FromRawUnchecked"/>
    public static TemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateListResponseFromRaw : IFromRaw<TemplateListResponse>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The timestamp at which the template was created
    /// </summary>
    public required string CreatedAt
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The timestamp at which the template was published
    /// </summary>
    public required string PublishedAt
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "published_at"); }
        init { ModelBase.Set(this._rawData, "published_at", value); }
    }

    /// <summary>
    /// The timestamp at which the template was last updated
    /// </summary>
    public required string UpdatedAt
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "updated_at"); }
        init { ModelBase.Set(this._rawData, "updated_at", value); }
    }

    /// <summary>
    /// The version of the template
    /// </summary>
    public required string Version
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "version"); }
        init { ModelBase.Set(this._rawData, "version", value); }
    }

    /// <summary>
    /// The template's data containing it's routing configs
    /// </summary>
    public required Data Data
    {
        get { return ModelBase.GetNotNullClass<Data>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
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

    /// <inheritdoc/>
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

    public Item(global::Courier.Models.Tenants.Templates.Item item)
        : base(item) { }

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

    /// <inheritdoc cref="global::Courier.Models.Tenants.Templates.ItemFromRaw.FromRawUnchecked"/>
    public static global::Courier.Models.Tenants.Templates.Item FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRaw<global::Courier.Models.Tenants.Templates.Item>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullClass<Data>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public IntersectionMember1() { }

    public IntersectionMember1(
        global::Courier.Models.Tenants.Templates.IntersectionMember1 intersectionMember1
    )
        : base(intersectionMember1) { }

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

    /// <inheritdoc cref="global::Courier.Models.Tenants.Templates.IntersectionMember1FromRaw.FromRawUnchecked"/>
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
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullClass<MessageRouting>(this.RawData, "routing"); }
        init { ModelBase.Set(this._rawData, "routing", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Routing.Validate();
    }

    public Data() { }

    public Data(Data data)
        : base(data) { }

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

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
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
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
