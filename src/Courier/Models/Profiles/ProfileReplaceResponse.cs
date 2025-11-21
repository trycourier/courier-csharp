using System.Collections.Frozen;
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
    public required ApiEnum<string, ProfileReplaceResponseStatus> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ProfileReplaceResponseStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
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

    public ProfileReplaceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileReplaceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ProfileReplaceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProfileReplaceResponse(ApiEnum<string, ProfileReplaceResponseStatus> status)
        : this()
    {
        this.Status = status;
    }
}

[JsonConverter(typeof(ProfileReplaceResponseStatusConverter))]
public enum ProfileReplaceResponseStatus
{
    Success,
}

sealed class ProfileReplaceResponseStatusConverter : JsonConverter<ProfileReplaceResponseStatus>
{
    public override ProfileReplaceResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUCCESS" => ProfileReplaceResponseStatus.Success,
            _ => (ProfileReplaceResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileReplaceResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileReplaceResponseStatus.Success => "SUCCESS",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
