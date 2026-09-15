using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// Which recipient's held digest to release.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TopicDigestReleaseRequest, TopicDigestReleaseRequestFromRaw>)
)]
public sealed record class TopicDigestReleaseRequest : JsonModel
{
    /// <summary>
    /// The recipient whose digest to release. Required: there is no "release everyone
    /// on this topic" form, because a whole-schedule flush already has its own endpoint
    /// and a body-shaped difference between one recipient and all of them is too
    /// easy to get wrong.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// The recipient's tenant, when they were sent to as part of one -- the same
    /// value returned as `tenant_id` on a digest instance and sent as `message.context.tenant_id`.
    /// It is part of the held digest's key, so a tenanted recipient cannot be found
    /// without it. Omit for an ordinary recipient.
    /// </summary>
    public string? TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tenant_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tenant_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UserID;
        _ = this.TenantID;
    }

    public TopicDigestReleaseRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicDigestReleaseRequest(TopicDigestReleaseRequest topicDigestReleaseRequest)
        : base(topicDigestReleaseRequest) { }
#pragma warning restore CS8618

    public TopicDigestReleaseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicDigestReleaseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopicDigestReleaseRequestFromRaw.FromRawUnchecked"/>
    public static TopicDigestReleaseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopicDigestReleaseRequest(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class TopicDigestReleaseRequestFromRaw : IFromRawJson<TopicDigestReleaseRequest>
{
    /// <inheritdoc/>
    public TopicDigestReleaseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopicDigestReleaseRequest.FromRawUnchecked(rawData);
}
