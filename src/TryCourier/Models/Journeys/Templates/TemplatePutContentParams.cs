using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Models.Notifications;

namespace TryCourier.Models.Journeys.Templates;

/// <summary>
/// Replace the elemental content of a journey-scoped notification template. Overwrites
/// all elements in the template draft with the provided content.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TemplatePutContentParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string TemplateID { get; init; }

    public string? NotificationID { get; init; }

    /// <summary>
    /// Elemental content payload. The server defaults `version` when omitted.
    /// </summary>
    public required TemplatePutContentParamsContent Content
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<TemplatePutContentParamsContent>("content");
        }
        init { this._rawBodyData.Set("content", value); }
    }

    /// <summary>
    /// Template state. Defaults to `DRAFT`.
    /// </summary>
    public ApiEnum<string, NotificationTemplateState>? State
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, NotificationTemplateState>>(
                "state"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("state", value);
        }
    }

    public TemplatePutContentParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplatePutContentParams(TemplatePutContentParams templatePutContentParams)
        : base(templatePutContentParams)
    {
        this.TemplateID = templatePutContentParams.TemplateID;
        this.NotificationID = templatePutContentParams.NotificationID;

        this._rawBodyData = new(templatePutContentParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TemplatePutContentParams(
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
    TemplatePutContentParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string templateID,
        string notificationID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.TemplateID = templateID;
        this.NotificationID = notificationID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TemplatePutContentParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string templateID,
        string notificationID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            templateID,
            notificationID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["TemplateID"] = JsonSerializer.SerializeToElement(this.TemplateID),
                    ["NotificationID"] = JsonSerializer.SerializeToElement(this.NotificationID),
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

    public virtual bool Equals(TemplatePutContentParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.TemplateID.Equals(other.TemplateID)
            && (this.NotificationID?.Equals(other.NotificationID) ?? other.NotificationID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/journeys/{0}/templates/{1}/content",
                    this.TemplateID,
                    this.NotificationID
                )
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
/// Elemental content payload. The server defaults `version` when omitted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TemplatePutContentParamsContent,
        TemplatePutContentParamsContentFromRaw
    >)
)]
public sealed record class TemplatePutContentParamsContent : JsonModel
{
    public required IReadOnlyList<ElementalNode> Elements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ElementalNode>>("elements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ElementalNode>>(
                "elements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Content version identifier (e.g., `2022-01-01`). Optional; server defaults
    /// when omitted.
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        _ = this.Version;
    }

    public TemplatePutContentParamsContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplatePutContentParamsContent(
        TemplatePutContentParamsContent templatePutContentParamsContent
    )
        : base(templatePutContentParamsContent) { }
#pragma warning restore CS8618

    public TemplatePutContentParamsContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplatePutContentParamsContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplatePutContentParamsContentFromRaw.FromRawUnchecked"/>
    public static TemplatePutContentParamsContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplatePutContentParamsContent(IReadOnlyList<ElementalNode> elements)
        : this()
    {
        this.Elements = elements;
    }
}

class TemplatePutContentParamsContentFromRaw : IFromRawJson<TemplatePutContentParamsContent>
{
    /// <inheritdoc/>
    public TemplatePutContentParamsContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplatePutContentParamsContent.FromRawUnchecked(rawData);
}
