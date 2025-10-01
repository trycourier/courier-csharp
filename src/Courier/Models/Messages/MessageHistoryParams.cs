using System;
using System.Net.Http;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Messages;

/// <summary>
/// Fetch the array of events of a message you've previously sent.
/// </summary>
public sealed record class MessageHistoryParams : ParamsBase
{
    public required string MessageID;

    /// <summary>
    /// A supported Message History type that will filter the events returned.
    /// </summary>
    public string? Type
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/messages/{0}/history", this.MessageID)
        )
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
