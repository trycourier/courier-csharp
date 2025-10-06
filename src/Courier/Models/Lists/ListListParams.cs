using System;
using System.Net.Http;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Lists;

/// <summary>
/// Returns all of the lists, with the ability to filter based on a pattern.
/// </summary>
public sealed record class ListListParams : ParamsBase
{
    /// <summary>
    /// A unique identifier that allows for fetching the next page of lists.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// "A pattern used to filter the list items returned. Pattern types supported:
    /// exact match on `list_id` or a pattern of one or more pattern parts. you may
    /// replace a part with either: `*` to match all parts in that position, or `**`
    /// to signify a wildcard `endsWith` pattern match."
    /// </summary>
    public string? Pattern
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("pattern", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["pattern"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/lists")
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
