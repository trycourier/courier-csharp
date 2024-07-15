using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<LogicalOperator>))]
public enum LogicalOperator
{
    [EnumMember(Value = "AND")]
    And,

    [EnumMember(Value = "OR")]
    Or
}
