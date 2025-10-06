using Courier.Core;

namespace Courier.Models.Users.Tokens.TokenAddSingleParamsProperties.ExpiryDateVariants;

public sealed record class String(string Value) : ExpiryDate, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Bool(bool Value) : ExpiryDate, IVariant<Bool, bool>
{
    public static Bool From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}
