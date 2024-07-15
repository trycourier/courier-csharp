namespace Com.Courier;

public record AudienceMembersListParams
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of members
    /// </summary>
    public string? Cursor { get; init; }
}
