using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Auth;

[JsonConverter(typeof(ModelConverter<AuthIssueTokenResponse>))]
public sealed record class AuthIssueTokenResponse : ModelBase, IFromRaw<AuthIssueTokenResponse>
{
    public string? Token
    {
        get
        {
            if (!this.Properties.TryGetValue("token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Token;
    }

    public AuthIssueTokenResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthIssueTokenResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AuthIssueTokenResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
