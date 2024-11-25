using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<AutomationAddToBatchScope>))]
public enum AutomationAddToBatchScope
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "global")]
    Global,

    [EnumMember(Value = "dynamic")]
    Dynamic,
}
