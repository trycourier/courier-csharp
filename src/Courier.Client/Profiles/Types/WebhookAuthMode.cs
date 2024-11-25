using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<WebhookAuthMode>))]
public enum WebhookAuthMode
{
    [EnumMember(Value = "none")]
    None,

    [EnumMember(Value = "basic")]
    Basic,

    [EnumMember(Value = "bearer")]
    Bearer,
}
