using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Messages;

/// <summary>
/// Cancel a message that is currently in the process of being delivered. A well-formatted
/// API call to the cancel message API will return either `200` status code for a
/// successful cancellation or `409` status code for an unsuccessful cancellation.
/// Both cases will include the actual message record in the response body (see details below).
/// </summary>
public sealed record class MessageCancelParams : ParamsBase
{
    public required string MessageID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/messages/{0}/cancel", this.MessageID)
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
