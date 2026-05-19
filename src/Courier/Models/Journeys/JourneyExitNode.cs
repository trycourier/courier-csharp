using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Journeys;

/// <summary>
/// Terminate the journey run.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyExitNode, JourneyExitNodeFromRaw>))]
public sealed record class JourneyExitNode : JsonModel
{
    public required ApiEnum<string, JourneyExitNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyExitNodeType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ID;
    }

    public JourneyExitNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyExitNode(JourneyExitNode journeyExitNode)
        : base(journeyExitNode) { }
#pragma warning restore CS8618

    public JourneyExitNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyExitNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyExitNodeFromRaw.FromRawUnchecked"/>
    public static JourneyExitNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneyExitNode(ApiEnum<string, JourneyExitNodeType> type)
        : this()
    {
        this.Type = type;
    }
}

class JourneyExitNodeFromRaw : IFromRawJson<JourneyExitNode>
{
    /// <inheritdoc/>
    public JourneyExitNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyExitNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyExitNodeTypeConverter))]
public enum JourneyExitNodeType
{
    Exit,
}

sealed class JourneyExitNodeTypeConverter : JsonConverter<JourneyExitNodeType>
{
    public override JourneyExitNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "exit" => JourneyExitNodeType.Exit,
            _ => (JourneyExitNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyExitNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyExitNodeType.Exit => "exit",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
