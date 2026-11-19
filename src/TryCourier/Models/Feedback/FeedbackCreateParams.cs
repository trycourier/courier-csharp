using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Feedback;

/// <summary>
/// Reports a suspected bug, confusing behavior or a missing feature in Courier.
/// It is built for AI agents and developer tools to call when Courier does something
/// unexpected, and people can call it too.
///
/// <para>A report is not a support ticket. A `201` means Courier stored the report;
/// it does not promise a reply or a fix. For help with your account, contact Courier support.</para>
///
/// <para>Never include secrets, API keys or customer data such as recipient names,
/// email addresses or message content.</para>
///
/// <para>Requires an API key with no scope restrictions; a JWT or a scoped API key
/// is refused. Each workspace can submit 200 reports per UTC day, and requests that
/// fail validation count toward that limit.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FeedbackCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// What kind of report this is: `possible_bug` for behavior that looks wrong,
    /// `confusing_behavior` for behavior that works but was hard to understand,
    /// `feature_request` for something Courier does not do yet, and `other`.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawBodyData.Set("category", value); }
    }

    /// <summary>
    /// What happened, in enough detail for someone at Courier to follow it.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Where you met the problem: the REST `api`, an `sdk`, the Courier `mcp` server,
    /// the Courier app `ui`, the `docs`, or `other`.
    /// </summary>
    public required ApiEnum<string, Surface> Surface
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Surface>>("surface");
        }
        init { this._rawBodyData.Set("surface", value); }
    }

    /// <summary>
    /// A one-line summary of the report.
    /// </summary>
    public required string Title
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("title");
        }
        init { this._rawBodyData.Set("title", value); }
    }

    /// <summary>
    /// What you expected to happen instead.
    /// </summary>
    public string? ExpectedBehavior
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("expected_behavior");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("expected_behavior", value);
        }
    }

    /// <summary>
    /// The agent or tool that submitted the report, such as `Claude Code`.
    /// </summary>
    public string? Harness
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("harness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("harness", value);
        }
    }

    /// <summary>
    /// Where it happened, such as an endpoint (`POST /send`), an SDK method, an MCP
    /// tool name or a docs URL.
    /// </summary>
    public string? Location
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("location");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("location", value);
        }
    }

    /// <summary>
    /// The AI model that submitted the report, such as `claude-opus-5-5`.
    /// </summary>
    public string? Model
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("model", value);
        }
    }

    /// <summary>
    /// The request ID of an API call that shows the problem, if there is one.
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("request_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("request_id", value);
        }
    }

    public FeedbackCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeedbackCreateParams(FeedbackCreateParams feedbackCreateParams)
        : base(feedbackCreateParams)
    {
        this._rawBodyData = new(feedbackCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FeedbackCreateParams(
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
    FeedbackCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FeedbackCreateParams FromRawUnchecked(
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(FeedbackCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/feedback")
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
/// What kind of report this is: `possible_bug` for behavior that looks wrong, `confusing_behavior`
/// for behavior that works but was hard to understand, `feature_request` for something
/// Courier does not do yet, and `other`.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    PossibleBug,
    ConfusingBehavior,
    FeatureRequest,
    Other,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "possible_bug" => Category.PossibleBug,
            "confusing_behavior" => Category.ConfusingBehavior,
            "feature_request" => Category.FeatureRequest,
            "other" => Category.Other,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.PossibleBug => "possible_bug",
                Category.ConfusingBehavior => "confusing_behavior",
                Category.FeatureRequest => "feature_request",
                Category.Other => "other",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Where you met the problem: the REST `api`, an `sdk`, the Courier `mcp` server,
/// the Courier app `ui`, the `docs`, or `other`.
/// </summary>
[JsonConverter(typeof(SurfaceConverter))]
public enum Surface
{
    Api,
    Sdk,
    Mcp,
    Ui,
    Docs,
    Other,
}

sealed class SurfaceConverter : JsonConverter<Surface>
{
    public override Surface Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "api" => Surface.Api,
            "sdk" => Surface.Sdk,
            "mcp" => Surface.Mcp,
            "ui" => Surface.Ui,
            "docs" => Surface.Docs,
            "other" => Surface.Other,
            _ => (Surface)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Surface value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Surface.Api => "api",
                Surface.Sdk => "sdk",
                Surface.Mcp => "mcp",
                Surface.Ui => "ui",
                Surface.Docs => "docs",
                Surface.Other => "other",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
