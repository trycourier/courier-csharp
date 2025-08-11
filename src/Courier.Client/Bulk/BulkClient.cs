using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public partial class BulkClient
{
    private RawClient _client;

    internal BulkClient(RawClient client)
    {
        _client = client;
    }

    /// <example>
    /// <code>
    /// await client.Bulk.CreateJobAsync(
    ///     new BulkCreateJobParams
    ///     {
    ///         Message = new InboundBulkMessage
    ///         {
    ///             Brand = null,
    ///             Data = null,
    ///             Event = null,
    ///             Locale = null,
    ///             Override = null,
    ///             Message = null,
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<BulkCreateJobResponse> CreateJobAsync(
        BulkCreateJobParams request,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = "/bulk",
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
                return JsonUtils.Deserialize<BulkCreateJobResponse>(responseBody)!;
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
    /// Ingest user data into a Bulk Job
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Bulk.IngestUsersAsync(
    ///     "job_id",
    ///     new BulkIngestUsersParams
    ///     {
    ///         Users = new List&lt;InboundBulkMessageUser&gt;()
    ///         {
    ///             new InboundBulkMessageUser
    ///             {
    ///                 Preferences = null,
    ///                 Profile = null,
    ///                 Recipient = null,
    ///                 Data = null,
    ///                 To = null,
    ///             },
    ///             new InboundBulkMessageUser
    ///             {
    ///                 Preferences = null,
    ///                 Profile = null,
    ///                 Recipient = null,
    ///                 Data = null,
    ///                 To = null,
    ///             },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task IngestUsersAsync(
        string jobId,
        BulkIngestUsersParams request,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/bulk/{jobId}",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        throw new CourierApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }

    /// <summary>
    /// Run a bulk job
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Bulk.RunJobAsync("job_id");
    /// </code>
    /// </example>
    public async Task RunJobAsync(
        string jobId,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = $"/bulk/{jobId}/run",
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
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<BadRequest>(responseBody));
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
    /// Get a bulk job
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Bulk.GetJobAsync("job_id");
    /// </code>
    /// </example>
    public async Task<BulkGetJobResponse> GetJobAsync(
        string jobId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/bulk/{jobId}",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<BulkGetJobResponse>(responseBody)!;
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
    /// Get Bulk Job Users
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Bulk.GetUsersAsync("job_id", new BulkGetUsersParams());
    /// </code>
    /// </example>
    public async Task<BulkGetJobUsersResponse> GetUsersAsync(
        string jobId,
        BulkGetUsersParams request,
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
                Path = $"/bulk/{jobId}/users",
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
                return JsonUtils.Deserialize<BulkGetJobUsersResponse>(responseBody)!;
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
}
