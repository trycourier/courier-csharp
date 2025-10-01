using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Notifications.Checks;

public sealed record class CheckDeleteParams : ParamsBase
{
    public required string ID;

    public required string SubmissionID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/notifications/{0}/{1}/checks", this.ID, this.SubmissionID)
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
