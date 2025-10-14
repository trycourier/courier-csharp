using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Translations;

/// <summary>
/// Get translations by locale
/// </summary>
public sealed record class TranslationRetrieveParams : ParamsBase
{
    public required string Domain;

    public required string Locale;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/translations/{0}/{1}", this.Domain, this.Locale)
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
