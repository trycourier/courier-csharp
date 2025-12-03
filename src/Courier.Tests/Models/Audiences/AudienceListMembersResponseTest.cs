using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceListMembersResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudienceListMembersResponse
        {
            Items =
            [
                new()
                {
                    AddedAt = "added_at",
                    AudienceID = "audience_id",
                    AudienceVersion = 0,
                    MemberID = "member_id",
                    Reason = "reason",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        List<Item> expectedItems =
        [
            new()
            {
                AddedAt = "added_at",
                AudienceID = "audience_id",
                AudienceVersion = 0,
                MemberID = "member_id",
                Reason = "reason",
            },
        ];
        Paging expectedPaging = new() { More = true, Cursor = "cursor" };

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPaging, model.Paging);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudienceListMembersResponse
        {
            Items =
            [
                new()
                {
                    AddedAt = "added_at",
                    AudienceID = "audience_id",
                    AudienceVersion = 0,
                    MemberID = "member_id",
                    Reason = "reason",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudienceListMembersResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudienceListMembersResponse
        {
            Items =
            [
                new()
                {
                    AddedAt = "added_at",
                    AudienceID = "audience_id",
                    AudienceVersion = 0,
                    MemberID = "member_id",
                    Reason = "reason",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudienceListMembersResponse>(json);
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                AddedAt = "added_at",
                AudienceID = "audience_id",
                AudienceVersion = 0,
                MemberID = "member_id",
                Reason = "reason",
            },
        ];
        Paging expectedPaging = new() { More = true, Cursor = "cursor" };

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedPaging, deserialized.Paging);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudienceListMembersResponse
        {
            Items =
            [
                new()
                {
                    AddedAt = "added_at",
                    AudienceID = "audience_id",
                    AudienceVersion = 0,
                    MemberID = "member_id",
                    Reason = "reason",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        model.Validate();
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            AddedAt = "added_at",
            AudienceID = "audience_id",
            AudienceVersion = 0,
            MemberID = "member_id",
            Reason = "reason",
        };

        string expectedAddedAt = "added_at";
        string expectedAudienceID = "audience_id";
        long expectedAudienceVersion = 0;
        string expectedMemberID = "member_id";
        string expectedReason = "reason";

        Assert.Equal(expectedAddedAt, model.AddedAt);
        Assert.Equal(expectedAudienceID, model.AudienceID);
        Assert.Equal(expectedAudienceVersion, model.AudienceVersion);
        Assert.Equal(expectedMemberID, model.MemberID);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            AddedAt = "added_at",
            AudienceID = "audience_id",
            AudienceVersion = 0,
            MemberID = "member_id",
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            AddedAt = "added_at",
            AudienceID = "audience_id",
            AudienceVersion = 0,
            MemberID = "member_id",
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);
        Assert.NotNull(deserialized);

        string expectedAddedAt = "added_at";
        string expectedAudienceID = "audience_id";
        long expectedAudienceVersion = 0;
        string expectedMemberID = "member_id";
        string expectedReason = "reason";

        Assert.Equal(expectedAddedAt, deserialized.AddedAt);
        Assert.Equal(expectedAudienceID, deserialized.AudienceID);
        Assert.Equal(expectedAudienceVersion, deserialized.AudienceVersion);
        Assert.Equal(expectedMemberID, deserialized.MemberID);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            AddedAt = "added_at",
            AudienceID = "audience_id",
            AudienceVersion = 0,
            MemberID = "member_id",
            Reason = "reason",
        };

        model.Validate();
    }
}
