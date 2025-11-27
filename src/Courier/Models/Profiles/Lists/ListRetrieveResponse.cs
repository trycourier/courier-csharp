using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Profiles.Lists;

[JsonConverter(typeof(ModelConverter<ListRetrieveResponse, ListRetrieveResponseFromRaw>))]
public sealed record class ListRetrieveResponse : ModelBase
{
    public required Paging Paging
    {
        get
        {
            if (!this._rawData.TryGetValue("paging", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'paging' cannot be null",
                    new ArgumentOutOfRangeException("paging", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Paging>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'paging' cannot be null",
                    new ArgumentNullException("paging")
                );
        }
        init
        {
            this._rawData["paging"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of lists
    /// </summary>
    public required IReadOnlyList<Result> Results
    {
        get
        {
            if (!this._rawData.TryGetValue("results", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'results' cannot be null",
                    new ArgumentOutOfRangeException("results", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Result>>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'results' cannot be null",
                    new ArgumentNullException("results")
                );
        }
        init
        {
            this._rawData["results"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public ListRetrieveResponse() { }

    public ListRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ListRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListRetrieveResponseFromRaw : IFromRaw<ListRetrieveResponse>
{
    public ListRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ListRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
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
    /// The date/time of when the list was created. Represented as a string in ISO format.
    /// </summary>
    public required string Created
    {
        get
        {
            if (!this._rawData.TryGetValue("created", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'created' cannot be null",
                    new ArgumentOutOfRangeException("created", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'created' cannot be null",
                    new ArgumentNullException("created")
                );
        }
        init
        {
            this._rawData["created"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List name
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The date/time of when the list was updated. Represented as a string in ISO format.
    /// </summary>
    public required string Updated
    {
        get
        {
            if (!this._rawData.TryGetValue("updated", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'updated' cannot be null",
                    new ArgumentOutOfRangeException("updated", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'updated' cannot be null",
                    new ArgumentNullException("updated")
                );
        }
        init
        {
            this._rawData["updated"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            if (!this._rawData.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RecipientPreferences?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        _ = this.Name;
        _ = this.Updated;
        this.Preferences?.Validate();
    }

    public Result() { }

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRaw<Result>
{
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}
