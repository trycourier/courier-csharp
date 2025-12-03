using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantListUsersResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TenantListUsersResponse
        {
            HasMore = true,
            Type = TenantListUsersResponseType.List,
            URL = "url",
            Cursor = "cursor",
            Items =
            [
                new()
                {
                    TenantID = "tenant_id",
                    Profile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Type.User,
                    UserID = "user_id",
                },
            ],
            NextURL = "next_url",
        };

        bool expectedHasMore = true;
        ApiEnum<string, TenantListUsersResponseType> expectedType =
            TenantListUsersResponseType.List;
        string expectedURL = "url";
        string expectedCursor = "cursor";
        List<TenantAssociation> expectedItems =
        [
            new()
            {
                TenantID = "tenant_id",
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Type = Type.User,
                UserID = "user_id",
            },
        ];
        string expectedNextURL = "next_url";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedCursor, model.Cursor);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextURL, model.NextURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TenantListUsersResponse
        {
            HasMore = true,
            Type = TenantListUsersResponseType.List,
            URL = "url",
            Cursor = "cursor",
            Items =
            [
                new()
                {
                    TenantID = "tenant_id",
                    Profile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Type.User,
                    UserID = "user_id",
                },
            ],
            NextURL = "next_url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TenantListUsersResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TenantListUsersResponse
        {
            HasMore = true,
            Type = TenantListUsersResponseType.List,
            URL = "url",
            Cursor = "cursor",
            Items =
            [
                new()
                {
                    TenantID = "tenant_id",
                    Profile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Type.User,
                    UserID = "user_id",
                },
            ],
            NextURL = "next_url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TenantListUsersResponse>(json);
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        ApiEnum<string, TenantListUsersResponseType> expectedType =
            TenantListUsersResponseType.List;
        string expectedURL = "url";
        string expectedCursor = "cursor";
        List<TenantAssociation> expectedItems =
        [
            new()
            {
                TenantID = "tenant_id",
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Type = Type.User,
                UserID = "user_id",
            },
        ];
        string expectedNextURL = "next_url";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedURL, deserialized.URL);
        Assert.Equal(expectedCursor, deserialized.Cursor);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextURL, deserialized.NextURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TenantListUsersResponse
        {
            HasMore = true,
            Type = TenantListUsersResponseType.List,
            URL = "url",
            Cursor = "cursor",
            Items =
            [
                new()
                {
                    TenantID = "tenant_id",
                    Profile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Type.User,
                    UserID = "user_id",
                },
            ],
            NextURL = "next_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TenantListUsersResponse
        {
            HasMore = true,
            Type = TenantListUsersResponseType.List,
            URL = "url",
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.NextURL);
        Assert.False(model.RawData.ContainsKey("next_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TenantListUsersResponse
        {
            HasMore = true,
            Type = TenantListUsersResponseType.List,
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TenantListUsersResponse
        {
            HasMore = true,
            Type = TenantListUsersResponseType.List,
            URL = "url",

            Cursor = null,
            Items = null,
            NextURL = null,
        };

        Assert.Null(model.Cursor);
        Assert.True(model.RawData.ContainsKey("cursor"));
        Assert.Null(model.Items);
        Assert.True(model.RawData.ContainsKey("items"));
        Assert.Null(model.NextURL);
        Assert.True(model.RawData.ContainsKey("next_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TenantListUsersResponse
        {
            HasMore = true,
            Type = TenantListUsersResponseType.List,
            URL = "url",

            Cursor = null,
            Items = null,
            NextURL = null,
        };

        model.Validate();
    }
}
