namespace Com.Courier;

public record GetMessageHistoryRequest
{
    /// <summary>
    /// A supported Message History type that will filter the events returned.
    /// </summary>
    public string? Type { get; init; }
}
