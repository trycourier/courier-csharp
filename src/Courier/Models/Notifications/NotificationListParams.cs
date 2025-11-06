using System.Net.Http;
using System.Text.Json;
using Courier.Core;
using System = System;

namespace Courier.Models.Notifications;

public sealed record class NotificationListParams : ParamsBase
{
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
    /// Retrieve the notes from the Notification template settings.
    /// </summary>
    public bool? Notes
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("notes", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["notes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(ICourierClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/notifications")
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
