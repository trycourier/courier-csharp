using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<WebhookMethod>))]
public enum WebhookMethod
{
    [EnumMember(Value = "POST")]
    Post,

    [EnumMember(Value = "PUT")]
    Put,
}
