using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record BrandTemplateOverride
{
    [JsonPropertyName("mjml")]
    public required BrandTemplate Mjml { get; init; }

    [JsonPropertyName("footerBackgroundColor")]
    public string? FooterBackgroundColor { get; init; }

    [JsonPropertyName("footerFullWidth")]
    public bool? FooterFullWidth { get; init; }

    [JsonPropertyName("backgroundColor")]
    public string? BackgroundColor { get; init; }

    [JsonPropertyName("blocksBackgroundColor")]
    public string? BlocksBackgroundColor { get; init; }

    [JsonPropertyName("enabled")]
    public required bool Enabled { get; init; }

    [JsonPropertyName("footer")]
    public string? Footer { get; init; }

    [JsonPropertyName("head")]
    public string? Head { get; init; }

    [JsonPropertyName("header")]
    public string? Header { get; init; }

    [JsonPropertyName("width")]
    public string? Width { get; init; }
}
