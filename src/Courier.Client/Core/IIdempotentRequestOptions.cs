namespace Courier.Client.Core;

internal interface IIdempotentRequestOptions : IRequestOptions
{
    public string? IdempotencyKey { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// The expiry can either be an ISO8601 datetime or a duration like "1 Day".
    /// </summary>
    public string? IdempotencyExpiry { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }
    internal Headers GetIdempotencyHeaders();
}
