using System.Net.Http;
using System.Text.Json;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

public class BulkClient
{
    private RawClient _client;

    public BulkClient(RawClient client)
    {
        _client = client;
    }

    public async Task<BulkCreateJobResponse> CreateJobAsync(BulkCreateJobParams request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "/bulk",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<BulkCreateJobResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Ingest user data into a Bulk Job
    /// </summary>
    public async Task IngestUsersAsync(string jobId, BulkIngestUsersParams request)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"/bulk/{jobId}",
                Body = request
            }
        );
    }

    /// <summary>
    /// Run a bulk job
    /// </summary>
    public async Task RunJobAsync(string jobId)
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Post, Path = $"/bulk/{jobId}/run" }
        );
    }

    /// <summary>
    /// Get a bulk job
    /// </summary>
    public async Task<BulkGetJobResponse> GetJobAsync(string jobId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Get, Path = $"/bulk/{jobId}" }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<BulkGetJobResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Get Bulk Job Users
    /// </summary>
    public async Task<BulkGetJobUsersResponse> GetUsersAsync(string jobId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Get, Path = $"/bulk/{jobId}/users" }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<BulkGetJobUsersResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
