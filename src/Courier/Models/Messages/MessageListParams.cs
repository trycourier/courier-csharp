using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Messages;

/// <summary>
/// Fetch the statuses of messages you've previously sent.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MessageListParams : ParamsBase
{
    /// <summary>
    /// A boolean value that indicates whether archived messages should be included
    /// in the response.
    /// </summary>
    public bool? Archived
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("archived");
        }
        init { this._rawQueryData.Set("archived", value); }
    }

    /// <summary>
    /// A unique identifier that allows for fetching the next set of messages.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init { this._rawQueryData.Set("cursor", value); }
    }

    /// <summary>
    /// The enqueued datetime of a message to filter out messages received before.
    /// </summary>
    public string? EnqueuedAfter
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("enqueued_after");
        }
        init { this._rawQueryData.Set("enqueued_after", value); }
    }

    /// <summary>
    /// A unique identifier representing the event that was used to send the event.
    /// </summary>
    public string? Event
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("event");
        }
        init { this._rawQueryData.Set("event", value); }
    }

    /// <summary>
    /// A unique identifier representing the list the message was sent to.
    /// </summary>
    public string? List
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("list");
        }
        init { this._rawQueryData.Set("list", value); }
    }

    /// <summary>
    /// A unique identifier representing the message_id returned from either /send
    /// or /send/list.
    /// </summary>
    public string? MessageID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("messageId");
        }
        init { this._rawQueryData.Set("messageId", value); }
    }

    /// <summary>
    /// A unique identifier representing the notification that was used to send the event.
    /// </summary>
    public string? Notification
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("notification");
        }
        init { this._rawQueryData.Set("notification", value); }
    }

    /// <summary>
    /// The key assocated to the provider you want to filter on. E.g., sendgrid, inbox,
    /// twilio, slack, msteams, etc. Allows multiple values to be set in query parameters.
    /// </summary>
    public IReadOnlyList<string?>? Provider
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string?>>("provider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string?>?>(
                "provider",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A unique identifier representing the recipient associated with the requested profile.
    /// </summary>
    public string? Recipient
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("recipient");
        }
        init { this._rawQueryData.Set("recipient", value); }
    }

    /// <summary>
    /// An indicator of the current status of the message. Allows multiple values
    /// to be set in query parameters.
    /// </summary>
    public IReadOnlyList<string?>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string?>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string?>?>(
                "status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A tag placed in the metadata.tags during a notification send. Allows multiple
    /// values to be set in query parameters.
    /// </summary>
    public IReadOnlyList<string?>? Tag
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string?>>("tag");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string?>?>(
                "tag",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A comma delimited list of 'tags'. Messages will be returned if they match
    /// any of the tags passed in.
    /// </summary>
    public string? Tags
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tags");
        }
        init { this._rawQueryData.Set("tags", value); }
    }

    /// <summary>
    /// Messages sent with the context of a Tenant
    /// </summary>
    public string? TenantID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tenant_id");
        }
        init { this._rawQueryData.Set("tenant_id", value); }
    }

    /// <summary>
    /// The unique identifier used to trace the requests
    /// </summary>
    public string? TraceID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("traceId");
        }
        init { this._rawQueryData.Set("traceId", value); }
    }

    public MessageListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageListParams(MessageListParams messageListParams)
        : base(messageListParams) { }
#pragma warning restore CS8618

    public MessageListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static MessageListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MessageListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/messages")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
