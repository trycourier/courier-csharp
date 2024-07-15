namespace Com.Courier;

public record AudiencesListParams
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of audiences
    /// </summary>
    public string? Cursor { get; init; }
}
