using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Bulk = Courier.Models.Bulk;
using ToProperties = Courier.Models.Send.BaseMessageSendToProperties.ToProperties;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToVariants;

public sealed record class AudienceRecipient(ToProperties::AudienceRecipient Value)
    : To,
        IVariant<AudienceRecipient, ToProperties::AudienceRecipient>
{
    public static AudienceRecipient From(ToProperties::AudienceRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember1(ToProperties::UnionMember1 Value)
    : To,
        IVariant<UnionMember1, ToProperties::UnionMember1>
{
    public static UnionMember1 From(ToProperties::UnionMember1 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnionMember2(ToProperties::UnionMember2 Value)
    : To,
        IVariant<UnionMember2, ToProperties::UnionMember2>
{
    public static UnionMember2 From(ToProperties::UnionMember2 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UserRecipient(Bulk::UserRecipient Value)
    : To,
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

public sealed record class SlackRecipient(ToProperties::SlackRecipient Value)
    : To,
        IVariant<SlackRecipient, ToProperties::SlackRecipient>
{
    public static SlackRecipient From(ToProperties::SlackRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MsTeamsRecipient(ToProperties::MsTeamsRecipient Value)
    : To,
        IVariant<MsTeamsRecipient, ToProperties::MsTeamsRecipient>
{
    public static MsTeamsRecipient From(ToProperties::MsTeamsRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RecipientData(Dictionary<string, JsonElement> Value)
    : To,
        IVariant<RecipientData, Dictionary<string, JsonElement>>
{
    public static RecipientData From(Dictionary<string, JsonElement> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class PagerdutyRecipient(ToProperties::PagerdutyRecipient Value)
    : To,
        IVariant<PagerdutyRecipient, ToProperties::PagerdutyRecipient>
{
    public static PagerdutyRecipient From(ToProperties::PagerdutyRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebhookRecipient(ToProperties::WebhookRecipient Value)
    : To,
        IVariant<WebhookRecipient, ToProperties::WebhookRecipient>
{
    public static WebhookRecipient From(ToProperties::WebhookRecipient value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Recipients(List<Recipient> Value)
    : To,
        IVariant<Recipients, List<Recipient>>
{
    public static Recipients From(List<Recipient> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
