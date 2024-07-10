namespace Courier.Net.Users;

public record ListTenantsForUserParams
{
    /// <summary>
    /// The number of accounts to return
    /// (defaults to 20, maximum value of 100)
    /// </summary>
    public int? Limit { get; init; }

    /// <summary>
    /// Continue the pagination with the next cursor
    /// </summary>
    public string? Cursor { get; init; }
}
