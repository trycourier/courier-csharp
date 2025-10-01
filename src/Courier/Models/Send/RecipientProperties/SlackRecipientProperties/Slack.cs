using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Send.RecipientProperties.SlackRecipientProperties.SlackProperties;
using SlackVariants = Courier.Models.Send.RecipientProperties.SlackRecipientProperties.SlackVariants;

namespace Courier.Models.Send.RecipientProperties.SlackRecipientProperties;

[JsonConverter(typeof(SlackConverter))]
public abstract record class Slack
{
    internal Slack() { }

    public static implicit operator Slack(SendToSlackChannel value) =>
        new SlackVariants::SendToSlackChannel(value);

    public static implicit operator Slack(SendToSlackEmail value) =>
        new SlackVariants::SendToSlackEmail(value);

    public static implicit operator Slack(SendToSlackUserID value) =>
        new SlackVariants::SendToSlackUserID(value);

    public bool TryPickSendToSlackChannel([NotNullWhen(true)] out SendToSlackChannel? value)
    {
        value = (this as SlackVariants::SendToSlackChannel)?.Value;
        return value != null;
    }

    public bool TryPickSendToSlackEmail([NotNullWhen(true)] out SendToSlackEmail? value)
    {
        value = (this as SlackVariants::SendToSlackEmail)?.Value;
        return value != null;
    }

    public bool TryPickSendToSlackUserID([NotNullWhen(true)] out SendToSlackUserID? value)
    {
        value = (this as SlackVariants::SendToSlackUserID)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SlackVariants::SendToSlackChannel> sendToSlackChannel,
        Action<SlackVariants::SendToSlackEmail> sendToSlackEmail,
        Action<SlackVariants::SendToSlackUserID> sendToSlackUserID
    )
    {
        switch (this)
        {
            case SlackVariants::SendToSlackChannel inner:
                sendToSlackChannel(inner);
                break;
            case SlackVariants::SendToSlackEmail inner:
                sendToSlackEmail(inner);
                break;
            case SlackVariants::SendToSlackUserID inner:
                sendToSlackUserID(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Slack");
        }
    }

    public T Match<T>(
        Func<SlackVariants::SendToSlackChannel, T> sendToSlackChannel,
        Func<SlackVariants::SendToSlackEmail, T> sendToSlackEmail,
        Func<SlackVariants::SendToSlackUserID, T> sendToSlackUserID
    )
    {
        return this switch
        {
            SlackVariants::SendToSlackChannel inner => sendToSlackChannel(inner),
            SlackVariants::SendToSlackEmail inner => sendToSlackEmail(inner),
            SlackVariants::SendToSlackUserID inner => sendToSlackUserID(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Slack"),
        };
    }

    public abstract void Validate();
}

sealed class SlackConverter : JsonConverter<Slack>
{
    public override Slack? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<SendToSlackChannel>(ref reader, options);
            if (deserialized != null)
            {
                return new SlackVariants::SendToSlackChannel(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant SlackVariants::SendToSlackChannel",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SendToSlackEmail>(ref reader, options);
            if (deserialized != null)
            {
                return new SlackVariants::SendToSlackEmail(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant SlackVariants::SendToSlackEmail",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SendToSlackUserID>(ref reader, options);
            if (deserialized != null)
            {
                return new SlackVariants::SendToSlackUserID(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant SlackVariants::SendToSlackUserID",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Slack value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            SlackVariants::SendToSlackChannel(var sendToSlackChannel) => sendToSlackChannel,
            SlackVariants::SendToSlackEmail(var sendToSlackEmail) => sendToSlackEmail,
            SlackVariants::SendToSlackUserID(var sendToSlackUserID) => sendToSlackUserID,
            _ => throw new CourierInvalidDataException("Data did not match any variant of Slack"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
