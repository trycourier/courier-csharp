using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BrandSettingsEmail
{
    [JsonPropertyName("templateOverride")]
    public BrandTemplateOverride? TemplateOverride { get; set; }

    [JsonPropertyName("head")]
    public EmailHead? Head { get; set; }

    [JsonPropertyName("footer")]
    public EmailFooter? Footer { get; set; }

    [JsonPropertyName("header")]
    public EmailHeader? Header { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
