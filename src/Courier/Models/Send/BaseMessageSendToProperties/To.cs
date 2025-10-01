using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Bulk;
using Courier.Models.Send.BaseMessageSendToProperties.ToProperties;
using ToVariants = Courier.Models.Send.BaseMessageSendToProperties.ToVariants;

namespace Courier.Models.Send.BaseMessageSendToProperties;

/// <summary>
/// The recipient or a list of recipients of the message
/// </summary>
[JsonConverter(typeof(ToConverter))]
public abstract record class To
{
    internal To() { }

    public static implicit operator To(AudienceRecipient value) =>
        new ToVariants::AudienceRecipient(value);

    public static implicit operator To(UnionMember1 value) => new ToVariants::UnionMember1(value);

    public static implicit operator To(UnionMember2 value) => new ToVariants::UnionMember2(value);

    public static implicit operator To(UserRecipient value) => new ToVariants::UserRecipient(value);

    public static implicit operator To(SlackRecipient value) =>
        new ToVariants::SlackRecipient(value);

    public static implicit operator To(MsTeamsRecipient value) =>
        new ToVariants::MsTeamsRecipient(value);

    public static implicit operator To(Dictionary<string, JsonElement> value) =>
        new ToVariants::RecipientData(value);

    public static implicit operator To(PagerdutyRecipient value) =>
        new ToVariants::PagerdutyRecipient(value);

    public static implicit operator To(WebhookRecipient value) =>
        new ToVariants::WebhookRecipient(value);

    public static implicit operator To(List<Recipient> value) => new ToVariants::Recipients(value);

