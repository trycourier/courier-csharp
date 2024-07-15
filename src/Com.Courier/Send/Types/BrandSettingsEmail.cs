using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BrandSettingsEmail
{
    [JsonPropertyName("templateOverride")]
    public BrandTemplateOverride? TemplateOverride { get; init; }

    [JsonPropertyName("head")]
    public EmailHead? Head { get; init; }

    [JsonPropertyName("footer")]
    public EmailFooter? Footer { get; init; }

    [JsonPropertyName("header")]
    public EmailHeader? Header { get; init; }
}
