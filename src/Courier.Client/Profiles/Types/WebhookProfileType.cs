using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<WebhookProfileType>))]
public enum WebhookProfileType
{
    [EnumMember(Value = "limited")]
    Limited,

    [EnumMember(Value = "expanded")]
    Expanded,
}
