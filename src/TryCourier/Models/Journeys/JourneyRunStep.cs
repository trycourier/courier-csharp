using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// One executed node of a Journey run. `node_id` is the id of the node in the published
/// Journey, so a step maps directly onto the Journey graph.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyRunStep, JourneyRunStepFromRaw>))]
public sealed record class JourneyRunStep : JsonModel
{
    /// <summary>
    /// The kind of node that ran, e.g. `send`, `delay`, or `exit`.
    /// </summary>
    public required string Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// The state of the step: the seven run statuses, plus `SKIPPED` and `COMPUTING`.
    /// Not an enum — new values have been added before.
    /// </summary>
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// When the step started, as an ISO 8601 timestamp.
    /// </summary>
    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// The message this step produced, present on send steps. Pass it to `GET /messages/{message_id}`
    /// for delivery status. A send to a List or an Audience yields one id for the
    /// request, not one per recipient.
    /// </summary>
    public string? MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message_id", value);
        }
    }

    /// <summary>
    /// The id of the node in the published Journey that this step executed.
    /// </summary>
    public string? NodeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("node_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("node_id", value);
        }
    }

    /// <summary>
    /// When the step last changed state, as an ISO 8601 timestamp.
    /// </summary>
    public string? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Action;
        _ = this.Status;
        _ = this.CreatedAt;
        _ = this.MessageID;
        _ = this.NodeID;
        _ = this.UpdatedAt;
    }

    public JourneyRunStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyRunStep(JourneyRunStep journeyRunStep)
        : base(journeyRunStep) { }
#pragma warning restore CS8618

    public JourneyRunStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyRunStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyRunStepFromRaw.FromRawUnchecked"/>
    public static JourneyRunStep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyRunStepFromRaw : IFromRawJson<JourneyRunStep>
{
    /// <inheritdoc/>
    public JourneyRunStep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyRunStep.FromRawUnchecked(rawData);
}
