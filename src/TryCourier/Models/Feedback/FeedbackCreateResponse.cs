using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Feedback;

[JsonConverter(typeof(JsonModelConverter<FeedbackCreateResponse, FeedbackCreateResponseFromRaw>))]
public sealed record class FeedbackCreateResponse : JsonModel
{
    /// <summary>
    /// The ID of the stored report, `fbk_` followed by a ULID.
    /// </summary>
    public required string FeedbackID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("feedback_id");
        }
        init { this._rawData.Set("feedback_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FeedbackID;
    }

    public FeedbackCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeedbackCreateResponse(FeedbackCreateResponse feedbackCreateResponse)
        : base(feedbackCreateResponse) { }
#pragma warning restore CS8618

    public FeedbackCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeedbackCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeedbackCreateResponseFromRaw.FromRawUnchecked"/>
    public static FeedbackCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FeedbackCreateResponse(string feedbackID)
        : this()
    {
        this.FeedbackID = feedbackID;
    }
}

class FeedbackCreateResponseFromRaw : IFromRawJson<FeedbackCreateResponse>
{
    /// <inheritdoc/>
    public FeedbackCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeedbackCreateResponse.FromRawUnchecked(rawData);
}
