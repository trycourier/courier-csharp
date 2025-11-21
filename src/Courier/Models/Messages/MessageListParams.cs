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
        get
        {
            if (!this._rawQueryData.TryGetValue("archived", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["archived"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A unique identifier that allows for fetching the next set of messages.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The enqueued datetime of a message to filter out messages received before.
    /// </summary>
    public string? EnqueuedAfter
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("enqueued_after", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["enqueued_after"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A unique identifier representing the event that was used to send the event.
    /// </summary>
    public string? Event
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("event", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["event"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A unique identifier representing the list the message was sent to.
    /// </summary>
    public string? List
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("list", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["list"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A unique identifier representing the message_id returned from either /send
    /// or /send/list.
    /// </summary>
    public string? MessageID
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("messageId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["messageId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A unique identifier representing the notification that was used to send the event.
    /// </summary>
    public string? Notification
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("notification", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["notification"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The key assocated to the provider you want to filter on. E.g., sendgrid, inbox,
    /// twilio, slack, msteams, etc. Allows multiple values to be set in query parameters.
    /// </summary>
    public List<string?>? Provider
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("provider", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string?>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawQueryData.TryGetValue("recipient", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["recipient"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An indicator of the current status of the message. Allows multiple values
    /// to be set in query parameters.
    /// </summary>
    public List<string?>? Status
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string?>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A tag placed in the metadata.tags during a notification send. Allows multiple
    /// values to be set in query parameters.
    /// </summary>
    public List<string?>? Tag
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("tag", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string?>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData["tag"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawQueryData.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["tags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Messages sent with the context of a Tenant
    /// </summary>
    public string? TenantID
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("tenant_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["tenant_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier used to trace the requests
    /// </summary>
    public string? TraceID
    {
        get
        {
            if (!this._rawQueryData.TryGetValue("traceId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawQueryData["traceId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
