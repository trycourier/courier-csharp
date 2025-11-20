using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Profiles.Lists;

/// <summary>
/// Subscribes the given user to one or more lists. If the list does not exist, it
/// will be created.
/// </summary>
public sealed record class ListSubscribeParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public string? UserID { get; init; }

    public required List<SubscribeToListsRequestItem> Lists
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("lists", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'lists' cannot be null",
                    new ArgumentOutOfRangeException("lists", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<SubscribeToListsRequestItem>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'lists' cannot be null",
                    new ArgumentNullException("lists")
                );
        }
        init
        {
            this._bodyProperties["lists"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ListSubscribeParams() { }

    public ListSubscribeParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListSubscribeParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static ListSubscribeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/profiles/{0}/lists", this.UserID)
        )
        {
            Query = this.QueryString(options),
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

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
