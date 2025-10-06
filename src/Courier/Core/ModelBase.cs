using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Send.ElementalNodeProperties.UnionMember0Properties;
using Courier.Models.Send.MessageRoutingProperties;
using Courier.Models.Send.PreferenceProperties;
using Courier.Models.Send.PreferenceProperties.ChannelPreferenceProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ChannelsProperties.ChannelsItemProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.TimeoutProperties;
using IntersectionMember1Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember2Properties.IntersectionMember1Properties;
using RoutingProperties = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.RoutingProperties;
using UnionMember1Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember1Properties;
using UnionMember3Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember3Properties;
using UnionMember4Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember4Properties;
using UnionMember5Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember5Properties;
using UnionMember7Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember7Properties;

namespace Courier.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, UnionMember1Properties::Type>(),
            new ApiEnumConverter<string, IntersectionMember1Properties::Type>(),
            new ApiEnumConverter<string, UnionMember3Properties::Type>(),
            new ApiEnumConverter<string, UnionMember4Properties::Align>(),
            new ApiEnumConverter<string, UnionMember4Properties::Style>(),
            new ApiEnumConverter<string, UnionMember4Properties::Type>(),
            new ApiEnumConverter<string, UnionMember5Properties::Type>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.ElementalNodeProperties.UnionMember6Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<string, UnionMember7Properties::Type>(),
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
