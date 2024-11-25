using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<AutomationFetchDataWebhookMethod>))]
public enum AutomationFetchDataWebhookMethod
{
    [EnumMember(Value = "GET")]
    Get,

    [EnumMember(Value = "POST")]
    Post,
}
