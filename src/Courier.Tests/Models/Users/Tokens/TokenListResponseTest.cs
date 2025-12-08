using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Users.Tokens;

namespace Courier.Tests.Models.Users.Tokens;

public class TokenListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TokenListResponse
        {
            Tokens =
            [
                new()
                {
                    Token = "token",
                    ProviderKey = UserTokenProviderKey.FirebaseFcm,
                    Device = new()
                    {
                        AdID = "ad_id",
                        AppID = "app_id",
                        DeviceID = "device_id",
                        Manufacturer = "manufacturer",
                        Model = "model",
                        Platform = "platform",
                    },
                    ExpiryDate = "string",
                    Properties = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Tracking = new()
                    {
                        IP = "ip",
                        Lat = "lat",
                        Long = "long",
                        OsVersion = "os_version",
                    },
                },
            ],
        };

        List<UserToken> expectedTokens =
        [
            new()
            {
                Token = "token",
                ProviderKey = UserTokenProviderKey.FirebaseFcm,
                Device = new()
                {
                    AdID = "ad_id",
                    AppID = "app_id",
                    DeviceID = "device_id",
                    Manufacturer = "manufacturer",
                    Model = "model",
                    Platform = "platform",
                },
                ExpiryDate = "string",
                Properties = JsonSerializer.Deserialize<JsonElement>("{}"),
                Tracking = new()
                {
                    IP = "ip",
                    Lat = "lat",
                    Long = "long",
                    OsVersion = "os_version",
                },
            },
        ];

        Assert.Equal(expectedTokens.Count, model.Tokens.Count);
        for (int i = 0; i < expectedTokens.Count; i++)
        {
            Assert.Equal(expectedTokens[i], model.Tokens[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TokenListResponse
        {
            Tokens =
            [
                new()
                {
                    Token = "token",
                    ProviderKey = UserTokenProviderKey.FirebaseFcm,
                    Device = new()
                    {
                        AdID = "ad_id",
                        AppID = "app_id",
                        DeviceID = "device_id",
                        Manufacturer = "manufacturer",
                        Model = "model",
                        Platform = "platform",
                    },
                    ExpiryDate = "string",
                    Properties = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Tracking = new()
                    {
                        IP = "ip",
                        Lat = "lat",
                        Long = "long",
                        OsVersion = "os_version",
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TokenListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TokenListResponse
        {
            Tokens =
            [
                new()
                {
                    Token = "token",
                    ProviderKey = UserTokenProviderKey.FirebaseFcm,
                    Device = new()
                    {
                        AdID = "ad_id",
                        AppID = "app_id",
                        DeviceID = "device_id",
                        Manufacturer = "manufacturer",
                        Model = "model",
                        Platform = "platform",
                    },
                    ExpiryDate = "string",
                    Properties = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Tracking = new()
                    {
                        IP = "ip",
                        Lat = "lat",
                        Long = "long",
                        OsVersion = "os_version",
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TokenListResponse>(json);
        Assert.NotNull(deserialized);

        List<UserToken> expectedTokens =
        [
            new()
            {
                Token = "token",
                ProviderKey = UserTokenProviderKey.FirebaseFcm,
                Device = new()
                {
                    AdID = "ad_id",
                    AppID = "app_id",
                    DeviceID = "device_id",
                    Manufacturer = "manufacturer",
                    Model = "model",
                    Platform = "platform",
                },
                ExpiryDate = "string",
                Properties = JsonSerializer.Deserialize<JsonElement>("{}"),
                Tracking = new()
                {
                    IP = "ip",
                    Lat = "lat",
                    Long = "long",
                    OsVersion = "os_version",
                },
            },
        ];

        Assert.Equal(expectedTokens.Count, deserialized.Tokens.Count);
        for (int i = 0; i < expectedTokens.Count; i++)
        {
            Assert.Equal(expectedTokens[i], deserialized.Tokens[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TokenListResponse
        {
            Tokens =
            [
                new()
                {
                    Token = "token",
                    ProviderKey = UserTokenProviderKey.FirebaseFcm,
                    Device = new()
                    {
                        AdID = "ad_id",
                        AppID = "app_id",
                        DeviceID = "device_id",
                        Manufacturer = "manufacturer",
                        Model = "model",
                        Platform = "platform",
                    },
                    ExpiryDate = "string",
                    Properties = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Tracking = new()
                    {
                        IP = "ip",
                        Lat = "lat",
                        Long = "long",
                        OsVersion = "os_version",
                    },
                },
            ],
        };

        model.Validate();
    }
}
