using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Broadcasts;

/// <summary>
/// Request body for updating a broadcast. Only the name is mutable.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UpdateBroadcastRequest, UpdateBroadcastRequestFromRaw>))]
public sealed record class UpdateBroadcastRequest : JsonModel
{
    /// <summary>
    /// New human-readable name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public UpdateBroadcastRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateBroadcastRequest(UpdateBroadcastRequest updateBroadcastRequest)
        : base(updateBroadcastRequest) { }
#pragma warning restore CS8618

    public UpdateBroadcastRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateBroadcastRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateBroadcastRequestFromRaw.FromRawUnchecked"/>
    public static UpdateBroadcastRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UpdateBroadcastRequest(string name)
        : this()
    {
        this.Name = name;
    }
}

class UpdateBroadcastRequestFromRaw : IFromRawJson<UpdateBroadcastRequest>
{
    /// <inheritdoc/>
    public UpdateBroadcastRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UpdateBroadcastRequest.FromRawUnchecked(rawData);
}
