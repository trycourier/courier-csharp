using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Auth;

[JsonConverter(typeof(ModelConverter<AuthIssueTokenResponse>))]
public sealed record class AuthIssueTokenResponse : ModelBase, IFromRaw<AuthIssueTokenResponse>
{
    public required string Token
    {
        get
        {
            if (!this.Properties.TryGetValue("token", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'token' cannot be null",
                    new ArgumentOutOfRangeException("token", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'token' cannot be null",
                    new ArgumentNullException("token")
                );
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

    [SetsRequiredMembers]
    public AuthIssueTokenResponse(string token)
        : this()
    {
        this.Token = token;
    }
}
