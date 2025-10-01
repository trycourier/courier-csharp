using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Profiles;

/// <summary>
/// Returns the specified user profile.
/// </summary>
public sealed record class ProfileRetrieveParams : ParamsBase
{
    public required string UserID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/profiles/{0}", this.UserID)
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
