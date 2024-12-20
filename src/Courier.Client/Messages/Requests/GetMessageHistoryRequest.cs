using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record GetMessageHistoryRequest
{
    /// <summary>
    /// A supported Message History type that will filter the events returned.
    /// </summary>
    public string? Type { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
