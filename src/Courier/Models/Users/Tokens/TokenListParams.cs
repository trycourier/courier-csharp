using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Users.Tokens;

/// <summary>
/// Gets all tokens available for a :user_id
/// </summary>
public sealed record class TokenListParams : ParamsBase
{
    public required string UserID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/users/{0}/tokens", this.UserID)
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
