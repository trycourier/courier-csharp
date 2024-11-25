using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record RenderOutputResponse
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<RenderOutput> Results { get; set; } = new List<RenderOutput>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
