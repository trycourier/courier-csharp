using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

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
