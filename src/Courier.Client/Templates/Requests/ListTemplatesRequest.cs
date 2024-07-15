namespace Courier.Client;

public record ListTemplatesRequest
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of templates
    /// </summary>
    public string? Cursor { get; init; }
}
