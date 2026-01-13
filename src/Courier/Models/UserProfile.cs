using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<UserProfile, UserProfileFromRaw>))]
public sealed record class UserProfile : JsonModel
{
    public Address? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Address>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    public AirshipProfile? Airship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AirshipProfile>("airship");
        }
        init { this._rawData.Set("airship", value); }
    }

    public string? Apn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("apn");
        }
        init { this._rawData.Set("apn", value); }
    }

    public string? Birthdate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("birthdate");
        }
        init { this._rawData.Set("birthdate", value); }
    }

    /// <summary>
    /// A free form object. Due to a limitation of the API Explorer, you can only
    /// enter string key/values below, but this API accepts more complex object structures.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Custom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("custom");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "custom",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public Discord? Discord
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Discord>("discord");
        }
        init { this._rawData.Set("discord", value); }
    }

    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    public bool? EmailVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("email_verified");
        }
        init { this._rawData.Set("email_verified", value); }
    }

    public Expo? Expo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Expo>("expo");
        }
        init { this._rawData.Set("expo", value); }
    }

    public string? FacebookPsid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("facebookPSID");
        }
        init { this._rawData.Set("facebookPSID", value); }
    }

    public string? FamilyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("family_name");
        }
        init { this._rawData.Set("family_name", value); }
    }

    public UserProfileFirebaseToken? FirebaseToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserProfileFirebaseToken>("firebaseToken");
        }
        init { this._rawData.Set("firebaseToken", value); }
    }

    public string? Gender
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gender");
        }
        init { this._rawData.Set("gender", value); }
    }

    public string? GivenName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("given_name");
        }
        init { this._rawData.Set("given_name", value); }
    }

    public Intercom? Intercom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Intercom>("intercom");
        }
        init { this._rawData.Set("intercom", value); }
    }

    public string? Locale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locale");
        }
        init { this._rawData.Set("locale", value); }
    }

    public string? MiddleName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("middle_name");
        }
        init { this._rawData.Set("middle_name", value); }
    }

    public MsTeams? MsTeams
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MsTeams>("ms_teams");
        }
        init { this._rawData.Set("ms_teams", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Nickname
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nickname");
        }
        init { this._rawData.Set("nickname", value); }
    }

    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public bool? PhoneNumberVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("phone_number_verified");
        }
        init { this._rawData.Set("phone_number_verified", value); }
    }

    public string? Picture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("picture");
        }
        init { this._rawData.Set("picture", value); }
    }

    public string? PreferredName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("preferred_name");
        }
        init { this._rawData.Set("preferred_name", value); }
    }

    public string? Profile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profile");
        }
        init { this._rawData.Set("profile", value); }
    }

    public Slack? Slack
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Slack>("slack");
        }
        init { this._rawData.Set("slack", value); }
    }

    public string? Sub
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sub");
        }
        init { this._rawData.Set("sub", value); }
    }

    public string? TargetArn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("target_arn");
        }
        init { this._rawData.Set("target_arn", value); }
    }

    public string? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init { this._rawData.Set("website", value); }
    }

    public string? Zoneinfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("zoneinfo");
        }
        init { this._rawData.Set("zoneinfo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        this.Airship?.Validate();
        _ = this.Apn;
        _ = this.Birthdate;
        _ = this.Custom;
        this.Discord?.Validate();
        _ = this.Email;
        _ = this.EmailVerified;
        this.Expo?.Validate();
        _ = this.FacebookPsid;
        _ = this.FamilyName;
        this.FirebaseToken?.Validate();
        _ = this.Gender;
        _ = this.GivenName;
        this.Intercom?.Validate();
        _ = this.Locale;
        _ = this.MiddleName;
        this.MsTeams?.Validate();
        _ = this.Name;
        _ = this.Nickname;
        _ = this.PhoneNumber;
        _ = this.PhoneNumberVerified;
        _ = this.Picture;
        _ = this.PreferredName;
        _ = this.Profile;
        this.Slack?.Validate();
        _ = this.Sub;
        _ = this.TargetArn;
        _ = this.UpdatedAt;
        _ = this.Website;
        _ = this.Zoneinfo;
    }

    public UserProfile() { }

    public UserProfile(UserProfile userProfile)
        : base(userProfile) { }

    public UserProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileFromRaw.FromRawUnchecked"/>
    public static UserProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileFromRaw : IFromRawJson<UserProfile>
{
    /// <inheritdoc/>
    public UserProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserProfile.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    public required string Formatted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("formatted");
        }
        init { this._rawData.Set("formatted", value); }
    }

    public required string Locality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("locality");
        }
        init { this._rawData.Set("locality", value); }
    }

    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    public required string Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    public required string StreetAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("street_address");
        }
        init { this._rawData.Set("street_address", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.Formatted;
        _ = this.Locality;
        _ = this.PostalCode;
        _ = this.Region;
        _ = this.StreetAddress;
    }

    public Address() { }

    public Address(Address address)
        : base(address) { }

    public Address(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}
