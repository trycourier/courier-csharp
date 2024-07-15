using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<RoutingStrategyMethod>))]
public enum RoutingStrategyMethod
{
    [EnumMember(Value = "all")]
    All,

    [EnumMember(Value = "single")]
    Single
}
