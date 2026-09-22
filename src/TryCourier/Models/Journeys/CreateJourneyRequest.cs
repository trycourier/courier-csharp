using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Request body for creating a journey.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreateJourneyRequest, CreateJourneyRequestFromRaw>))]
public sealed record class CreateJourneyRequest : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required IReadOnlyList<JourneyNode> Nodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JourneyNode>>("nodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JourneyNode>>(
                "nodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Cancelation token stored on the journey definition. It tags every run the
    /// journey creates so that `POST /journeys/cancel` can later cancel those runs
    /// by token. Accepts a templated string such as `order-{{data.order_id}}`, which
    /// is resolved per run when the journey is invoked. On a replace, omitting this
    /// field preserves any existing token and sending a value replaces it.
    /// </summary>
    public string? CancelationToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cancelation_token");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cancelation_token", value);
        }
    }

    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Lifecycle state of a journey.
    /// </summary>
    public ApiEnum<string, JourneyState>? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, JourneyState>>("state");
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
        _ = this.Name;
        foreach (var item in this.Nodes)
        {
            item.Validate();
        }
        _ = this.CancelationToken;
        _ = this.Enabled;
        this.State?.Validate();
    }

    public CreateJourneyRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateJourneyRequest(CreateJourneyRequest createJourneyRequest)
        : base(createJourneyRequest) { }
#pragma warning restore CS8618

    public CreateJourneyRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateJourneyRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateJourneyRequestFromRaw.FromRawUnchecked"/>
    public static CreateJourneyRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateJourneyRequestFromRaw : IFromRawJson<CreateJourneyRequest>
{
    /// <inheritdoc/>
    public CreateJourneyRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateJourneyRequest.FromRawUnchecked(rawData);
}
