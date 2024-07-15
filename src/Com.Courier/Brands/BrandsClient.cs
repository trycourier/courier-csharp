using System.Net.Http;
using System.Text.Json;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

public class BrandsClient
{
    private RawClient _client;

    public BrandsClient(RawClient client)
    {
        _client = client;
    }

    public async Task<Brand> CreateAsync(BrandParameters request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "/brands",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<Brand>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Fetch a specific brand by brand ID.
    /// </summary>
    public async Task<Brand> GetAsync(string brandId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Get, Path = $"/brands/{brandId}" }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<Brand>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Get the list of brands.
    /// </summary>
    public async Task<BrandsResponse> ListAsync(ListBrandsRequest request)
    {
        var _query = new Dictionary<string, object>() { };
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "/brands",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<BrandsResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Delete a brand by brand ID.
    /// </summary>
    public async Task DeleteAsync(string brandId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Delete, Path = $"/brands/{brandId}" }
        );
    }

    /// <summary>
    /// Replace an existing brand with the supplied values.
    /// </summary>
    public async Task<Brand> ReplaceAsync(string brandId, BrandUpdateParameters request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Put,
                Path = $"/brands/{brandId}",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<Brand>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
