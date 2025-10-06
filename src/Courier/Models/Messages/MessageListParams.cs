using System;
using System.Collections.Generic;
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
            if (!this.QueryProperties.TryGetValue("archived", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["archived"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("enqueued_after", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["enqueued_after"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("event", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["event"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("list", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["list"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("messageId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["messageId"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("notification", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["notification"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The key assocated to the provider you want to filter on. E.g., sendgrid,
    /// inbox, twilio, slack, msteams, etc. Allows multiple values to be set in query parameters.
    /// </summary>
    public List<string?>? Provider
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("provider", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string?>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["provider"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("recipient", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["recipient"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string?>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["status"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("tag", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string?>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["tag"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["tags"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("tenant_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["tenant_id"] = JsonSerializer.SerializeToElement(
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
            if (!this.QueryProperties.TryGetValue("traceId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["traceId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/messages")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ICourierClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
