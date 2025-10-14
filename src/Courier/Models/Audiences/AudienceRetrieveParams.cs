using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Audiences;

/// <summary>
/// Returns the specified audience by id.
/// </summary>
public sealed record class AudienceRetrieveParams : ParamsBase
{
    public required string AudienceID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/audiences/{0}", this.AudienceID)
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
