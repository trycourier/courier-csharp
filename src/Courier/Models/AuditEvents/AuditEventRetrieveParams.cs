using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.AuditEvents;

/// <summary>
/// Fetch a specific audit event by ID.
/// </summary>
public sealed record class AuditEventRetrieveParams : ParamsBase
{
    public required string AuditEventID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/audit-events/{0}", this.AuditEventID)
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
