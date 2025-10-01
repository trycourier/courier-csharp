using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Messages;

/// <summary>
/// Fetch the status of a message you've previously sent.
/// </summary>
public sealed record class MessageRetrieveParams : ParamsBase
{
    public required string MessageID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/messages/{0}", this.MessageID)
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
