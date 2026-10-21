using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications;

/// <summary>
/// Email header fields for the template's email channel: the From, Reply-to, CC
/// and BCC values set in the Studio email channel settings. Each value may use template
/// variables, such as `{{data.cc}}`, which are resolved at send time. Reads omit
/// `email` when no header is set, and omit each unset field. Writes treat it as
/// optional, with three meanings. Omit it to keep the stored headers. Send null to
/// clear all four. Send an object to replace all four: a field the object leaves
/// out is cleared. Other email channel settings, such as the subject, are kept either
/// way. Headers only apply while `content` has an email channel; with no email channel
/// they are not stored.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<NotificationTemplateEmail, NotificationTemplateEmailFromRaw>)
)]
public sealed record class NotificationTemplateEmail : JsonModel
{
    /// <summary>
    /// BCC addresses.
    /// </summary>
    public IReadOnlyList<string>? Bcc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("bcc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "bcc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// CC addresses.
    /// </summary>
    public IReadOnlyList<string>? Cc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("cc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "cc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The From address.
    /// </summary>
    public string? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// The Reply-to address.
    /// </summary>
    public string? ReplyTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reply_to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reply_to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bcc;
        _ = this.Cc;
        _ = this.From;
        _ = this.ReplyTo;
    }

    public NotificationTemplateEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateEmail(NotificationTemplateEmail notificationTemplateEmail)
        : base(notificationTemplateEmail) { }
#pragma warning restore CS8618

    public NotificationTemplateEmail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateEmailFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateEmailFromRaw : IFromRawJson<NotificationTemplateEmail>
{
    /// <inheritdoc/>
    public NotificationTemplateEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateEmail.FromRawUnchecked(rawData);
}
