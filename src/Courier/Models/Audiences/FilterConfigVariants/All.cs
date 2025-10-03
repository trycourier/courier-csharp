using Courier.Core;
using Audiences = Courier.Models.Audiences;
using FilterConfigProperties = Courier.Models.Audiences.FilterConfigProperties;

namespace Courier.Models.Audiences.FilterConfigVariants;

public sealed record class UnionMember0(FilterConfigProperties::UnionMember0 Value)
    : FilterConfig,
        IVariant<UnionMember0, FilterConfigProperties::UnionMember0>
{
    public static UnionMember0 From(FilterConfigProperties::UnionMember0 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// The operator to use for filtering
/// </summary>
public sealed record class NestedFilterConfig(Audiences::NestedFilterConfig Value)
    : FilterConfig,
        IVariant<NestedFilterConfig, Audiences::NestedFilterConfig>
{
    public static NestedFilterConfig From(Audiences::NestedFilterConfig value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
