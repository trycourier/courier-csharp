using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Send.MessageRoutingProperties;
using Courier.Models.Send.RecipientProperties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties;
using Courier.Models.Send.RecipientProperties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties.ChannelPreferenceProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ChannelsProperties.ChannelsItemProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.TimeoutProperties;
using CategoriesItemProperties = Courier.Models.Send.RecipientProperties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties;
using ChannelPreferenceProperties = Courier.Models.Send.RecipientProperties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties.ChannelPreferenceProperties;
using NotificationsItemProperties = Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties;
using RoutingProperties = Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.RoutingProperties;

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
            new ApiEnumConverter<string, CategoriesItemProperties::Status>(),
            new ApiEnumConverter<string, ChannelPreferenceProperties::Channel>(),
            new ApiEnumConverter<string, CategoriesItemProperties::Source>(),
            new ApiEnumConverter<string, RoutingMethod>(),
            new ApiEnumConverter<string, RoutingProperties::Method>(),
            new ApiEnumConverter<string, Criteria>(),
            new ApiEnumConverter<string, NotificationsItemProperties::Status>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties.ChannelPreferenceProperties.Channel
            >(),
            new ApiEnumConverter<string, NotificationsItemProperties::Source>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties.Status
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties.ChannelPreferenceProperties.Channel
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties.Source
            >(),
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
