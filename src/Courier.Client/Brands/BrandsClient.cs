using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class BrandsClient
{
    private RawClient _client;

    internal BrandsClient(RawClient client)
    {
        _client = client;
    }

    /// <example>
    /// <code>
    /// await client.Brands.CreateAsync(
    ///     new BrandParameters
    ///     {
    ///         Id = null,
    ///         Name = "name",
    ///         Settings = new BrandSettings
    ///         {
    ///             Colors = null,
    ///             Inapp = null,
    ///             Email = null,
    ///         },
    ///         Snippets = null,
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<Brand> CreateAsync(
        BrandParameters request,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = "/brands",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<Brand>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<BadRequest>(responseBody));
                case 402:
                    throw new PaymentRequiredError(
                        JsonUtils.Deserialize<PaymentRequired>(responseBody)
                    );
                case 409:
                    throw new AlreadyExistsError(
                        JsonUtils.Deserialize<AlreadyExists>(responseBody)
                    );
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Fetch a specific brand by brand ID.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Brands.GetAsync("brand_id");
    /// </code>
    /// </example>
    public async Task<Brand> GetAsync(
        string brandId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/brands/{brandId}",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<Brand>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Get the list of brands.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Brands.ListAsync(new ListBrandsRequest());
    /// </code>
    /// </example>
    public async Task<BrandsResponse> ListAsync(
        ListBrandsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = "/brands",
                Query = _query,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<BrandsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Delete a brand by brand ID.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Brands.DeleteAsync("brand_id");
    /// </code>
    /// </example>
    public async Task DeleteAsync(
        string brandId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Delete,
                Path = $"/brands/{brandId}",
                Options = options,
            },
            cancellationToken
        );
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        try
        {
            switch (response.StatusCode)
            {
                case 409:
                    throw new ConflictError(JsonUtils.Deserialize<Conflict>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Replace an existing brand with the supplied values.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Brands.ReplaceAsync(
    ///     "brand_id",
    ///     new BrandUpdateParameters
    ///     {
    ///         Name = "name",
    ///         Settings = null,
    ///         Snippets = null,
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<Brand> ReplaceAsync(
        string brandId,
        BrandUpdateParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = $"/brands/{brandId}",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<Brand>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }
}
