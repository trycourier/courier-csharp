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

namespace TryCourier.Models.Journeys.Templates;

/// <summary>
/// Replace the journey-scoped notification template draft.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TemplateReplaceParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string TemplateID { get; init; }

    public string? NotificationID { get; init; }

    public required TemplateReplaceParamsNotification Notification
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<TemplateReplaceParamsNotification>(
                "notification"
            );
        }
        init { this._rawBodyData.Set("notification", value); }
    }

    public string? State
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("state");
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

    public TemplateReplaceParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateReplaceParams(TemplateReplaceParams templateReplaceParams)
        : base(templateReplaceParams)
    {
        this.TemplateID = templateReplaceParams.TemplateID;
        this.NotificationID = templateReplaceParams.NotificationID;

        this._rawBodyData = new(templateReplaceParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TemplateReplaceParams(
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
    TemplateReplaceParams(
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
    public static TemplateReplaceParams FromRawUnchecked(
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

    public virtual bool Equals(TemplateReplaceParams? other)
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/journeys/{0}/templates/{1}", this.TemplateID, this.NotificationID)
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

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateReplaceParamsNotification,
        TemplateReplaceParamsNotificationFromRaw
    >)
)]
public sealed record class TemplateReplaceParamsNotification : JsonModel
{
    public required TemplateReplaceParamsNotificationBrand? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateReplaceParamsNotificationBrand>("brand");
        }
        init { this._rawData.Set("brand", value); }
    }

    public required TemplateReplaceParamsNotificationContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TemplateReplaceParamsNotificationContent>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required TemplateReplaceParamsNotificationSubscription? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TemplateReplaceParamsNotificationSubscription>(
                "subscription"
            );
        }
        init { this._rawData.Set("subscription", value); }
    }

    public required IReadOnlyList<string> Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "tags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Brand?.Validate();
        this.Content.Validate();
        _ = this.Name;
        this.Subscription?.Validate();
        _ = this.Tags;
    }

    public TemplateReplaceParamsNotification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateReplaceParamsNotification(
        TemplateReplaceParamsNotification templateReplaceParamsNotification
    )
        : base(templateReplaceParamsNotification) { }
#pragma warning restore CS8618

    public TemplateReplaceParamsNotification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateReplaceParamsNotification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateReplaceParamsNotificationFromRaw.FromRawUnchecked"/>
    public static TemplateReplaceParamsNotification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateReplaceParamsNotificationFromRaw : IFromRawJson<TemplateReplaceParamsNotification>
{
    /// <inheritdoc/>
    public TemplateReplaceParamsNotification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateReplaceParamsNotification.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateReplaceParamsNotificationBrand,
        TemplateReplaceParamsNotificationBrandFromRaw
    >)
)]
public sealed record class TemplateReplaceParamsNotificationBrand : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public TemplateReplaceParamsNotificationBrand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateReplaceParamsNotificationBrand(
        TemplateReplaceParamsNotificationBrand templateReplaceParamsNotificationBrand
    )
        : base(templateReplaceParamsNotificationBrand) { }
#pragma warning restore CS8618

    public TemplateReplaceParamsNotificationBrand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateReplaceParamsNotificationBrand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateReplaceParamsNotificationBrandFromRaw.FromRawUnchecked"/>
    public static TemplateReplaceParamsNotificationBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateReplaceParamsNotificationBrand(string id)
        : this()
    {
        this.ID = id;
    }
}

