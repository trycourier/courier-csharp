using System.Text.Json.Serialization;
using OneOf;
using Courier.Net;

namespace Courier.Net;

public class ElementalContent
{
    /// <summary>
    /// For example, "2022-01-01"
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; init; }

    [JsonPropertyName("brand")]
    public object? Brand { get; init; }

    [JsonPropertyName("elements")]
    public List<OneOf<ElementalNode._Text, ElementalNode._Meta, ElementalNode._Channel, ElementalNode._Image, ElementalNode._Action, ElementalNode._Divider, ElementalNode._Group, ElementalNode._Quote>> Elements { get; init; }
}
