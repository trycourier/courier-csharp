using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Profiles;

[JsonConverter(typeof(JsonModelConverter<ProfileReplaceResponse, ProfileReplaceResponseFromRaw>))]
public sealed record class ProfileReplaceResponse : JsonModel
{
    public required ApiEnum<string, ProfileReplaceResponseStatus> Status
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, ProfileReplaceResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
    }

    public ProfileReplaceResponse() { }

    public ProfileReplaceResponse(ProfileReplaceResponse profileReplaceResponse)
        : base(profileReplaceResponse) { }

    public ProfileReplaceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileReplaceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileReplaceResponseFromRaw.FromRawUnchecked"/>
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

class ProfileReplaceResponseFromRaw : IFromRawJson<ProfileReplaceResponse>
{
    /// <inheritdoc/>
    public ProfileReplaceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileReplaceResponse.FromRawUnchecked(rawData);
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
