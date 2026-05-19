using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Journeys;

/// <summary>
/// Request body for replacing a journey-scoped notification template draft.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyTemplateReplaceRequest, JourneyTemplateReplaceRequestFromRaw>)
)]
public sealed record class JourneyTemplateReplaceRequest : JsonModel
{
    public required JourneyTemplateReplaceRequestNotification Notification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JourneyTemplateReplaceRequestNotification>(
                "notification"
            );
        }
        init { this._rawData.Set("notification", value); }
    }

    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Notification.Validate();
        _ = this.State;
    }

    public JourneyTemplateReplaceRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateReplaceRequest(
        JourneyTemplateReplaceRequest journeyTemplateReplaceRequest
    )
        : base(journeyTemplateReplaceRequest) { }
#pragma warning restore CS8618

    public JourneyTemplateReplaceRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateReplaceRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateReplaceRequestFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateReplaceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneyTemplateReplaceRequest(JourneyTemplateReplaceRequestNotification notification)
        : this()
    {
        this.Notification = notification;
    }
}

class JourneyTemplateReplaceRequestFromRaw : IFromRawJson<JourneyTemplateReplaceRequest>
{
    /// <inheritdoc/>
    public JourneyTemplateReplaceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateReplaceRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        JourneyTemplateReplaceRequestNotification,
        JourneyTemplateReplaceRequestNotificationFromRaw
    >)
)]
public sealed record class JourneyTemplateReplaceRequestNotification : JsonModel
{
    public required JourneyTemplateReplaceRequestNotificationBrand? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JourneyTemplateReplaceRequestNotificationBrand>(
                "brand"
            );
        }
        init { this._rawData.Set("brand", value); }
    }

    public required JourneyTemplateReplaceRequestNotificationContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JourneyTemplateReplaceRequestNotificationContent>(
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

    public required JourneyTemplateReplaceRequestNotificationSubscription? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JourneyTemplateReplaceRequestNotificationSubscription>(
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

    public JourneyTemplateReplaceRequestNotification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateReplaceRequestNotification(
        JourneyTemplateReplaceRequestNotification journeyTemplateReplaceRequestNotification
    )
        : base(journeyTemplateReplaceRequestNotification) { }
#pragma warning restore CS8618

    public JourneyTemplateReplaceRequestNotification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateReplaceRequestNotification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateReplaceRequestNotificationFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateReplaceRequestNotification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyTemplateReplaceRequestNotificationFromRaw
    : IFromRawJson<JourneyTemplateReplaceRequestNotification>
{
    /// <inheritdoc/>
    public JourneyTemplateReplaceRequestNotification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateReplaceRequestNotification.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        JourneyTemplateReplaceRequestNotificationBrand,
        JourneyTemplateReplaceRequestNotificationBrandFromRaw
    >)
)]
public sealed record class JourneyTemplateReplaceRequestNotificationBrand : JsonModel
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

    public JourneyTemplateReplaceRequestNotificationBrand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateReplaceRequestNotificationBrand(
        JourneyTemplateReplaceRequestNotificationBrand journeyTemplateReplaceRequestNotificationBrand
    )
        : base(journeyTemplateReplaceRequestNotificationBrand) { }
#pragma warning restore CS8618

    public JourneyTemplateReplaceRequestNotificationBrand(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateReplaceRequestNotificationBrand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateReplaceRequestNotificationBrandFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateReplaceRequestNotificationBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneyTemplateReplaceRequestNotificationBrand(string id)
        : this()
    {
        this.ID = id;
    }
}

class JourneyTemplateReplaceRequestNotificationBrandFromRaw
    : IFromRawJson<JourneyTemplateReplaceRequestNotificationBrand>
{
    /// <inheritdoc/>
    public JourneyTemplateReplaceRequestNotificationBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateReplaceRequestNotificationBrand.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        JourneyTemplateReplaceRequestNotificationContent,
        JourneyTemplateReplaceRequestNotificationContentFromRaw
    >)
)]
public sealed record class JourneyTemplateReplaceRequestNotificationContent : JsonModel
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

    public required ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentVersion> Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentVersion>
            >("version");
        }
        init { this._rawData.Set("version", value); }
    }

    public ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentScope>? Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentScope>
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

    public JourneyTemplateReplaceRequestNotificationContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateReplaceRequestNotificationContent(
        JourneyTemplateReplaceRequestNotificationContent journeyTemplateReplaceRequestNotificationContent
    )
        : base(journeyTemplateReplaceRequestNotificationContent) { }
#pragma warning restore CS8618

    public JourneyTemplateReplaceRequestNotificationContent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateReplaceRequestNotificationContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateReplaceRequestNotificationContentFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateReplaceRequestNotificationContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyTemplateReplaceRequestNotificationContentFromRaw
    : IFromRawJson<JourneyTemplateReplaceRequestNotificationContent>
{
    /// <inheritdoc/>
    public JourneyTemplateReplaceRequestNotificationContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateReplaceRequestNotificationContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyTemplateReplaceRequestNotificationContentVersionConverter))]
public enum JourneyTemplateReplaceRequestNotificationContentVersion
{
    V2022_01_01,
}

sealed class JourneyTemplateReplaceRequestNotificationContentVersionConverter
    : JsonConverter<JourneyTemplateReplaceRequestNotificationContentVersion>
{
    public override JourneyTemplateReplaceRequestNotificationContentVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "2022-01-01" => JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
            _ => (JourneyTemplateReplaceRequestNotificationContentVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyTemplateReplaceRequestNotificationContentVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01 => "2022-01-01",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyTemplateReplaceRequestNotificationContentScopeConverter))]
public enum JourneyTemplateReplaceRequestNotificationContentScope
{
    Default,
    Strict,
}

sealed class JourneyTemplateReplaceRequestNotificationContentScopeConverter
    : JsonConverter<JourneyTemplateReplaceRequestNotificationContentScope>
{
    public override JourneyTemplateReplaceRequestNotificationContentScope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default" => JourneyTemplateReplaceRequestNotificationContentScope.Default,
            "strict" => JourneyTemplateReplaceRequestNotificationContentScope.Strict,
            _ => (JourneyTemplateReplaceRequestNotificationContentScope)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyTemplateReplaceRequestNotificationContentScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyTemplateReplaceRequestNotificationContentScope.Default => "default",
                JourneyTemplateReplaceRequestNotificationContentScope.Strict => "strict",
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
        JourneyTemplateReplaceRequestNotificationSubscription,
        JourneyTemplateReplaceRequestNotificationSubscriptionFromRaw
    >)
)]
public sealed record class JourneyTemplateReplaceRequestNotificationSubscription : JsonModel
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

    public JourneyTemplateReplaceRequestNotificationSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateReplaceRequestNotificationSubscription(
        JourneyTemplateReplaceRequestNotificationSubscription journeyTemplateReplaceRequestNotificationSubscription
    )
        : base(journeyTemplateReplaceRequestNotificationSubscription) { }
#pragma warning restore CS8618

    public JourneyTemplateReplaceRequestNotificationSubscription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateReplaceRequestNotificationSubscription(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateReplaceRequestNotificationSubscriptionFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateReplaceRequestNotificationSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneyTemplateReplaceRequestNotificationSubscription(string topicID)
        : this()
    {
        this.TopicID = topicID;
    }
}

class JourneyTemplateReplaceRequestNotificationSubscriptionFromRaw
    : IFromRawJson<JourneyTemplateReplaceRequestNotificationSubscription>
{
    /// <inheritdoc/>
    public JourneyTemplateReplaceRequestNotificationSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateReplaceRequestNotificationSubscription.FromRawUnchecked(rawData);
}
