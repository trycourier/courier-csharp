using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<PreferenceStatus>))]
public enum PreferenceStatus
{
    [EnumMember(Value = "OPTED_IN")]
    OptedIn,

    [EnumMember(Value = "OPTED_OUT")]
    OptedOut,

    [EnumMember(Value = "REQUIRED")]
    Required
}
