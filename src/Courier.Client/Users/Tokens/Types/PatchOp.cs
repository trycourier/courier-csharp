using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

[JsonConverter(typeof(EnumSerializer<PatchOp>))]
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
    Test,
}
