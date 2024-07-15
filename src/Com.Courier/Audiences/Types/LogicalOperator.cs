using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<LogicalOperator>))]
public enum LogicalOperator
{
    [EnumMember(Value = "AND")]
    And,

    [EnumMember(Value = "OR")]
    Or
}
