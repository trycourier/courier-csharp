using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Users.Preferences;

[JsonConverter(
    typeof(JsonModelConverter<PreferenceBulkUpdateResponse, PreferenceBulkUpdateResponseFromRaw>)
)]
public sealed record class PreferenceBulkUpdateResponse : JsonModel
{
    /// <summary>
    /// The topics that could not be applied, each with a reason.
    /// </summary>
    public required IReadOnlyList<Error> Errors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Error>>("errors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Error>>(
                "errors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The topics that were successfully created or updated.
    /// </summary>
    public required IReadOnlyList<BulkPreferenceTopic> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BulkPreferenceTopic>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BulkPreferenceTopic>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Errors)
        {
            item.Validate();
        }
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public PreferenceBulkUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceBulkUpdateResponse(PreferenceBulkUpdateResponse preferenceBulkUpdateResponse)
        : base(preferenceBulkUpdateResponse) { }
#pragma warning restore CS8618

    public PreferenceBulkUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceBulkUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceBulkUpdateResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceBulkUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceBulkUpdateResponseFromRaw : IFromRawJson<PreferenceBulkUpdateResponse>
{
    /// <inheritdoc/>
    public PreferenceBulkUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceBulkUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A single topic that could not be applied in a bulk preference request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    /// <summary>
    /// A human-readable explanation of why the topic could not be applied.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

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
        _ = this.Reason;
        _ = this.TopicID;
    }

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error(Error error)
        : base(error) { }
#pragma warning restore CS8618

    public Error(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Error.FromRawUnchecked(rawData);
}
