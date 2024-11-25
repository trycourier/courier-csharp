using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationAddToBatchRetain
{
    /// <summary>
    /// Keep N number of notifications based on the type. First/Last N based on notification received.
    /// highest/lowest based on a scoring key providing in the data accessed by sort_key
    /// </summary>
    [JsonPropertyName("type")]
    public required AutomationAddToBatchRetainType Type { get; set; }

    /// <summary>
    /// The number of records to keep in batch. Default is 10 and only configurable by requesting from support.
    /// When configurable minimum is 2 and maximum is 100.
    /// </summary>
    [JsonPropertyName("count")]
    public required int Count { get; set; }

    /// <summary>
    /// Defines the data value data[sort_key] that is used to sort the stored items. Required when type is set to highest or lowest.
    /// </summary>
    [JsonPropertyName("sort_key")]
    public string? SortKey { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
