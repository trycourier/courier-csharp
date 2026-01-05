using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class AudienceRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudienceRecipient
        {
            AudienceID = "audience_id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Filters =
            [
                new()
                {
                    Operator = Operator.MemberOf,
                    Path = Path.AccountID,
                    Value = "value",
                },
            ],
        };

        string expectedAudienceID = "audience_id";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<AudienceFilter> expectedFilters =
        [
            new()
            {
                Operator = Operator.MemberOf,
                Path = Path.AccountID,
                Value = "value",
            },
        ];

        Assert.Equal(expectedAudienceID, model.AudienceID);
        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.NotNull(model.Filters);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudienceRecipient
        {
            AudienceID = "audience_id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Filters =
            [
                new()
                {
                    Operator = Operator.MemberOf,
                    Path = Path.AccountID,
                    Value = "value",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudienceRecipient>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudienceRecipient
        {
            AudienceID = "audience_id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Filters =
            [
                new()
                {
                    Operator = Operator.MemberOf,
                    Path = Path.AccountID,
                    Value = "value",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudienceRecipient>(element);
        Assert.NotNull(deserialized);

        string expectedAudienceID = "audience_id";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<AudienceFilter> expectedFilters =
        [
            new()
            {
                Operator = Operator.MemberOf,
                Path = Path.AccountID,
                Value = "value",
            },
        ];

        Assert.Equal(expectedAudienceID, deserialized.AudienceID);
        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.NotNull(deserialized.Filters);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudienceRecipient
        {
            AudienceID = "audience_id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Filters =
            [
                new()
                {
                    Operator = Operator.MemberOf,
                    Path = Path.AccountID,
                    Value = "value",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AudienceRecipient { AudienceID = "audience_id" };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AudienceRecipient { AudienceID = "audience_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AudienceRecipient
        {
            AudienceID = "audience_id",

            Data = null,
            Filters = null,
        };

        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AudienceRecipient
        {
            AudienceID = "audience_id",

            Data = null,
            Filters = null,
        };

        model.Validate();
    }
}
