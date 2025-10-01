using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Bulk = Courier.Models.Bulk;
using RecipientProperties = Courier.Models.Send.RecipientProperties;

namespace Courier.Models.Send.RecipientVariants;

public sealed record class AudienceRecipient(RecipientProperties::AudienceRecipient Value)
    : Recipient,
        IVariant<AudienceRecipient, RecipientProperties::AudienceRecipient>
{
    public static AudienceRecipient From(RecipientProperties::AudienceRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember1(RecipientProperties::UnionMember1 Value)
    : Recipient,
        IVariant<UnionMember1, RecipientProperties::UnionMember1>
{
    public static UnionMember1 From(RecipientProperties::UnionMember1 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember2(RecipientProperties::UnionMember2 Value)
    : Recipient,
        IVariant<UnionMember2, RecipientProperties::UnionMember2>
{
    public static UnionMember2 From(RecipientProperties::UnionMember2 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UserRecipient(Bulk::UserRecipient Value)
    : Recipient,
        IVariant<UserRecipient, Bulk::UserRecipient>
{
    public static UserRecipient From(Bulk::UserRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SlackRecipient(RecipientProperties::SlackRecipient Value)
    : Recipient,
        IVariant<SlackRecipient, RecipientProperties::SlackRecipient>
{
    public static SlackRecipient From(RecipientProperties::SlackRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MsTeamsRecipient(RecipientProperties::MsTeamsRecipient Value)
    : Recipient,
        IVariant<MsTeamsRecipient, RecipientProperties::MsTeamsRecipient>
{
    public static MsTeamsRecipient From(RecipientProperties::MsTeamsRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RecipientData(Dictionary<string, JsonElement> Value)
    : Recipient,
        IVariant<RecipientData, Dictionary<string, JsonElement>>
{
    public static RecipientData From(Dictionary<string, JsonElement> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class PagerdutyRecipient(RecipientProperties::PagerdutyRecipient Value)
    : Recipient,
        IVariant<PagerdutyRecipient, RecipientProperties::PagerdutyRecipient>
{
    public static PagerdutyRecipient From(RecipientProperties::PagerdutyRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebhookRecipient(RecipientProperties::WebhookRecipient Value)
    : Recipient,
        IVariant<WebhookRecipient, RecipientProperties::WebhookRecipient>
{
    public static WebhookRecipient From(RecipientProperties::WebhookRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
