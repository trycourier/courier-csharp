using System;
using System.Net.Http;

#nullable enable

namespace Courier.Client.Core;

public partial class IdempotentRequestOptions : IIdempotentRequestOptions
{
    /// <summary>
    /// The Base URL for the API.
    /// </summary>
    public string? BaseUrl { get; init; }

    /// <summary>
    /// The http client used to make requests.
    /// </summary>
    public HttpClient? HttpClient { get; init; }

    /// <summary>
    /// The http client used to make requests.
    /// </summary>
    public int? MaxRetries { get; init; }

    /// <summary>
    /// The timeout for the request.
    /// </summary>
    public TimeSpan? Timeout { get; init; }

    public string? IdempotencyKey { get; init; }

    /// <summary>
    /// The expiry can either be an ISO8601 datetime or a duration like "1 Day".
    /// </summary>
    public string? IdempotencyExpiry { get; init; }

    /// <summary>
    /// The http headers sent with the request.
    /// </summary>
    Headers IRequestOptions.Headers { get; init; } = new();

    Headers IIdempotentRequestOptions.GetIdempotencyHeaders()
    {
        return new Headers(
            new Dictionary<string, string>
            {
                ["Idempotency-Key"] = IdempotencyKey,
                ["X-Idempotency-Expiration"] = IdempotencyExpiry,
            }
        );
    }
}
