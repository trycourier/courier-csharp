using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Users.Tokens;

/// <summary>
/// Get single token available for a `:token`
/// </summary>
public sealed record class TokenRetrieveParams : ParamsBase
{
    public required string UserID;

    public required string Token;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/tokens/{1}", this.UserID, this.Token)
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
