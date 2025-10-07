using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Audiences.FilterProperties.UnionMember0Properties;
using Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationDelayStepProperties;
using Courier.Models.Brands.BrandSettingsInAppProperties;
using Courier.Models.Bulk.BulkListUsersResponseProperties.ItemProperties.IntersectionMember1Properties;
using Courier.Models.Inbound.InboundTrackEventParamsProperties;
using Courier.Models.PreferenceProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ChannelsProperties.ChannelsItemProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.RoutingProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.TimeoutProperties;
using Courier.Models.Tenants.DefaultPreferences.Items;
using Courier.Models.Tenants.Templates;
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
using IntersectionMember1Properties = Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties.UnionMember0Properties.IntersectionMember1Properties;
using ItemUpdateParamsProperties = Courier.Models.Tenants.DefaultPreferences.Items.ItemUpdateParamsProperties;
using JobProperties = Courier.Models.Bulk.BulkRetrieveJobResponseProperties.JobProperties;
using ListDeleteResponseProperties = Courier.Models.Profiles.Lists.ListDeleteResponseProperties;
using ListSubscribeResponseProperties = Courier.Models.Profiles.Lists.ListSubscribeResponseProperties;
using MessageDetailsProperties = Courier.Models.Messages.MessageDetailsProperties;
using MessageRoutingProperties = Courier.Models.Notifications.MessageRoutingProperties;
using NestedFilterConfigProperties = Courier.Models.Audiences.NestedFilterConfigProperties;
using ProfileCreateResponseProperties = Courier.Models.Profiles.ProfileCreateResponseProperties;
using ProfileReplaceResponseProperties = Courier.Models.Profiles.ProfileReplaceResponseProperties;
using SubscriptionTopicNewProperties = Courier.Models.Tenants.DefaultPreferences.Items.SubscriptionTopicNewProperties;
using TemplateListResponseProperties = Courier.Models.Tenants.Templates.TemplateListResponseProperties;
using TenantAssociationProperties = Courier.Models.Users.Tenants.TenantAssociationProperties;
using TenantListResponseProperties = Courier.Models.Tenants.TenantListResponseProperties;
using TenantListUsersResponseProperties = Courier.Models.Tenants.TenantListUsersResponseProperties;
using TokenAddSingleParamsProperties = Courier.Models.Users.Tokens.TokenAddSingleParamsProperties;
using UnionMember0Properties = Courier.Models.Audiences.FilterConfigProperties.UnionMember0Properties;
using UnionMember4Properties = Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties.UnionMember4Properties;
using WebhookProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationFetchDataStepProperties.WebhookProperties;

namespace Courier.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, RoutingMethod>(),
            new ApiEnumConverter<string, Method>(),
            new ApiEnumConverter<string, Criteria>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, UnionMember0Properties::Operator>(),
            new ApiEnumConverter<string, NestedFilterConfigProperties::Operator>(),
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
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, MessageDetailsProperties::Status>(),
            new ApiEnumConverter<string, MessageDetailsProperties::Reason>(),
            new ApiEnumConverter<string, MessageRoutingProperties::Method>(),
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
            new ApiEnumConverter<string, Alignment>(),
            new ApiEnumConverter<string, IntersectionMember1Properties::Type>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties.UnionMember1Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties.UnionMember2Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties.UnionMember3Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<string, UnionMember4Properties::Style>(),
            new ApiEnumConverter<string, UnionMember4Properties::Type>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties.UnionMember5Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Tenants.Templates.ElementalContentProperties.ElementProperties.UnionMember6Properties.IntersectionMember1Properties.Type
            >(),
            new ApiEnumConverter<string, TextStyle>(),
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
