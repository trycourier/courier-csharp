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

[JsonConverter(
    typeof(JsonModelConverter<JourneyTemplateCreateRequest, JourneyTemplateCreateRequestFromRaw>)
)]
public sealed record class JourneyTemplateCreateRequest : JsonModel
{
    public required string Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    public required Notification Notification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Notification>("notification");
        }
        init { this._rawData.Set("notification", value); }
    }

    public string? ProviderKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("providerKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("providerKey", value);
        }
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
        _ = this.Channel;
        this.Notification.Validate();
        _ = this.ProviderKey;
        _ = this.State;
    }

    public JourneyTemplateCreateRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateCreateRequest(JourneyTemplateCreateRequest journeyTemplateCreateRequest)
        : base(journeyTemplateCreateRequest) { }
#pragma warning restore CS8618

    public JourneyTemplateCreateRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateCreateRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateCreateRequestFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyTemplateCreateRequestFromRaw : IFromRawJson<JourneyTemplateCreateRequest>
{
    /// <inheritdoc/>
    public JourneyTemplateCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateCreateRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Notification, NotificationFromRaw>))]
public sealed record class Notification : JsonModel
{
    public required Brand? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Brand>("brand");
        }
        init { this._rawData.Set("brand", value); }
    }

    public required Content Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Content>("content");
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

    public required Subscription? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Subscription>("subscription");
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

    public Notification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Notification(Notification notification)
        : base(notification) { }
#pragma warning restore CS8618

    public Notification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Notification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationFromRaw.FromRawUnchecked"/>
    public static Notification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationFromRaw : IFromRawJson<Notification>
{
    /// <inheritdoc/>
    public Notification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Notification.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Brand, BrandFromRaw>))]
public sealed record class Brand : JsonModel
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

    public Brand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Brand(Brand brand)
        : base(brand) { }
#pragma warning restore CS8618

    public Brand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandFromRaw.FromRawUnchecked"/>
    public static Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Brand(string id)
        : this()
    {
        this.ID = id;
    }
}

class BrandFromRaw : IFromRawJson<Brand>
{
    /// <inheritdoc/>
    public Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Brand.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Content, ContentFromRaw>))]
public sealed record class Content : JsonModel
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

    public required ApiEnum<string, ContentVersion> Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ContentVersion>>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    public ApiEnum<string, Scope>? Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Scope>>("scope");
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

    public Content() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Content(Content content)
        : base(content) { }
#pragma warning restore CS8618

    public Content(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Content(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContentFromRaw.FromRawUnchecked"/>
    public static Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContentFromRaw : IFromRawJson<Content>
{
    /// <inheritdoc/>
    public Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Content.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ContentVersionConverter))]
public enum ContentVersion
{
    V2022_01_01,
}

sealed class ContentVersionConverter : JsonConverter<ContentVersion>
{
    public override ContentVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "2022-01-01" => ContentVersion.V2022_01_01,
            _ => (ContentVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContentVersion.V2022_01_01 => "2022-01-01",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ScopeConverter))]
public enum Scope
{
    Default,
    Strict,
}

sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default" => Scope.Default,
            "strict" => Scope.Strict,
            _ => (Scope)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Scope.Default => "default",
                Scope.Strict => "strict",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Subscription, SubscriptionFromRaw>))]
public sealed record class Subscription : JsonModel
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

    public Subscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Subscription(Subscription subscription)
        : base(subscription) { }
#pragma warning restore CS8618

    public Subscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionFromRaw.FromRawUnchecked"/>
    public static Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Subscription(string topicID)
        : this()
    {
        this.TopicID = topicID;
    }
}

class SubscriptionFromRaw : IFromRawJson<Subscription>
{
    /// <inheritdoc/>
    public Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscription.FromRawUnchecked(rawData);
}
