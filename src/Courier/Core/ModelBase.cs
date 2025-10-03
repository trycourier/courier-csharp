using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Send.MessageRoutingProperties;
using Courier.Models.Send.PreferenceProperties;
using Courier.Models.Send.PreferenceProperties.ChannelPreferenceProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ChannelsProperties.ChannelsItemProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.TimeoutProperties;
using RoutingProperties = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.RoutingProperties;

namespace Courier.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Method>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Channel>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, RoutingMethod>(),
            new ApiEnumConverter<string, RoutingProperties::Method>(),
            new ApiEnumConverter<string, Criteria>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(Dictionary<string, JsonElement> properties);
}
