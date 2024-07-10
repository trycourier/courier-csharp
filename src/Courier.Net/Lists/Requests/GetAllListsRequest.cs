namespace Courier.Net;

public record GetAllListsRequest
{
    /// <summary>
    /// A unique identifier that allows for fetching the next page of lists.
    /// </summary>
    public string? Cursor { get; init; }

    /// <summary>
    /// "A pattern used to filter the list items returned. Pattern types supported: exact match on `list_id` or a pattern of one or more pattern parts. you may replace a part with either: `*` to match all parts in that position, or `**` to signify a wildcard `endsWith` pattern match."
    /// </summary>
    public string? Pattern { get; init; }
}
