using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Send.RecipientProperties.WebhookRecipientProperties.WebhookProperties;

/// <summary>
/// Specifies what profile information is included in the request payload. Defaults
/// to 'limited' if not specified.
/// </summary>
[JsonConverter(typeof(ProfileConverter))]
public enum Profile
{
    Limited,
    Expanded,
}

sealed class ProfileConverter : JsonConverter<Profile>
{
    public override Profile Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "limited" => Profile.Limited,
            "expanded" => Profile.Expanded,
            _ => (Profile)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Profile value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Profile.Limited => "limited",
                Profile.Expanded => "expanded",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