class TemplateReplaceParamsNotificationBrandFromRaw
    : IFromRawJson<TemplateReplaceParamsNotificationBrand>
{
    /// <inheritdoc/>
    public TemplateReplaceParamsNotificationBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateReplaceParamsNotificationBrand.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateReplaceParamsNotificationContent,
        TemplateReplaceParamsNotificationContentFromRaw
    >)
)]
public sealed record class TemplateReplaceParamsNotificationContent : JsonModel
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

    public required ApiEnum<string, TemplateReplaceParamsNotificationContentVersion> Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TemplateReplaceParamsNotificationContentVersion>
            >("version");
        }
        init { this._rawData.Set("version", value); }
    }

    public ApiEnum<string, TemplateReplaceParamsNotificationContentScope>? Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, TemplateReplaceParamsNotificationContentScope>
            >("scope");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scope", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        this.Version.Validate();
        this.Scope?.Validate();
    }

    public TemplateReplaceParamsNotificationContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateReplaceParamsNotificationContent(
        TemplateReplaceParamsNotificationContent templateReplaceParamsNotificationContent
    )
        : base(templateReplaceParamsNotificationContent) { }
#pragma warning restore CS8618

    public TemplateReplaceParamsNotificationContent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateReplaceParamsNotificationContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateReplaceParamsNotificationContentFromRaw.FromRawUnchecked"/>
    public static TemplateReplaceParamsNotificationContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateReplaceParamsNotificationContentFromRaw
    : IFromRawJson<TemplateReplaceParamsNotificationContent>
{
    /// <inheritdoc/>
    public TemplateReplaceParamsNotificationContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateReplaceParamsNotificationContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TemplateReplaceParamsNotificationContentVersionConverter))]
public enum TemplateReplaceParamsNotificationContentVersion
{
    V2022_01_01,
}

sealed class TemplateReplaceParamsNotificationContentVersionConverter
    : JsonConverter<TemplateReplaceParamsNotificationContentVersion>
{
    public override TemplateReplaceParamsNotificationContentVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "2022-01-01" => TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
            _ => (TemplateReplaceParamsNotificationContentVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TemplateReplaceParamsNotificationContentVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TemplateReplaceParamsNotificationContentVersion.V2022_01_01 => "2022-01-01",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TemplateReplaceParamsNotificationContentScopeConverter))]
public enum TemplateReplaceParamsNotificationContentScope
{
    Default,
    Strict,
}

sealed class TemplateReplaceParamsNotificationContentScopeConverter
    : JsonConverter<TemplateReplaceParamsNotificationContentScope>
{
    public override TemplateReplaceParamsNotificationContentScope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default" => TemplateReplaceParamsNotificationContentScope.Default,
            "strict" => TemplateReplaceParamsNotificationContentScope.Strict,
            _ => (TemplateReplaceParamsNotificationContentScope)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TemplateReplaceParamsNotificationContentScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TemplateReplaceParamsNotificationContentScope.Default => "default",
                TemplateReplaceParamsNotificationContentScope.Strict => "strict",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        TemplateReplaceParamsNotificationSubscription,
        TemplateReplaceParamsNotificationSubscriptionFromRaw
    >)
)]
public sealed record class TemplateReplaceParamsNotificationSubscription : JsonModel
{
    public required string TopicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic_id");
        }
        init { this._rawData.Set("topic_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TopicID;
    }

    public TemplateReplaceParamsNotificationSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateReplaceParamsNotificationSubscription(
        TemplateReplaceParamsNotificationSubscription templateReplaceParamsNotificationSubscription
    )
        : base(templateReplaceParamsNotificationSubscription) { }
#pragma warning restore CS8618

    public TemplateReplaceParamsNotificationSubscription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateReplaceParamsNotificationSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateReplaceParamsNotificationSubscriptionFromRaw.FromRawUnchecked"/>
    public static TemplateReplaceParamsNotificationSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateReplaceParamsNotificationSubscription(string topicID)
        : this()
    {
        this.TopicID = topicID;
    }
}

class TemplateReplaceParamsNotificationSubscriptionFromRaw
    : IFromRawJson<TemplateReplaceParamsNotificationSubscription>
{
    /// <inheritdoc/>
    public TemplateReplaceParamsNotificationSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateReplaceParamsNotificationSubscription.FromRawUnchecked(rawData);
}
