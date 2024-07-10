using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

[JsonConverter(typeof(StringEnumSerializer<AutomationFetchDataWebhookMethod>))]
public enum AutomationFetchDataWebhookMethod
{
    [EnumMember(Value = "GET")]
    Get,

    [EnumMember(Value = "POST")]
    Post
}
