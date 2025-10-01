using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using Courier.Models.Bulk;
using Courier.Models.Send.RecipientProperties;
using RecipientVariants = Courier.Models.Send.RecipientVariants;

namespace Courier.Models.Send;

[JsonConverter(typeof(RecipientConverter))]
public abstract record class Recipient
{
    internal Recipient() { }

    public static implicit operator Recipient(AudienceRecipient value) =>
        new RecipientVariants::AudienceRecipient(value);

    public static implicit operator Recipient(UnionMember1 value) =>
        new RecipientVariants::UnionMember1(value);

    public static implicit operator Recipient(UnionMember2 value) =>
        new RecipientVariants::UnionMember2(value);

    public static implicit operator Recipient(UserRecipient value) =>
        new RecipientVariants::UserRecipient(value);

    public static implicit operator Recipient(SlackRecipient value) =>
        new RecipientVariants::SlackRecipient(value);

    public static implicit operator Recipient(MsTeamsRecipient value) =>
        new RecipientVariants::MsTeamsRecipient(value);

    public static implicit operator Recipient(Dictionary<string, JsonElement> value) =>
        new RecipientVariants::RecipientData(value);

    public static implicit operator Recipient(PagerdutyRecipient value) =>
        new RecipientVariants::PagerdutyRecipient(value);

    public static implicit operator Recipient(WebhookRecipient value) =>
        new RecipientVariants::WebhookRecipient(value);

    public bool TryPickAudience([NotNullWhen(true)] out AudienceRecipient? value)
    {
        value = (this as RecipientVariants::AudienceRecipient)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = (this as RecipientVariants::UnionMember1)?.Value;
        return value != null;
    }

    public bool TryPickUnionMember2([NotNullWhen(true)] out UnionMember2? value)
    {
        value = (this as RecipientVariants::UnionMember2)?.Value;
        return value != null;
    }

    public bool TryPickUser([NotNullWhen(true)] out UserRecipient? value)
    {
        value = (this as RecipientVariants::UserRecipient)?.Value;
        return value != null;
    }

    public bool TryPickSlack([NotNullWhen(true)] out SlackRecipient? value)
    {
        value = (this as RecipientVariants::SlackRecipient)?.Value;
        return value != null;
    }

    public bool TryPickMsTeams([NotNullWhen(true)] out MsTeamsRecipient? value)
    {
        value = (this as RecipientVariants::MsTeamsRecipient)?.Value;
        return value != null;
    }

    public bool TryPickData([NotNullWhen(true)] out Dictionary<string, JsonElement>? value)
    {
        value = (this as RecipientVariants::RecipientData)?.Value;
        return value != null;
    }

    public bool TryPickPagerduty([NotNullWhen(true)] out PagerdutyRecipient? value)
    {
        value = (this as RecipientVariants::PagerdutyRecipient)?.Value;
        return value != null;
    }

    public bool TryPickWebhook([NotNullWhen(true)] out WebhookRecipient? value)
    {
        value = (this as RecipientVariants::WebhookRecipient)?.Value;
        return value != null;
    }

    public void Switch(
        Action<RecipientVariants::AudienceRecipient> audience,
        Action<RecipientVariants::UnionMember1> unionMember1,
        Action<RecipientVariants::UnionMember2> unionMember2,
        Action<RecipientVariants::UserRecipient> user,
        Action<RecipientVariants::SlackRecipient> slack,
        Action<RecipientVariants::MsTeamsRecipient> msTeams,
        Action<RecipientVariants::RecipientData> recipientData,
        Action<RecipientVariants::PagerdutyRecipient> pagerduty,
        Action<RecipientVariants::WebhookRecipient> webhook
    )
    {
        switch (this)
        {
            case RecipientVariants::AudienceRecipient inner:
                audience(inner);
                break;
            case RecipientVariants::UnionMember1 inner:
                unionMember1(inner);
                break;
            case RecipientVariants::UnionMember2 inner:
                unionMember2(inner);
                break;
            case RecipientVariants::UserRecipient inner:
                user(inner);
                break;
            case RecipientVariants::SlackRecipient inner:
                slack(inner);
                break;
            case RecipientVariants::MsTeamsRecipient inner:
                msTeams(inner);
                break;
            case RecipientVariants::RecipientData inner:
                recipientData(inner);
                break;
            case RecipientVariants::PagerdutyRecipient inner:
                pagerduty(inner);
                break;
            case RecipientVariants::WebhookRecipient inner:
                webhook(inner);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of Recipient"
                );
        }
    }

    public T Match<T>(
        Func<RecipientVariants::AudienceRecipient, T> audience,
        Func<RecipientVariants::UnionMember1, T> unionMember1,
        Func<RecipientVariants::UnionMember2, T> unionMember2,
        Func<RecipientVariants::UserRecipient, T> user,
        Func<RecipientVariants::SlackRecipient, T> slack,
        Func<RecipientVariants::MsTeamsRecipient, T> msTeams,
        Func<RecipientVariants::RecipientData, T> recipientData,
        Func<RecipientVariants::PagerdutyRecipient, T> pagerduty,
        Func<RecipientVariants::WebhookRecipient, T> webhook
    )
    {
        return this switch
        {
            RecipientVariants::AudienceRecipient inner => audience(inner),
            RecipientVariants::UnionMember1 inner => unionMember1(inner),
            RecipientVariants::UnionMember2 inner => unionMember2(inner),
            RecipientVariants::UserRecipient inner => user(inner),
            RecipientVariants::SlackRecipient inner => slack(inner),
            RecipientVariants::MsTeamsRecipient inner => msTeams(inner),
            RecipientVariants::RecipientData inner => recipientData(inner),
            RecipientVariants::PagerdutyRecipient inner => pagerduty(inner),
            RecipientVariants::WebhookRecipient inner => webhook(inner),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of Recipient"
            ),
        };
    }

    public abstract void Validate();
}

sealed class RecipientConverter : JsonConverter<Recipient>
{
    public override Recipient? Read(
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
                return new RecipientVariants::AudienceRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::AudienceRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(ref reader, options);
            if (deserialized != null)
            {
                return new RecipientVariants::UnionMember1(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::UnionMember1",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember2>(ref reader, options);
            if (deserialized != null)
            {
                return new RecipientVariants::UnionMember2(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::UnionMember2",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UserRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new RecipientVariants::UserRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::UserRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SlackRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new RecipientVariants::SlackRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::SlackRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<MsTeamsRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new RecipientVariants::MsTeamsRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::MsTeamsRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PagerdutyRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new RecipientVariants::PagerdutyRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::PagerdutyRecipient",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebhookRecipient>(ref reader, options);
            if (deserialized != null)
            {
                return new RecipientVariants::WebhookRecipient(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::WebhookRecipient",
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
                return new RecipientVariants::RecipientData(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant RecipientVariants::RecipientData",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Recipient value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            RecipientVariants::AudienceRecipient(var audience) => audience,
            RecipientVariants::UnionMember1(var unionMember1) => unionMember1,
            RecipientVariants::UnionMember2(var unionMember2) => unionMember2,
            RecipientVariants::UserRecipient(var user) => user,
            RecipientVariants::SlackRecipient(var slack) => slack,
            RecipientVariants::MsTeamsRecipient(var msTeams) => msTeams,
            RecipientVariants::RecipientData(var recipientData) => recipientData,
            RecipientVariants::PagerdutyRecipient(var pagerduty) => pagerduty,
            RecipientVariants::WebhookRecipient(var webhook) => webhook,
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of Recipient"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
