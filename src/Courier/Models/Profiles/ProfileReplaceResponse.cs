using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Profiles;

[JsonConverter(typeof(ModelConverter<ProfileReplaceResponse>))]
public sealed record class ProfileReplaceResponse : ModelBase, IFromRaw<ProfileReplaceResponse>
{
    public required ApiEnum<string, StatusModel> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, StatusModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Status.Validate();
    }

    public ProfileReplaceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileReplaceResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ProfileReplaceResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ProfileReplaceResponse(ApiEnum<string, StatusModel> status)
        : this()
    {
        this.Status = status;
    }
}

[JsonConverter(typeof(StatusModelConverter))]
public enum StatusModel
{
    Success,
}

sealed class StatusModelConverter : JsonConverter<StatusModel>
{
    public override StatusModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUCCESS" => StatusModel.Success,
            _ => (StatusModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatusModel.Success => "SUCCESS",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
