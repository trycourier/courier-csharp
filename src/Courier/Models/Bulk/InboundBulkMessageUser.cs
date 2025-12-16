using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(ModelConverter<InboundBulkMessageUser, InboundBulkMessageUserFromRaw>))]
public sealed record class InboundBulkMessageUser : ModelBase
{
    /// <summary>
    /// User-specific data that will be merged with message.data
    /// </summary>
    public JsonElement? Data
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "data"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "data", value);
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            return ModelBase.GetNullableClass<RecipientPreferences>(this.RawData, "preferences");
        }
        init { ModelBase.Set(this._rawData, "preferences", value); }
    }

    /// <summary>
    /// User profile information. For email-based bulk jobs, `profile.email` is required
    ///  for provider routing to determine if the message can be delivered. The email
    ///  address should be provided here rather than in `to.email`.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Profile
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "profile"
            );
        }
        init { ModelBase.Set(this._rawData, "profile", value); }
    }

    /// <summary>
    /// User ID (legacy field, use profile or to.user_id instead)
    /// </summary>
    public string? Recipient
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "recipient"); }
        init { ModelBase.Set(this._rawData, "recipient", value); }
    }

    /// <summary>
    /// Optional recipient information. Note: For email provider routing, use  `profile.email`
    /// instead of `to.email`. The `to` field is primarily used  for recipient identification
    /// and data merging.
    /// </summary>
    public UserRecipient? To
    {
        get { return ModelBase.GetNullableClass<UserRecipient>(this.RawData, "to"); }
        init { ModelBase.Set(this._rawData, "to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        this.Preferences?.Validate();
        _ = this.Profile;
        _ = this.Recipient;
        this.To?.Validate();
    }

    public InboundBulkMessageUser() { }

    public InboundBulkMessageUser(InboundBulkMessageUser inboundBulkMessageUser)
        : base(inboundBulkMessageUser) { }

    public InboundBulkMessageUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundBulkMessageUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundBulkMessageUserFromRaw.FromRawUnchecked"/>
    public static InboundBulkMessageUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InboundBulkMessageUserFromRaw : IFromRaw<InboundBulkMessageUser>
{
    /// <inheritdoc/>
    public InboundBulkMessageUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundBulkMessageUser.FromRawUnchecked(rawData);
}
