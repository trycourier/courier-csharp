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
        get { return JsonModel.GetNullableClass<Address>(this.RawData, "address"); }
        init { JsonModel.Set(this._rawData, "address", value); }
    }

    public AirshipProfile? Airship
    {
        get { return JsonModel.GetNullableClass<AirshipProfile>(this.RawData, "airship"); }
        init { JsonModel.Set(this._rawData, "airship", value); }
    }

    public string? Apn
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "apn"); }
        init { JsonModel.Set(this._rawData, "apn", value); }
    }

    public string? Birthdate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "birthdate"); }
        init { JsonModel.Set(this._rawData, "birthdate", value); }
    }

    /// <summary>
    /// A free form object. Due to a limitation of the API Explorer, you can only
    /// enter string key/values below, but this API accepts more complex object structures.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Custom
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "custom"
            );
        }
        init { JsonModel.Set(this._rawData, "custom", value); }
    }

    public Discord? Discord
    {
        get { return JsonModel.GetNullableClass<Discord>(this.RawData, "discord"); }
        init { JsonModel.Set(this._rawData, "discord", value); }
    }

    public string? Email
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "email"); }
        init { JsonModel.Set(this._rawData, "email", value); }
    }

    public bool? EmailVerified
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "email_verified"); }
        init { JsonModel.Set(this._rawData, "email_verified", value); }
    }

    public Expo? Expo
    {
        get { return JsonModel.GetNullableClass<Expo>(this.RawData, "expo"); }
        init { JsonModel.Set(this._rawData, "expo", value); }
    }

    public string? FacebookPsid
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "facebookPSID"); }
        init { JsonModel.Set(this._rawData, "facebookPSID", value); }
    }

    public string? FamilyName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "family_name"); }
        init { JsonModel.Set(this._rawData, "family_name", value); }
    }

    public UserProfileFirebaseToken? FirebaseToken
    {
        get
        {
            return JsonModel.GetNullableClass<UserProfileFirebaseToken>(
                this.RawData,
                "firebaseToken"
            );
        }
        init { JsonModel.Set(this._rawData, "firebaseToken", value); }
    }

    public string? Gender
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "gender"); }
        init { JsonModel.Set(this._rawData, "gender", value); }
    }

    public string? GivenName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "given_name"); }
        init { JsonModel.Set(this._rawData, "given_name", value); }
    }

    public Intercom? Intercom
    {
        get { return JsonModel.GetNullableClass<Intercom>(this.RawData, "intercom"); }
        init { JsonModel.Set(this._rawData, "intercom", value); }
    }

    public string? Locale
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "locale"); }
        init { JsonModel.Set(this._rawData, "locale", value); }
    }

    public string? MiddleName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "middle_name"); }
        init { JsonModel.Set(this._rawData, "middle_name", value); }
    }

    public MsTeams? MsTeams
    {
        get { return JsonModel.GetNullableClass<MsTeams>(this.RawData, "ms_teams"); }
        init { JsonModel.Set(this._rawData, "ms_teams", value); }
    }

    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    public string? Nickname
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "nickname"); }
        init { JsonModel.Set(this._rawData, "nickname", value); }
    }

    public string? PhoneNumber
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "phone_number"); }
        init { JsonModel.Set(this._rawData, "phone_number", value); }
    }

    public bool? PhoneNumberVerified
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "phone_number_verified"); }
        init { JsonModel.Set(this._rawData, "phone_number_verified", value); }
    }

    public string? Picture
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "picture"); }
        init { JsonModel.Set(this._rawData, "picture", value); }
    }

    public string? PreferredName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "preferred_name"); }
        init { JsonModel.Set(this._rawData, "preferred_name", value); }
    }

    public string? Profile
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "profile"); }
        init { JsonModel.Set(this._rawData, "profile", value); }
    }

    public Slack? Slack
    {
        get { return JsonModel.GetNullableClass<Slack>(this.RawData, "slack"); }
        init { JsonModel.Set(this._rawData, "slack", value); }
    }

    public string? Sub
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "sub"); }
        init { JsonModel.Set(this._rawData, "sub", value); }
    }

    public string? TargetArn
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "target_arn"); }
        init { JsonModel.Set(this._rawData, "target_arn", value); }
    }

    public string? UpdatedAt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "updated_at"); }
        init { JsonModel.Set(this._rawData, "updated_at", value); }
    }

    public string? Website
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "website"); }
        init { JsonModel.Set(this._rawData, "website", value); }
    }

    public string? Zoneinfo
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "zoneinfo"); }
        init { JsonModel.Set(this._rawData, "zoneinfo", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "country"); }
        init { JsonModel.Set(this._rawData, "country", value); }
    }

    public required string Formatted
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "formatted"); }
        init { JsonModel.Set(this._rawData, "formatted", value); }
    }

    public required string Locality
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "locality"); }
        init { JsonModel.Set(this._rawData, "locality", value); }
    }

    public required string PostalCode
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "postal_code"); }
        init { JsonModel.Set(this._rawData, "postal_code", value); }
    }

    public required string Region
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "region"); }
        init { JsonModel.Set(this._rawData, "region", value); }
    }

    public required string StreetAddress
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "street_address"); }
        init { JsonModel.Set(this._rawData, "street_address", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
