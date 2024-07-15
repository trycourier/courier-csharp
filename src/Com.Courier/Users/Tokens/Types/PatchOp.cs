using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier.Core;
using Com.Courier.Users;

#nullable enable

namespace Com.Courier.Users;

[JsonConverter(typeof(StringEnumSerializer<PatchOp>))]
public enum PatchOp
{
    [EnumMember(Value = "replace")]
    Replace,

    [EnumMember(Value = "add")]
    Add,

    [EnumMember(Value = "remove")]
    Remove,

    [EnumMember(Value = "copy")]
    Copy,

    [EnumMember(Value = "move")]
    Move,

    [EnumMember(Value = "test")]
    Test
}
