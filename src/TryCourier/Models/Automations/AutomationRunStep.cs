using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Automations;

/// <summary>
/// One executed step of an Automation run.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AutomationRunStep, AutomationRunStepFromRaw>))]
public sealed record class AutomationRunStep : JsonModel
{
    /// <summary>
    /// The kind of step that ran, e.g. `send`, `delay`, or `update-profile`.
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
    /// A unique identifier representing the step.
    /// </summary>
    public string? StepID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("step_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("step_id", value);
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
        _ = this.StepID;
        _ = this.UpdatedAt;
    }

    public AutomationRunStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutomationRunStep(AutomationRunStep automationRunStep)
        : base(automationRunStep) { }
#pragma warning restore CS8618

    public AutomationRunStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationRunStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationRunStepFromRaw.FromRawUnchecked"/>
    public static AutomationRunStep FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationRunStepFromRaw : IFromRawJson<AutomationRunStep>
{
    /// <inheritdoc/>
    public AutomationRunStep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AutomationRunStep.FromRawUnchecked(rawData);
}
