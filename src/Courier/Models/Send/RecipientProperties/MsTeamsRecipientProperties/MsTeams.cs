using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Send.RecipientProperties.MsTeamsRecipientProperties.MsTeamsProperties;
using MsTeamsVariants = Courier.Models.Send.RecipientProperties.MsTeamsRecipientProperties.MsTeamsVariants;

namespace Courier.Models.Send.RecipientProperties.MsTeamsRecipientProperties;

[JsonConverter(typeof(MsTeamsConverter))]
public abstract record class MsTeams
{
    internal MsTeams() { }

    public static implicit operator MsTeams(SendToMsTeamsUserID value) =>
        new MsTeamsVariants::SendToMsTeamsUserID(value);

    public static implicit operator MsTeams(SendToMsTeamsEmail value) =>
        new MsTeamsVariants::SendToMsTeamsEmail(value);

    public static implicit operator MsTeams(SendToMsTeamsChannelID value) =>
        new MsTeamsVariants::SendToMsTeamsChannelID(value);

    public static implicit operator MsTeams(SendToMsTeamsConversationID value) =>
        new MsTeamsVariants::SendToMsTeamsConversationID(value);

    public static implicit operator MsTeams(SendToMsTeamsChannelName value) =>
        new MsTeamsVariants::SendToMsTeamsChannelName(value);

    public bool TryPickSendToMsTeamsUserID([NotNullWhen(true)] out SendToMsTeamsUserID? value)
    {
        value = (this as MsTeamsVariants::SendToMsTeamsUserID)?.Value;
        return value != null;
    }

    public bool TryPickSendToMsTeamsEmail([NotNullWhen(true)] out SendToMsTeamsEmail? value)
    {
        value = (this as MsTeamsVariants::SendToMsTeamsEmail)?.Value;
        return value != null;
    }

    public bool TryPickSendToMsTeamsChannelID([NotNullWhen(true)] out SendToMsTeamsChannelID? value)
    {
        value = (this as MsTeamsVariants::SendToMsTeamsChannelID)?.Value;
        return value != null;
    }

    public bool TryPickSendToMsTeamsConversationID(
        [NotNullWhen(true)] out SendToMsTeamsConversationID? value
    )
    {
        value = (this as MsTeamsVariants::SendToMsTeamsConversationID)?.Value;
        return value != null;
    }

    public bool TryPickSendToMsTeamsChannelName(
        [NotNullWhen(true)] out SendToMsTeamsChannelName? value
    )
    {
        value = (this as MsTeamsVariants::SendToMsTeamsChannelName)?.Value;
        return value != null;
    }

    public void Switch(
        Action<MsTeamsVariants::SendToMsTeamsUserID> sendToMsTeamsUserID,
        Action<MsTeamsVariants::SendToMsTeamsEmail> sendToMsTeamsEmail,
        Action<MsTeamsVariants::SendToMsTeamsChannelID> sendToMsTeamsChannelID,
        Action<MsTeamsVariants::SendToMsTeamsConversationID> sendToMsTeamsConversationID,
        Action<MsTeamsVariants::SendToMsTeamsChannelName> sendToMsTeamsChannelName
    )
    {
        switch (this)
        {
            case MsTeamsVariants::SendToMsTeamsUserID inner:
                sendToMsTeamsUserID(inner);
                break;
            case MsTeamsVariants::SendToMsTeamsEmail inner:
                sendToMsTeamsEmail(inner);
                break;
            case MsTeamsVariants::SendToMsTeamsChannelID inner:
                sendToMsTeamsChannelID(inner);
                break;
            case MsTeamsVariants::SendToMsTeamsConversationID inner:
                sendToMsTeamsConversationID(inner);
                break;
            case MsTeamsVariants::SendToMsTeamsChannelName inner:
                sendToMsTeamsChannelName(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of MsTeams");
        }
    }

    public T Match<T>(
        Func<MsTeamsVariants::SendToMsTeamsUserID, T> sendToMsTeamsUserID,
        Func<MsTeamsVariants::SendToMsTeamsEmail, T> sendToMsTeamsEmail,
        Func<MsTeamsVariants::SendToMsTeamsChannelID, T> sendToMsTeamsChannelID,
        Func<MsTeamsVariants::SendToMsTeamsConversationID, T> sendToMsTeamsConversationID,
        Func<MsTeamsVariants::SendToMsTeamsChannelName, T> sendToMsTeamsChannelName
    )
    {
        return this switch
        {
            MsTeamsVariants::SendToMsTeamsUserID inner => sendToMsTeamsUserID(inner),
            MsTeamsVariants::SendToMsTeamsEmail inner => sendToMsTeamsEmail(inner),
            MsTeamsVariants::SendToMsTeamsChannelID inner => sendToMsTeamsChannelID(inner),
            MsTeamsVariants::SendToMsTeamsConversationID inner => sendToMsTeamsConversationID(
                inner
            ),
            MsTeamsVariants::SendToMsTeamsChannelName inner => sendToMsTeamsChannelName(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of MsTeams"),
        };
    }

    public abstract void Validate();
}

sealed class MsTeamsConverter : JsonConverter<MsTeams>
{
    public override MsTeams? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<SendToMsTeamsUserID>(ref reader, options);
            if (deserialized != null)
            {
                return new MsTeamsVariants::SendToMsTeamsUserID(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MsTeamsVariants::SendToMsTeamsUserID",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SendToMsTeamsEmail>(ref reader, options);
            if (deserialized != null)
            {
                return new MsTeamsVariants::SendToMsTeamsEmail(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MsTeamsVariants::SendToMsTeamsEmail",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SendToMsTeamsChannelID>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new MsTeamsVariants::SendToMsTeamsChannelID(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MsTeamsVariants::SendToMsTeamsChannelID",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SendToMsTeamsConversationID>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new MsTeamsVariants::SendToMsTeamsConversationID(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MsTeamsVariants::SendToMsTeamsConversationID",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SendToMsTeamsChannelName>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new MsTeamsVariants::SendToMsTeamsChannelName(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant MsTeamsVariants::SendToMsTeamsChannelName",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, MsTeams value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            MsTeamsVariants::SendToMsTeamsUserID(var sendToMsTeamsUserID) => sendToMsTeamsUserID,
            MsTeamsVariants::SendToMsTeamsEmail(var sendToMsTeamsEmail) => sendToMsTeamsEmail,
            MsTeamsVariants::SendToMsTeamsChannelID(var sendToMsTeamsChannelID) =>
                sendToMsTeamsChannelID,
            MsTeamsVariants::SendToMsTeamsConversationID(var sendToMsTeamsConversationID) =>
                sendToMsTeamsConversationID,
            MsTeamsVariants::SendToMsTeamsChannelName(var sendToMsTeamsChannelName) =>
                sendToMsTeamsChannelName,
            _ => throw new CourierInvalidDataException("Data did not match any variant of MsTeams"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
