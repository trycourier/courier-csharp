using Courier.Core;
using ChannelProperties = Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelProperties;

namespace Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelVariants;

public sealed record class RoutingStrategyChannel(ChannelProperties::RoutingStrategyChannel Value)
    : Channel,
        IVariant<RoutingStrategyChannel, ChannelProperties::RoutingStrategyChannel>
{
    public static RoutingStrategyChannel From(ChannelProperties::RoutingStrategyChannel value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RoutingStrategyProvider(ChannelProperties::RoutingStrategyProvider Value)
    : Channel,
        IVariant<RoutingStrategyProvider, ChannelProperties::RoutingStrategyProvider>
{
    public static RoutingStrategyProvider From(ChannelProperties::RoutingStrategyProvider value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class String(string Value) : Channel, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
