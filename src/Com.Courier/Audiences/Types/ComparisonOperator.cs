using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<ComparisonOperator>))]
public enum ComparisonOperator
{
    [EnumMember(Value = "ENDS_WITH")]
    EndsWith,

    [EnumMember(Value = "EQ")]
    Eq,

    [EnumMember(Value = "EXISTS")]
    Exists,

    [EnumMember(Value = "GT")]
    Gt,

    [EnumMember(Value = "GTE")]
    Gte,

    [EnumMember(Value = "INCLUDES")]
    Includes,

    [EnumMember(Value = "IS_AFTER")]
    IsAfter,

    [EnumMember(Value = "IS_BEFORE")]
    IsBefore,

    [EnumMember(Value = "LT")]
    Lt,

    [EnumMember(Value = "LTE")]
    Lte,

    [EnumMember(Value = "NEQ")]
    Neq,

    [EnumMember(Value = "OMIT")]
    Omit,

    [EnumMember(Value = "STARTS_WITH")]
    StartsWith
}
