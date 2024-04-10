using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class ElementalGroupNode
{
    /// <summary>
    /// Sub elements to render.
    /// </summary>
    [JsonPropertyName("elements")]
    public List<OneOf<ElementalNode._Text, ElementalNode._Meta, ElementalNode._Channel, ElementalNode._Image, ElementalNode._Action, ElementalNode._Divider, ElementalNode._Group, ElementalNode._Quote>> Elements { get; init; }

    [JsonPropertyName("channels")]
    public List<string>? Channels { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("if")]
    public string? If { get; init; }

    [JsonPropertyName("loop")]
    public string? Loop { get; init; }
}