    public bool TryPickAudienceRecipient([NotNullWhen(true)] out AudienceRecipient? value)
    {
        value = (this as ToVariants::AudienceRecipient)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = (this as ToVariants::UnionMember1)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember2([NotNullWhen(true)] out UnionMember2? value)
    {
        value = (this as ToVariants::UnionMember2)?.Value;
        return value != null;
    }

    public bool TryPickUserRecipient([NotNullWhen(true)] out UserRecipient? value)
    {
        value = (this as ToVariants::UserRecipient)?.Value;
        return value != null;
    }

    public bool TryPickSlackRecipient([NotNullWhen(true)] out SlackRecipient? value)
    {
        value = (this as ToVariants::SlackRecipient)?.Value;
        return value != null;
    }

    public bool TryPickMsTeamsRecipient([NotNullWhen(true)] out MsTeamsRecipient? value)
    {
        value = (this as ToVariants::MsTeamsRecipient)?.Value;
        return value != null;
    }

    public bool TryPickRecipientData([NotNullWhen(true)] out Dictionary<string, JsonElement>? value)
    {
        value = (this as ToVariants::RecipientData)?.Value;
        return value != null;
    }

    public bool TryPickPagerdutyRecipient([NotNullWhen(true)] out PagerdutyRecipient? value)
    {
        value = (this as ToVariants::PagerdutyRecipient)?.Value;
        return value != null;
    }

    public bool TryPickWebhookRecipient([NotNullWhen(true)] out WebhookRecipient? value)
    {
        value = (this as ToVariants::WebhookRecipient)?.Value;
        return value != null;
    }

    public bool TryPickRecipients([NotNullWhen(true)] out List<Recipient>? value)
    {
        value = (this as ToVariants::Recipients)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ToVariants::AudienceRecipient> audienceRecipient,
        Action<ToVariants::UnionMember1> unionMember1,
        Action<ToVariants::UnionMember2> unionMember2,
        Action<ToVariants::UserRecipient> userRecipient,
        Action<ToVariants::SlackRecipient> slackRecipient,
        Action<ToVariants::MsTeamsRecipient> msTeamsRecipient,
        Action<ToVariants::RecipientData> recipientData,
        Action<ToVariants::PagerdutyRecipient> pagerdutyRecipient,
        Action<ToVariants::WebhookRecipient> webhookRecipient,
        Action<ToVariants::Recipients> recipients
    )
    {
        switch (this)
        {
            case ToVariants::AudienceRecipient inner:
                audienceRecipient(inner);
                break;
            case ToVariants::UnionMember1 inner:
                unionMember1(inner);
                break;
            case ToVariants::UnionMember2 inner:
                unionMember2(inner);
                break;
            case ToVariants::UserRecipient inner:
                userRecipient(inner);
                break;
            case ToVariants::SlackRecipient inner:
                slackRecipient(inner);
                break;
            case ToVariants::MsTeamsRecipient inner:
                msTeamsRecipient(inner);
                break;
            case ToVariants::RecipientData inner:
                recipientData(inner);
                break;
            case ToVariants::PagerdutyRecipient inner:
                pagerdutyRecipient(inner);
                break;
            case ToVariants::WebhookRecipient inner:
                webhookRecipient(inner);
                break;
            case ToVariants::Recipients inner:
                recipients(inner);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of To");
        }
    }

    public T Match<T>(
        Func<ToVariants::AudienceRecipient, T> audienceRecipient,
        Func<ToVariants::UnionMember1, T> unionMember1,
        Func<ToVariants::UnionMember2, T> unionMember2,
        Func<ToVariants::UserRecipient, T> userRecipient,
        Func<ToVariants::SlackRecipient, T> slackRecipient,
        Func<ToVariants::MsTeamsRecipient, T> msTeamsRecipient,
        Func<ToVariants::RecipientData, T> recipientData,
        Func<ToVariants::PagerdutyRecipient, T> pagerdutyRecipient,
        Func<ToVariants::WebhookRecipient, T> webhookRecipient,
        Func<ToVariants::Recipients, T> recipients
    )
    {
        return this switch
        {
            ToVariants::AudienceRecipient inner => audienceRecipient(inner),
            ToVariants::UnionMember1 inner => unionMember1(inner),
            ToVariants::UnionMember2 inner => unionMember2(inner),
            ToVariants::UserRecipient inner => userRecipient(inner),
            ToVariants::SlackRecipient inner => slackRecipient(inner),
            ToVariants::MsTeamsRecipient inner => msTeamsRecipient(inner),
            ToVariants::RecipientData inner => recipientData(inner),
            ToVariants::PagerdutyRecipient inner => pagerdutyRecipient(inner),
            ToVariants::WebhookRecipient inner => webhookRecipient(inner),
            ToVariants::Recipients inner => recipients(inner),
            _ => throw new CourierInvalidDataException("Data did not match any variant of To"),
        };
    }

    public abstract void Validate();
}

sealed class ToConverter : JsonConverter<To?>
{
    public override To? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<AudienceRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::AudienceRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::AudienceRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::UnionMember1(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::UnionMember1",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember2>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::UnionMember2(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::UnionMember2",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UserRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::UserRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::UserRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SlackRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::SlackRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::SlackRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<MsTeamsRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::MsTeamsRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::MsTeamsRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PagerdutyRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::PagerdutyRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::PagerdutyRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebhookRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::WebhookRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::WebhookRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToVariants::RecipientData(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::RecipientData",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Recipient>>(ref reader, options);
            if (deserialized != null)
            {
                return new ToVariants::Recipients(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant ToVariants::Recipients",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, To? value, JsonSerializerOptions options)
    {
        object? variant = value switch
        {
            null => null,
            ToVariants::AudienceRecipient(var audienceRecipient) => audienceRecipient,
            ToVariants::UnionMember1(var unionMember1) => unionMember1,
            ToVariants::UnionMember2(var unionMember2) => unionMember2,
            ToVariants::UserRecipient(var userRecipient) => userRecipient,
            ToVariants::SlackRecipient(var slackRecipient) => slackRecipient,
            ToVariants::MsTeamsRecipient(var msTeamsRecipient) => msTeamsRecipient,
            ToVariants::RecipientData(var recipientData) => recipientData,
            ToVariants::PagerdutyRecipient(var pagerdutyRecipient) => pagerdutyRecipient,
            ToVariants::WebhookRecipient(var webhookRecipient) => webhookRecipient,
            ToVariants::Recipients(var recipients) => recipients,
            _ => throw new CourierInvalidDataException("Data did not match any variant of To"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
