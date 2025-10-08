using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Audiences.FilterProperties;
using Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationDelayStepProperties;
using Courier.Models.Brands.BrandSettingsInAppProperties;
using Courier.Models.Bulk.BulkListUsersResponseProperties.ItemProperties.IntersectionMember1Properties;
using Courier.Models.MessageRoutingProperties;
using Courier.Models.PreferenceProperties;
using Courier.Models.Send.ElementalNodeProperties.UnionMember0Properties.IntersectionMember1Properties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ChannelsProperties.ChannelsItemProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.TimeoutProperties;
using Courier.Models.Tenants.DefaultPreferences.Items;
using Courier.Models.Users.Preferences;
using Courier.Models.Users.Tokens.UserTokenProperties;
using AutomationCancelStepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationCancelStepProperties;
using AutomationFetchDataStepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationFetchDataStepProperties;
using AutomationInvokeStepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationInvokeStepProperties;
using AutomationSendListStepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationSendListStepProperties;
using AutomationSendStepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationSendStepProperties;
using AutomationUpdateProfileStepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationUpdateProfileStepProperties;
using BaseCheckProperties = Courier.Models.Notifications.Checks.BaseCheckProperties;
using BlockProperties = Courier.Models.Notifications.NotificationGetContentProperties.BlockProperties;
using FilterConfigProperties = Courier.Models.Audiences.FilterConfigProperties;
using InboundTrackEventParamsProperties = Courier.Models.Inbound.InboundTrackEventParamsProperties;
using IntersectionMember1Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember1Properties.IntersectionMember1Properties;
using ItemUpdateParamsProperties = Courier.Models.Tenants.DefaultPreferences.Items.ItemUpdateParamsProperties;
using JobProperties = Courier.Models.Bulk.BulkRetrieveJobResponseProperties.JobProperties;
using ListDeleteResponseProperties = Courier.Models.Profiles.Lists.ListDeleteResponseProperties;
using ListSubscribeResponseProperties = Courier.Models.Profiles.Lists.ListSubscribeResponseProperties;
using MessageDetailsProperties = Courier.Models.Messages.MessageDetailsProperties;
using ProfileCreateResponseProperties = Courier.Models.Profiles.ProfileCreateResponseProperties;
using ProfileReplaceResponseProperties = Courier.Models.Profiles.ProfileReplaceResponseProperties;
using RoutingProperties = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.RoutingProperties;
using SubscriptionTopicNewProperties = Courier.Models.Tenants.DefaultPreferences.Items.SubscriptionTopicNewProperties;
using TemplateListResponseProperties = Courier.Models.Tenants.Templates.TemplateListResponseProperties;
using TenantAssociationProperties = Courier.Models.Users.Tenants.TenantAssociationProperties;
using TenantListResponseProperties = Courier.Models.Tenants.TenantListResponseProperties;
using TenantListUsersResponseProperties = Courier.Models.Tenants.TenantListUsersResponseProperties;
using TokenAddSingleParamsProperties = Courier.Models.Users.Tokens.TokenAddSingleParamsProperties;
using WebhookProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationFetchDataStepProperties.WebhookProperties;

namespace Courier.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Alignment>(),
            new ApiEnumConverter<string, Method>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, TextStyle>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, IntersectionMember1Properties::Type>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.ElementalNodeProperties.UnionMember2Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.ElementalNodeProperties.UnionMember3Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.ElementalNodeProperties.UnionMember4Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.ElementalNodeProperties.UnionMember5Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.ElementalNodeProperties.UnionMember6Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<string, RoutingMethod>(),
            new ApiEnumConverter<string, RoutingProperties::Method>(),
            new ApiEnumConverter<string, Criteria>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, FilterConfigProperties::Operator>(),
            new ApiEnumConverter<string, Action>(),
            new ApiEnumConverter<string, AutomationSendStepProperties::Action>(),
            new ApiEnumConverter<string, AutomationSendListStepProperties::Action>(),
            new ApiEnumConverter<string, AutomationUpdateProfileStepProperties::Action>(),
            new ApiEnumConverter<string, AutomationUpdateProfileStepProperties::Merge>(),
            new ApiEnumConverter<string, AutomationCancelStepProperties::Action>(),
            new ApiEnumConverter<string, AutomationFetchDataStepProperties::Action>(),
            new ApiEnumConverter<string, WebhookProperties::Method>(),
            new ApiEnumConverter<string, AutomationFetchDataStepProperties::MergeStrategy>(),
            new ApiEnumConverter<string, AutomationInvokeStepProperties::Action>(),
            new ApiEnumConverter<string, Placement>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, JobProperties::Status>(),
            new ApiEnumConverter<string, InboundTrackEventParamsProperties::Type>(),
            new ApiEnumConverter<string, MessageDetailsProperties::Status>(),
            new ApiEnumConverter<string, MessageDetailsProperties::Reason>(),
            new ApiEnumConverter<string, BlockProperties::Type>(),
            new ApiEnumConverter<string, BaseCheckProperties::Status>(),
            new ApiEnumConverter<string, BaseCheckProperties::Type>(),
            new ApiEnumConverter<string, ProfileCreateResponseProperties::Status>(),
            new ApiEnumConverter<string, ProfileReplaceResponseProperties::Status>(),
            new ApiEnumConverter<string, ListDeleteResponseProperties::Status>(),
            new ApiEnumConverter<string, ListSubscribeResponseProperties::Status>(),
            new ApiEnumConverter<string, TenantListResponseProperties::Type>(),
            new ApiEnumConverter<string, TenantListUsersResponseProperties::Type>(),
            new ApiEnumConverter<string, ChannelClassification>(),
            new ApiEnumConverter<string, SubscriptionTopicNewProperties::Status>(),
            new ApiEnumConverter<string, ItemUpdateParamsProperties::Status>(),
            new ApiEnumConverter<string, TemplateListResponseProperties::Type>(),
            new ApiEnumConverter<string, PreferenceStatus>(),
            new ApiEnumConverter<string, TenantAssociationProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Users.Tenants.TenantListResponseProperties.Type
            >(),
            new ApiEnumConverter<string, ProviderKey>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Users.Tokens.TokenRetrieveResponseProperties.IntersectionMember1Properties.Status
            >(),
            new ApiEnumConverter<string, TokenAddSingleParamsProperties::ProviderKey>(),
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
