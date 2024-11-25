namespace Courier.Client.Core;

internal interface IIdempotentRequestOptions : IRequestOptions
{
    public string? IdempotencyKey { get; init; }

    /// <summary>
    /// The expiry can either be an ISO8601 datetime or a duration like "1 Day".
    /// </summary>
    public string? IdempotencyExpiry { get; init; }
    internal Headers GetIdempotencyHeaders();
}
