using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Providers;

/// <summary>
/// Applies JSON Patch (RFC 6902) operations to a provider configuration and keeps
/// every field the operations don't touch. Paths address the provider as it is returned:
/// /title, /alias and /settings/&lt;key&gt;. The operations apply in order, and
/// if one fails, nothing is saved.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ProviderPatchParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Operations to apply, in order. Paths address the provider as it is returned:
    /// `/title`, `/alias`, `/provider`, and `/settings/&lt;key&gt;` with the snake_case
    /// setting keys, including nested paths such as `/settings/rate_limit/rate`.
    /// If any operation fails, for example a `test`, nothing is saved and the request
    /// returns a 400. The result can't change `provider`, remove `title`, or add
    /// other top-level fields. Removing `/alias` clears it.
    /// </summary>
    public required IReadOnlyList<Patch> Patch
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Patch>>("patch");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Patch>>(
                "patch",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ProviderPatchParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProviderPatchParams(ProviderPatchParams providerPatchParams)
        : base(providerPatchParams)
    {
        this.ID = providerPatchParams.ID;

        this._rawBodyData = new(providerPatchParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProviderPatchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProviderPatchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ProviderPatchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ProviderPatchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/providers/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// One JSON Patch (RFC 6902) operation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Patch, PatchFromRaw>))]
public sealed record class Patch : JsonModel
{
    /// <summary>
    /// The operation to perform.
    /// </summary>
    public required ApiEnum<string, Op> Op
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Op>>("op");
        }
        init { this._rawData.Set("op", value); }
    }

    /// <summary>
    /// JSON Pointer to the field to operate on, such as `/settings/api_key`.
    /// </summary>
    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <summary>
    /// JSON Pointer to the source field for `move` and `copy`.
    /// </summary>
    public string? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// The value for `add`, `replace` and `test`. Any JSON value.
    /// </summary>
    public JsonElement? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Op.Validate();
        _ = this.Path;
        _ = this.From;
        _ = this.Value;
    }

    public Patch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Patch(Patch patch)
        : base(patch) { }
#pragma warning restore CS8618

    public Patch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Patch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PatchFromRaw.FromRawUnchecked"/>
    public static Patch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PatchFromRaw : IFromRawJson<Patch>
{
    /// <inheritdoc/>
    public Patch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Patch.FromRawUnchecked(rawData);
}

/// <summary>
/// The operation to perform.
/// </summary>
[JsonConverter(typeof(OpConverter))]
public enum Op
{
    Add,
    Remove,
    Replace,
    Move,
    Copy,
    Test,
}

sealed class OpConverter : JsonConverter<Op>
{
    public override Op Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "add" => Op.Add,
            "remove" => Op.Remove,
            "replace" => Op.Replace,
            "move" => Op.Move,
            "copy" => Op.Copy,
            "test" => Op.Test,
            _ => (Op)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Op value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Op.Add => "add",
                Op.Remove => "remove",
                Op.Replace => "replace",
                Op.Move => "move",
                Op.Copy => "copy",
                Op.Test => "test",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
