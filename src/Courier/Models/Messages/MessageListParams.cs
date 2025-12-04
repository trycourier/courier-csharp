using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Messages;

/// <summary>
/// Fetch the statuses of messages you've previously sent.
/// </summary>
public sealed record class MessageListParams : ParamsBase
{
    /// <summary>
    /// A boolean value that indicates whether archived messages should be included
    /// in the response.
    /// </summary>
    public bool? Archived
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawQueryData, "archived"); }
        init { ModelBase.Set(this._rawQueryData, "archived", value); }
    }

    /// <summary>
    /// A unique identifier that allows for fetching the next set of messages.
    /// </summary>
    public string? Cursor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "cursor"); }
        init { ModelBase.Set(this._rawQueryData, "cursor", value); }
    }

    /// <summary>
    /// The enqueued datetime of a message to filter out messages received before.
    /// </summary>
    public string? EnqueuedAfter
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "enqueued_after"); }
        init { ModelBase.Set(this._rawQueryData, "enqueued_after", value); }
    }

    /// <summary>
    /// A unique identifier representing the event that was used to send the event.
    /// </summary>
    public string? Event
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "event"); }
        init { ModelBase.Set(this._rawQueryData, "event", value); }
    }

    /// <summary>
    /// A unique identifier representing the list the message was sent to.
    /// </summary>
    public string? List
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "list"); }
        init { ModelBase.Set(this._rawQueryData, "list", value); }
    }

    /// <summary>
    /// A unique identifier representing the message_id returned from either /send
    /// or /send/list.
    /// </summary>
    public string? MessageID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "messageId"); }
        init { ModelBase.Set(this._rawQueryData, "messageId", value); }
    }

    /// <summary>
    /// A unique identifier representing the notification that was used to send the event.
    /// </summary>
    public string? Notification
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "notification"); }
        init { ModelBase.Set(this._rawQueryData, "notification", value); }
    }

    /// <summary>
    /// The key assocated to the provider you want to filter on. E.g., sendgrid, inbox,
    /// twilio, slack, msteams, etc. Allows multiple values to be set in query parameters.
    /// </summary>
    public IReadOnlyList<string?>? Provider
    {
        get { return ModelBase.GetNullableClass<List<string?>>(this.RawQueryData, "provider"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "provider", value);
        }
    }

    /// <summary>
    /// A unique identifier representing the recipient associated with the requested profile.
    /// </summary>
    public string? Recipient
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "recipient"); }
        init { ModelBase.Set(this._rawQueryData, "recipient", value); }
    }

    /// <summary>
    /// An indicator of the current status of the message. Allows multiple values
    /// to be set in query parameters.
    /// </summary>
    public IReadOnlyList<string?>? Status
    {
        get { return ModelBase.GetNullableClass<List<string?>>(this.RawQueryData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "status", value);
        }
    }

    /// <summary>
    /// A tag placed in the metadata.tags during a notification send. Allows multiple
    /// values to be set in query parameters.
    /// </summary>
    public IReadOnlyList<string?>? Tag
    {
        get { return ModelBase.GetNullableClass<List<string?>>(this.RawQueryData, "tag"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "tag", value);
        }
    }

    /// <summary>
    /// A comma delimited list of 'tags'. Messages will be returned if they match
    /// any of the tags passed in.
    /// </summary>
    public string? Tags
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "tags"); }
        init { ModelBase.Set(this._rawQueryData, "tags", value); }
    }

    /// <summary>
    /// Messages sent with the context of a Tenant
    /// </summary>
    public string? TenantID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "tenant_id"); }
        init { ModelBase.Set(this._rawQueryData, "tenant_id", value); }
    }

    /// <summary>
    /// The unique identifier used to trace the requests
    /// </summary>
    public string? TraceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "traceId"); }
        init { ModelBase.Set(this._rawQueryData, "traceId", value); }
    }

    public MessageListParams() { }

    public MessageListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
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
}
