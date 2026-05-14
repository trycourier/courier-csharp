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
    typeof(JsonModelConverter<JourneyTemplateGetResponse, JourneyTemplateGetResponseFromRaw>)
)]
public sealed record class JourneyTemplateGetResponse : JsonModel
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

    public required JourneyTemplateGetResponseBrand? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JourneyTemplateGetResponseBrand>("brand");
        }
        init { this._rawData.Set("brand", value); }
    }

    public required JourneyTemplateGetResponseContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JourneyTemplateGetResponseContent>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public required long Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    public required string Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creator");
        }
        init { this._rawData.Set("creator", value); }
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

    public required ApiEnum<string, State> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, State>>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    public required JourneyTemplateGetResponseSubscription? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JourneyTemplateGetResponseSubscription>(
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

    public long? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("updated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated", value);
        }
    }

    public string? Updater
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updater");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updater", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Brand?.Validate();
        this.Content.Validate();
        _ = this.Created;
        _ = this.Creator;
        _ = this.Name;
        this.State.Validate();
        this.Subscription?.Validate();
        _ = this.Tags;
        _ = this.Updated;
        _ = this.Updater;
    }

    public JourneyTemplateGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateGetResponse(JourneyTemplateGetResponse journeyTemplateGetResponse)
        : base(journeyTemplateGetResponse) { }
#pragma warning restore CS8618

    public JourneyTemplateGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateGetResponseFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyTemplateGetResponseFromRaw : IFromRawJson<JourneyTemplateGetResponse>
{
    /// <inheritdoc/>
    public JourneyTemplateGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateGetResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        JourneyTemplateGetResponseBrand,
        JourneyTemplateGetResponseBrandFromRaw
    >)
)]
public sealed record class JourneyTemplateGetResponseBrand : JsonModel
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

    public JourneyTemplateGetResponseBrand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateGetResponseBrand(
        JourneyTemplateGetResponseBrand journeyTemplateGetResponseBrand
    )
        : base(journeyTemplateGetResponseBrand) { }
#pragma warning restore CS8618

    public JourneyTemplateGetResponseBrand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateGetResponseBrand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateGetResponseBrandFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateGetResponseBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneyTemplateGetResponseBrand(string id)
        : this()
    {
        this.ID = id;
    }
}

class JourneyTemplateGetResponseBrandFromRaw : IFromRawJson<JourneyTemplateGetResponseBrand>
{
    /// <inheritdoc/>
    public JourneyTemplateGetResponseBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateGetResponseBrand.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        JourneyTemplateGetResponseContent,
        JourneyTemplateGetResponseContentFromRaw
    >)
)]
public sealed record class JourneyTemplateGetResponseContent : JsonModel
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

    public required ApiEnum<string, JourneyTemplateGetResponseContentVersion> Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, JourneyTemplateGetResponseContentVersion>
            >("version");
        }
        init { this._rawData.Set("version", value); }
    }

    public ApiEnum<string, JourneyTemplateGetResponseContentScope>? Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, JourneyTemplateGetResponseContentScope>
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

    public JourneyTemplateGetResponseContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateGetResponseContent(
        JourneyTemplateGetResponseContent journeyTemplateGetResponseContent
    )
        : base(journeyTemplateGetResponseContent) { }
#pragma warning restore CS8618

    public JourneyTemplateGetResponseContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateGetResponseContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateGetResponseContentFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateGetResponseContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyTemplateGetResponseContentFromRaw : IFromRawJson<JourneyTemplateGetResponseContent>
{
    /// <inheritdoc/>
    public JourneyTemplateGetResponseContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateGetResponseContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyTemplateGetResponseContentVersionConverter))]
public enum JourneyTemplateGetResponseContentVersion
{
    V2022_01_01,
}

sealed class JourneyTemplateGetResponseContentVersionConverter
    : JsonConverter<JourneyTemplateGetResponseContentVersion>
{
    public override JourneyTemplateGetResponseContentVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "2022-01-01" => JourneyTemplateGetResponseContentVersion.V2022_01_01,
            _ => (JourneyTemplateGetResponseContentVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyTemplateGetResponseContentVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyTemplateGetResponseContentVersion.V2022_01_01 => "2022-01-01",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyTemplateGetResponseContentScopeConverter))]
public enum JourneyTemplateGetResponseContentScope
{
    Default,
    Strict,
}

sealed class JourneyTemplateGetResponseContentScopeConverter
    : JsonConverter<JourneyTemplateGetResponseContentScope>
{
    public override JourneyTemplateGetResponseContentScope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default" => JourneyTemplateGetResponseContentScope.Default,
            "strict" => JourneyTemplateGetResponseContentScope.Strict,
            _ => (JourneyTemplateGetResponseContentScope)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyTemplateGetResponseContentScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyTemplateGetResponseContentScope.Default => "default",
                JourneyTemplateGetResponseContentScope.Strict => "strict",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StateConverter))]
public enum State
{
    Draft,
    Published,
}

sealed class StateConverter : JsonConverter<State>
{
    public override State Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => State.Draft,
            "PUBLISHED" => State.Published,
            _ => (State)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                State.Draft => "DRAFT",
                State.Published => "PUBLISHED",
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
        JourneyTemplateGetResponseSubscription,
        JourneyTemplateGetResponseSubscriptionFromRaw
    >)
)]
public sealed record class JourneyTemplateGetResponseSubscription : JsonModel
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

    public JourneyTemplateGetResponseSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateGetResponseSubscription(
        JourneyTemplateGetResponseSubscription journeyTemplateGetResponseSubscription
    )
        : base(journeyTemplateGetResponseSubscription) { }
#pragma warning restore CS8618

    public JourneyTemplateGetResponseSubscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateGetResponseSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateGetResponseSubscriptionFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateGetResponseSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneyTemplateGetResponseSubscription(string topicID)
        : this()
    {
        this.TopicID = topicID;
    }
}

class JourneyTemplateGetResponseSubscriptionFromRaw
    : IFromRawJson<JourneyTemplateGetResponseSubscription>
{
    /// <inheritdoc/>
    public JourneyTemplateGetResponseSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateGetResponseSubscription.FromRawUnchecked(rawData);
}
