using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class UserProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfile
        {
            Address = new()
            {
                Country = "country",
                Formatted = "formatted",
                Locality = "locality",
                PostalCode = "postal_code",
                Region = "region",
                StreetAddress = "street_address",
            },
            Airship = new() { Audience = new("named_user"), DeviceTypes = ["string"] },
            Apn = "apn",
            Birthdate = "birthdate",
            Custom = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Discord = new SendToChannel("channel_id"),
            Email = "email",
            EmailVerified = true,
            Expo = new Token("token"),
            FacebookPsid = "facebookPSID",
            FamilyName = "family_name",
            FirebaseToken = "string",
            Gender = "gender",
            GivenName = "given_name",
            Intercom = new() { From = "from", To = new("id") },
            Locale = "locale",
            MiddleName = "middle_name",
            MsTeams = new SendToMsTeamsUserID()
            {
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
                UserID = "user_id",
            },
            Name = "name",
            Nickname = "nickname",
            PhoneNumber = "phone_number",
            PhoneNumberVerified = true,
            Picture = "picture",
            PreferredName = "preferred_name",
            Profile = "profile",
            Slack = new SendToSlackChannel() { AccessToken = "access_token", Channel = "channel" },
            Sub = "sub",
            TargetArn = "target_arn",
            UpdatedAt = "updated_at",
            Website = "website",
            Zoneinfo = "zoneinfo",
        };

        Address expectedAddress = new()
        {
            Country = "country",
            Formatted = "formatted",
            Locality = "locality",
            PostalCode = "postal_code",
            Region = "region",
            StreetAddress = "street_address",
        };
        AirshipProfile expectedAirship = new()
        {
            Audience = new("named_user"),
            DeviceTypes = ["string"],
        };
        string expectedApn = "apn";
        string expectedBirthdate = "birthdate";
        Dictionary<string, JsonElement> expectedCustom = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Discord expectedDiscord = new SendToChannel("channel_id");
        string expectedEmail = "email";
        bool expectedEmailVerified = true;
        Expo expectedExpo = new Token("token");
        string expectedFacebookPsid = "facebookPSID";
        string expectedFamilyName = "family_name";
        UserProfileFirebaseToken expectedFirebaseToken = "string";
        string expectedGender = "gender";
        string expectedGivenName = "given_name";
        Intercom expectedIntercom = new() { From = "from", To = new("id") };
        string expectedLocale = "locale";
        string expectedMiddleName = "middle_name";
        MsTeams expectedMsTeams = new SendToMsTeamsUserID()
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
            UserID = "user_id",
        };
        string expectedName = "name";
        string expectedNickname = "nickname";
        string expectedPhoneNumber = "phone_number";
        bool expectedPhoneNumberVerified = true;
        string expectedPicture = "picture";
        string expectedPreferredName = "preferred_name";
        string expectedProfile = "profile";
        Slack expectedSlack = new SendToSlackChannel()
        {
            AccessToken = "access_token",
            Channel = "channel",
        };
        string expectedSub = "sub";
        string expectedTargetArn = "target_arn";
        string expectedUpdatedAt = "updated_at";
        string expectedWebsite = "website";
        string expectedZoneinfo = "zoneinfo";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedAirship, model.Airship);
        Assert.Equal(expectedApn, model.Apn);
        Assert.Equal(expectedBirthdate, model.Birthdate);
        Assert.NotNull(model.Custom);
        Assert.Equal(expectedCustom.Count, model.Custom.Count);
        foreach (var item in expectedCustom)
        {
            Assert.True(model.Custom.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Custom[item.Key]));
        }
        Assert.Equal(expectedDiscord, model.Discord);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedEmailVerified, model.EmailVerified);
        Assert.Equal(expectedExpo, model.Expo);
        Assert.Equal(expectedFacebookPsid, model.FacebookPsid);
        Assert.Equal(expectedFamilyName, model.FamilyName);
        Assert.Equal(expectedFirebaseToken, model.FirebaseToken);
        Assert.Equal(expectedGender, model.Gender);
        Assert.Equal(expectedGivenName, model.GivenName);
        Assert.Equal(expectedIntercom, model.Intercom);
        Assert.Equal(expectedLocale, model.Locale);
        Assert.Equal(expectedMiddleName, model.MiddleName);
        Assert.Equal(expectedMsTeams, model.MsTeams);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNickname, model.Nickname);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPhoneNumberVerified, model.PhoneNumberVerified);
        Assert.Equal(expectedPicture, model.Picture);
        Assert.Equal(expectedPreferredName, model.PreferredName);
        Assert.Equal(expectedProfile, model.Profile);
        Assert.Equal(expectedSlack, model.Slack);
        Assert.Equal(expectedSub, model.Sub);
        Assert.Equal(expectedTargetArn, model.TargetArn);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWebsite, model.Website);
        Assert.Equal(expectedZoneinfo, model.Zoneinfo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfile
        {
            Address = new()
            {
                Country = "country",
                Formatted = "formatted",
                Locality = "locality",
                PostalCode = "postal_code",
                Region = "region",
                StreetAddress = "street_address",
            },
            Airship = new() { Audience = new("named_user"), DeviceTypes = ["string"] },
            Apn = "apn",
            Birthdate = "birthdate",
            Custom = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Discord = new SendToChannel("channel_id"),
            Email = "email",
            EmailVerified = true,
            Expo = new Token("token"),
            FacebookPsid = "facebookPSID",
            FamilyName = "family_name",
            FirebaseToken = "string",
            Gender = "gender",
            GivenName = "given_name",
            Intercom = new() { From = "from", To = new("id") },
            Locale = "locale",
            MiddleName = "middle_name",
            MsTeams = new SendToMsTeamsUserID()
            {
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
                UserID = "user_id",
            },
            Name = "name",
            Nickname = "nickname",
            PhoneNumber = "phone_number",
            PhoneNumberVerified = true,
            Picture = "picture",
            PreferredName = "preferred_name",
            Profile = "profile",
            Slack = new SendToSlackChannel() { AccessToken = "access_token", Channel = "channel" },
            Sub = "sub",
            TargetArn = "target_arn",
            UpdatedAt = "updated_at",
            Website = "website",
            Zoneinfo = "zoneinfo",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfile
        {
            Address = new()
            {
                Country = "country",
                Formatted = "formatted",
                Locality = "locality",
                PostalCode = "postal_code",
                Region = "region",
                StreetAddress = "street_address",
            },
            Airship = new() { Audience = new("named_user"), DeviceTypes = ["string"] },
            Apn = "apn",
            Birthdate = "birthdate",
            Custom = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Discord = new SendToChannel("channel_id"),
            Email = "email",
            EmailVerified = true,
            Expo = new Token("token"),
            FacebookPsid = "facebookPSID",
            FamilyName = "family_name",
            FirebaseToken = "string",
            Gender = "gender",
            GivenName = "given_name",
            Intercom = new() { From = "from", To = new("id") },
            Locale = "locale",
            MiddleName = "middle_name",
            MsTeams = new SendToMsTeamsUserID()
            {
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
                UserID = "user_id",
            },
            Name = "name",
            Nickname = "nickname",
            PhoneNumber = "phone_number",
            PhoneNumberVerified = true,
            Picture = "picture",
            PreferredName = "preferred_name",
            Profile = "profile",
            Slack = new SendToSlackChannel() { AccessToken = "access_token", Channel = "channel" },
            Sub = "sub",
            TargetArn = "target_arn",
            UpdatedAt = "updated_at",
            Website = "website",
            Zoneinfo = "zoneinfo",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Address expectedAddress = new()
        {
            Country = "country",
            Formatted = "formatted",
            Locality = "locality",
            PostalCode = "postal_code",
            Region = "region",
            StreetAddress = "street_address",
        };
        AirshipProfile expectedAirship = new()
        {
            Audience = new("named_user"),
            DeviceTypes = ["string"],
        };
        string expectedApn = "apn";
        string expectedBirthdate = "birthdate";
        Dictionary<string, JsonElement> expectedCustom = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Discord expectedDiscord = new SendToChannel("channel_id");
        string expectedEmail = "email";
        bool expectedEmailVerified = true;
        Expo expectedExpo = new Token("token");
        string expectedFacebookPsid = "facebookPSID";
        string expectedFamilyName = "family_name";
        UserProfileFirebaseToken expectedFirebaseToken = "string";
        string expectedGender = "gender";
        string expectedGivenName = "given_name";
        Intercom expectedIntercom = new() { From = "from", To = new("id") };
        string expectedLocale = "locale";
        string expectedMiddleName = "middle_name";
        MsTeams expectedMsTeams = new SendToMsTeamsUserID()
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
            UserID = "user_id",
        };
        string expectedName = "name";
        string expectedNickname = "nickname";
        string expectedPhoneNumber = "phone_number";
        bool expectedPhoneNumberVerified = true;
        string expectedPicture = "picture";
        string expectedPreferredName = "preferred_name";
        string expectedProfile = "profile";
        Slack expectedSlack = new SendToSlackChannel()
        {
            AccessToken = "access_token",
            Channel = "channel",
        };
        string expectedSub = "sub";
        string expectedTargetArn = "target_arn";
        string expectedUpdatedAt = "updated_at";
        string expectedWebsite = "website";
        string expectedZoneinfo = "zoneinfo";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedAirship, deserialized.Airship);
        Assert.Equal(expectedApn, deserialized.Apn);
        Assert.Equal(expectedBirthdate, deserialized.Birthdate);
        Assert.NotNull(deserialized.Custom);
        Assert.Equal(expectedCustom.Count, deserialized.Custom.Count);
        foreach (var item in expectedCustom)
        {
            Assert.True(deserialized.Custom.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Custom[item.Key]));
        }
        Assert.Equal(expectedDiscord, deserialized.Discord);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedEmailVerified, deserialized.EmailVerified);
        Assert.Equal(expectedExpo, deserialized.Expo);
        Assert.Equal(expectedFacebookPsid, deserialized.FacebookPsid);
        Assert.Equal(expectedFamilyName, deserialized.FamilyName);
        Assert.Equal(expectedFirebaseToken, deserialized.FirebaseToken);
        Assert.Equal(expectedGender, deserialized.Gender);
        Assert.Equal(expectedGivenName, deserialized.GivenName);
        Assert.Equal(expectedIntercom, deserialized.Intercom);
        Assert.Equal(expectedLocale, deserialized.Locale);
        Assert.Equal(expectedMiddleName, deserialized.MiddleName);
        Assert.Equal(expectedMsTeams, deserialized.MsTeams);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNickname, deserialized.Nickname);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPhoneNumberVerified, deserialized.PhoneNumberVerified);
        Assert.Equal(expectedPicture, deserialized.Picture);
        Assert.Equal(expectedPreferredName, deserialized.PreferredName);
        Assert.Equal(expectedProfile, deserialized.Profile);
        Assert.Equal(expectedSlack, deserialized.Slack);
        Assert.Equal(expectedSub, deserialized.Sub);
        Assert.Equal(expectedTargetArn, deserialized.TargetArn);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWebsite, deserialized.Website);
        Assert.Equal(expectedZoneinfo, deserialized.Zoneinfo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfile
        {
            Address = new()
            {
                Country = "country",
                Formatted = "formatted",
                Locality = "locality",
                PostalCode = "postal_code",
                Region = "region",
                StreetAddress = "street_address",
            },
            Airship = new() { Audience = new("named_user"), DeviceTypes = ["string"] },
            Apn = "apn",
            Birthdate = "birthdate",
            Custom = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Discord = new SendToChannel("channel_id"),
            Email = "email",
            EmailVerified = true,
            Expo = new Token("token"),
            FacebookPsid = "facebookPSID",
            FamilyName = "family_name",
            FirebaseToken = "string",
            Gender = "gender",
            GivenName = "given_name",
            Intercom = new() { From = "from", To = new("id") },
            Locale = "locale",
            MiddleName = "middle_name",
            MsTeams = new SendToMsTeamsUserID()
            {
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
                UserID = "user_id",
            },
            Name = "name",
            Nickname = "nickname",
            PhoneNumber = "phone_number",
            PhoneNumberVerified = true,
            Picture = "picture",
            PreferredName = "preferred_name",
            Profile = "profile",
            Slack = new SendToSlackChannel() { AccessToken = "access_token", Channel = "channel" },
            Sub = "sub",
            TargetArn = "target_arn",
            UpdatedAt = "updated_at",
            Website = "website",
            Zoneinfo = "zoneinfo",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserProfile { };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Airship);
        Assert.False(model.RawData.ContainsKey("airship"));
        Assert.Null(model.Apn);
        Assert.False(model.RawData.ContainsKey("apn"));
        Assert.Null(model.Birthdate);
        Assert.False(model.RawData.ContainsKey("birthdate"));
        Assert.Null(model.Custom);
        Assert.False(model.RawData.ContainsKey("custom"));
        Assert.Null(model.Discord);
        Assert.False(model.RawData.ContainsKey("discord"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.EmailVerified);
        Assert.False(model.RawData.ContainsKey("email_verified"));
        Assert.Null(model.Expo);
        Assert.False(model.RawData.ContainsKey("expo"));
        Assert.Null(model.FacebookPsid);
        Assert.False(model.RawData.ContainsKey("facebookPSID"));
        Assert.Null(model.FamilyName);
        Assert.False(model.RawData.ContainsKey("family_name"));
        Assert.Null(model.FirebaseToken);
        Assert.False(model.RawData.ContainsKey("firebaseToken"));
        Assert.Null(model.Gender);
        Assert.False(model.RawData.ContainsKey("gender"));
        Assert.Null(model.GivenName);
        Assert.False(model.RawData.ContainsKey("given_name"));
        Assert.Null(model.Intercom);
        Assert.False(model.RawData.ContainsKey("intercom"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.MiddleName);
        Assert.False(model.RawData.ContainsKey("middle_name"));
        Assert.Null(model.MsTeams);
        Assert.False(model.RawData.ContainsKey("ms_teams"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Nickname);
        Assert.False(model.RawData.ContainsKey("nickname"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.PhoneNumberVerified);
        Assert.False(model.RawData.ContainsKey("phone_number_verified"));
        Assert.Null(model.Picture);
        Assert.False(model.RawData.ContainsKey("picture"));
        Assert.Null(model.PreferredName);
        Assert.False(model.RawData.ContainsKey("preferred_name"));
        Assert.Null(model.Profile);
        Assert.False(model.RawData.ContainsKey("profile"));
        Assert.Null(model.Slack);
        Assert.False(model.RawData.ContainsKey("slack"));
        Assert.Null(model.Sub);
        Assert.False(model.RawData.ContainsKey("sub"));
        Assert.Null(model.TargetArn);
        Assert.False(model.RawData.ContainsKey("target_arn"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
        Assert.Null(model.Zoneinfo);
        Assert.False(model.RawData.ContainsKey("zoneinfo"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserProfile { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UserProfile
        {
            Address = null,
            Airship = null,
            Apn = null,
            Birthdate = null,
            Custom = null,
            Discord = null,
            Email = null,
            EmailVerified = null,
            Expo = null,
            FacebookPsid = null,
            FamilyName = null,
            FirebaseToken = null,
            Gender = null,
            GivenName = null,
            Intercom = null,
            Locale = null,
            MiddleName = null,
            MsTeams = null,
            Name = null,
            Nickname = null,
            PhoneNumber = null,
            PhoneNumberVerified = null,
            Picture = null,
            PreferredName = null,
            Profile = null,
            Slack = null,
            Sub = null,
            TargetArn = null,
            UpdatedAt = null,
            Website = null,
            Zoneinfo = null,
        };

        Assert.Null(model.Address);
        Assert.True(model.RawData.ContainsKey("address"));
        Assert.Null(model.Airship);
        Assert.True(model.RawData.ContainsKey("airship"));
        Assert.Null(model.Apn);
        Assert.True(model.RawData.ContainsKey("apn"));
        Assert.Null(model.Birthdate);
        Assert.True(model.RawData.ContainsKey("birthdate"));
        Assert.Null(model.Custom);
        Assert.True(model.RawData.ContainsKey("custom"));
        Assert.Null(model.Discord);
        Assert.True(model.RawData.ContainsKey("discord"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.EmailVerified);
        Assert.True(model.RawData.ContainsKey("email_verified"));
        Assert.Null(model.Expo);
        Assert.True(model.RawData.ContainsKey("expo"));
        Assert.Null(model.FacebookPsid);
        Assert.True(model.RawData.ContainsKey("facebookPSID"));
        Assert.Null(model.FamilyName);
        Assert.True(model.RawData.ContainsKey("family_name"));
        Assert.Null(model.FirebaseToken);
        Assert.True(model.RawData.ContainsKey("firebaseToken"));
        Assert.Null(model.Gender);
        Assert.True(model.RawData.ContainsKey("gender"));
        Assert.Null(model.GivenName);
        Assert.True(model.RawData.ContainsKey("given_name"));
        Assert.Null(model.Intercom);
        Assert.True(model.RawData.ContainsKey("intercom"));
        Assert.Null(model.Locale);
        Assert.True(model.RawData.ContainsKey("locale"));
        Assert.Null(model.MiddleName);
        Assert.True(model.RawData.ContainsKey("middle_name"));
        Assert.Null(model.MsTeams);
        Assert.True(model.RawData.ContainsKey("ms_teams"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Nickname);
        Assert.True(model.RawData.ContainsKey("nickname"));
        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.PhoneNumberVerified);
        Assert.True(model.RawData.ContainsKey("phone_number_verified"));
        Assert.Null(model.Picture);
        Assert.True(model.RawData.ContainsKey("picture"));
        Assert.Null(model.PreferredName);
        Assert.True(model.RawData.ContainsKey("preferred_name"));
        Assert.Null(model.Profile);
        Assert.True(model.RawData.ContainsKey("profile"));
        Assert.Null(model.Slack);
        Assert.True(model.RawData.ContainsKey("slack"));
        Assert.Null(model.Sub);
        Assert.True(model.RawData.ContainsKey("sub"));
        Assert.Null(model.TargetArn);
        Assert.True(model.RawData.ContainsKey("target_arn"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Website);
        Assert.True(model.RawData.ContainsKey("website"));
        Assert.Null(model.Zoneinfo);
        Assert.True(model.RawData.ContainsKey("zoneinfo"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserProfile
        {
            Address = null,
            Airship = null,
            Apn = null,
            Birthdate = null,
            Custom = null,
            Discord = null,
            Email = null,
            EmailVerified = null,
            Expo = null,
            FacebookPsid = null,
            FamilyName = null,
            FirebaseToken = null,
            Gender = null,
            GivenName = null,
            Intercom = null,
            Locale = null,
            MiddleName = null,
            MsTeams = null,
            Name = null,
            Nickname = null,
            PhoneNumber = null,
            PhoneNumberVerified = null,
            Picture = null,
            PreferredName = null,
            Profile = null,
            Slack = null,
            Sub = null,
            TargetArn = null,
            UpdatedAt = null,
            Website = null,
            Zoneinfo = null,
        };

        model.Validate();
    }
}

public class AddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Address
        {
            Country = "country",
            Formatted = "formatted",
            Locality = "locality",
            PostalCode = "postal_code",
            Region = "region",
            StreetAddress = "street_address",
        };

        string expectedCountry = "country";
        string expectedFormatted = "formatted";
        string expectedLocality = "locality";
        string expectedPostalCode = "postal_code";
        string expectedRegion = "region";
        string expectedStreetAddress = "street_address";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedFormatted, model.Formatted);
        Assert.Equal(expectedLocality, model.Locality);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedStreetAddress, model.StreetAddress);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Address
        {
            Country = "country",
            Formatted = "formatted",
            Locality = "locality",
            PostalCode = "postal_code",
            Region = "region",
            StreetAddress = "street_address",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Address
        {
            Country = "country",
            Formatted = "formatted",
            Locality = "locality",
            PostalCode = "postal_code",
            Region = "region",
            StreetAddress = "street_address",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountry = "country";
        string expectedFormatted = "formatted";
        string expectedLocality = "locality";
        string expectedPostalCode = "postal_code";
        string expectedRegion = "region";
        string expectedStreetAddress = "street_address";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedFormatted, deserialized.Formatted);
        Assert.Equal(expectedLocality, deserialized.Locality);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedStreetAddress, deserialized.StreetAddress);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Address
        {
            Country = "country",
            Formatted = "formatted",
            Locality = "locality",
            PostalCode = "postal_code",
            Region = "region",
            StreetAddress = "street_address",
        };

        model.Validate();
    }
}
