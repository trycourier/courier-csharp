using Courier.Core;

namespace Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ExpiryProperties.ExpiresInVariants;

public sealed record class String(string Value) : ExpiresIn, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Long(long Value) : ExpiresIn, IVariant<Long, long>
{
    public static Long From(long value)
    {
        return new(value);
    }

    public override void Validate() { }
}
