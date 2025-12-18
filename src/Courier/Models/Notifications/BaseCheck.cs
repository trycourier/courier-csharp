using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Notifications;

[JsonConverter(typeof(JsonModelConverter<BaseCheck, BaseCheckFromRaw>))]
public sealed record class BaseCheck : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, Status> Status
    {
        get { return JsonModel.GetNotNullClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    public required ApiEnum<string, global::Courier.Models.Notifications.Type> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Notifications.Type>
            >(this.RawData, "type");
        }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Status.Validate();
        this.Type.Validate();
    }

    public BaseCheck() { }

    public BaseCheck(BaseCheck baseCheck)
        : base(baseCheck) { }

    public BaseCheck(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BaseCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BaseCheckFromRaw.FromRawUnchecked"/>
    public static BaseCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BaseCheckFromRaw : IFromRawJson<BaseCheck>
{
    /// <inheritdoc/>
    public BaseCheck FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BaseCheck.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Resolved,
    Failed,
    Pending,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RESOLVED" => Status.Resolved,
            "FAILED" => Status.Failed,
            "PENDING" => Status.Pending,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Resolved => "RESOLVED",
                Status.Failed => "FAILED",
                Status.Pending => "PENDING",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::Courier.Models.Notifications.TypeConverter))]
public enum Type
{
    Custom,
}

sealed class TypeConverter : JsonConverter<global::Courier.Models.Notifications.Type>
{
    public override global::Courier.Models.Notifications.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => global::Courier.Models.Notifications.Type.Custom,
            _ => (global::Courier.Models.Notifications.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Notifications.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Notifications.Type.Custom => "custom",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
