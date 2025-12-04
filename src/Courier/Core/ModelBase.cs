using System.Collections.Generic;
using System.Text.Json;
using Courier.Exceptions;
using Courier.Models;
using Courier.Models.Audiences;
using Courier.Models.Brands;
using Courier.Models.Bulk;
using Inbound = Courier.Models.Inbound;
using Invoke = Courier.Models.Automations.Invoke;
using Items = Courier.Models.Tenants.Preferences.Items;
using Lists = Courier.Models.Profiles.Lists;
using Messages = Courier.Models.Messages;
using Notifications = Courier.Models.Notifications;
using Profiles = Courier.Models.Profiles;
using Send = Courier.Models.Send;
using Templates = Courier.Models.Tenants.Templates;
using Tenants = Courier.Models.Tenants;
using Tokens = Courier.Models.Users.Tokens;

namespace Courier.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    /// <summary>
    /// The backing JSON properties of the instance.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Alignment>(),
            new ApiEnumConverter<string, ChannelClassification>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, ElementalChannelNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalDividerNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalImageNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalMetaNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalQuoteNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalTextNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, Method>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, PreferenceStatus>(),
            new ApiEnumConverter<string, TextStyle>(),
            new ApiEnumConverter<string, Send::RoutingMethod>(),
            new ApiEnumConverter<string, Send::Method>(),
            new ApiEnumConverter<string, Send::Criteria>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, FilterConfigOperator>(),
            new ApiEnumConverter<string, Invoke::Action>(),
            new ApiEnumConverter<string, Invoke::AutomationSendStepAction>(),
            new ApiEnumConverter<string, Invoke::AutomationSendListStepAction>(),
            new ApiEnumConverter<string, Invoke::AutomationUpdateProfileStepAction>(),
            new ApiEnumConverter<string, Invoke::Merge>(),
            new ApiEnumConverter<string, Invoke::AutomationCancelStepAction>(),
            new ApiEnumConverter<string, Invoke::AutomationFetchDataStepAction>(),
            new ApiEnumConverter<string, Invoke::Method>(),
            new ApiEnumConverter<string, Invoke::MergeStrategy>(),
            new ApiEnumConverter<string, Invoke::AutomationInvokeStepAction>(),
            new ApiEnumConverter<string, Placement>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, JobStatus>(),
            new ApiEnumConverter<string, Inbound::Type>(),
            new ApiEnumConverter<string, Messages::Status>(),
            new ApiEnumConverter<string, Messages::Reason>(),
            new ApiEnumConverter<string, Notifications::Status>(),
            new ApiEnumConverter<string, Notifications::Type>(),
            new ApiEnumConverter<string, Notifications::BlockType>(),
            new ApiEnumConverter<string, Profiles::Status>(),
            new ApiEnumConverter<string, Profiles::ProfileReplaceResponseStatus>(),
            new ApiEnumConverter<string, Lists::Status>(),
            new ApiEnumConverter<string, Lists::ListSubscribeResponseStatus>(),
            new ApiEnumConverter<string, Tenants::Status>(),
            new ApiEnumConverter<string, Tenants::Type>(),
            new ApiEnumConverter<string, Tenants::TenantListResponseType>(),
            new ApiEnumConverter<string, Tenants::TenantListUsersResponseType>(),
            new ApiEnumConverter<string, Items::Status>(),
            new ApiEnumConverter<string, Templates::Type>(),
            new ApiEnumConverter<string, global::Courier.Models.Users.Tenants.Type>(),
            new ApiEnumConverter<string, Tokens::UserTokenProviderKey>(),
            new ApiEnumConverter<string, Tokens::Status>(),
            new ApiEnumConverter<string, Tokens::ProviderKey>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    internal static void Set<T>(IDictionary<string, JsonElement> dictionary, string key, T value)
    {
        dictionary[key] = JsonSerializer.SerializeToElement(value, SerializerOptions);
    }

    internal static T GetNotNullClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new CourierInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T>(element, SerializerOptions)
                ?? throw new CourierInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new CourierInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T GetNotNullStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new CourierInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions)
                ?? throw new CourierInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new CourierInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new CourierInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new CourierInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public virtual bool Equals(ModelBase? other)
    {
        if (other == null || this.RawData.Count != other.RawData.Count)
        {
            return false;
        }

        foreach (var item in this.RawData)
        {
            if (!other.RawData.TryGetValue(item.Key, out var otherValue))
            {
                return false;
            }

            if (!JsonElement.DeepEquals(item.Value, otherValue))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return 0;
    }

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
///
/// <para>NOTE: This interface is in the style of a factory instance instead of using
/// abstract static methods because .NET Standard 2.0 doesn't support abstract static methods.</para>
/// </summary>
interface IFromRaw<T>
{
    /// <summary>
    /// Returns an instance constructed from the given raw JSON properties.
    ///
    /// <para>Required field and type mismatches are not checked. In these cases accessing
    /// the relevant properties of the constructed instance may throw.</para>
    ///
    /// <para>This method is useful for constructing an instance from already serialized
    /// data or for sending arbitrary data to the API (e.g. for undocumented or not
    /// yet supported properties or values).</para>
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
