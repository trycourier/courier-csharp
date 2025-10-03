using Courier.Core;
using Audiences = Courier.Models.Audiences;
using FilterProperties = Courier.Models.Audiences.FilterProperties;

namespace Courier.Models.Audiences.FilterVariants;

public sealed record class UnionMember0(FilterProperties::UnionMember0 Value)
    : Filter,
        IVariant<UnionMember0, FilterProperties::UnionMember0>
{
    public static UnionMember0 From(FilterProperties::UnionMember0 value)
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
    : Filter,
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
