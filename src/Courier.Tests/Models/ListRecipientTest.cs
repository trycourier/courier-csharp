using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class ListRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListRecipient
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Filters =
            [
                new()
                {
                    Operator = ListFilterOperator.MemberOf,
                    Path = ListFilterPath.AccountID,
                    Value = "value",
                },
            ],
            ListID = "list_id",
        };

        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<ListFilter> expectedFilters =
        [
            new()
            {
                Operator = ListFilterOperator.MemberOf,
                Path = ListFilterPath.AccountID,
                Value = "value",
            },
        ];
        string expectedListID = "list_id";

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
        Assert.Equal(expectedListID, model.ListID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ListRecipient
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Filters =
            [
                new()
                {
                    Operator = ListFilterOperator.MemberOf,
                    Path = ListFilterPath.AccountID,
                    Value = "value",
                },
            ],
            ListID = "list_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListRecipient>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListRecipient
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Filters =
            [
                new()
                {
                    Operator = ListFilterOperator.MemberOf,
                    Path = ListFilterPath.AccountID,
                    Value = "value",
                },
            ],
            ListID = "list_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ListRecipient>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<ListFilter> expectedFilters =
        [
            new()
            {
                Operator = ListFilterOperator.MemberOf,
                Path = ListFilterPath.AccountID,
                Value = "value",
            },
        ];
        string expectedListID = "list_id";

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
        Assert.Equal(expectedListID, deserialized.ListID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ListRecipient
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Filters =
            [
                new()
                {
                    Operator = ListFilterOperator.MemberOf,
                    Path = ListFilterPath.AccountID,
                    Value = "value",
                },
            ],
            ListID = "list_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ListRecipient { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.ListID);
        Assert.False(model.RawData.ContainsKey("list_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ListRecipient { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ListRecipient
        {
            Data = null,
            Filters = null,
            ListID = null,
        };

        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.ListID);
        Assert.True(model.RawData.ContainsKey("list_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ListRecipient
        {
            Data = null,
            Filters = null,
            ListID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ListRecipient
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Filters =
            [
                new()
                {
                    Operator = ListFilterOperator.MemberOf,
                    Path = ListFilterPath.AccountID,
                    Value = "value",
                },
            ],
            ListID = "list_id",
        };

        ListRecipient copied = new(model);

        Assert.Equal(model, copied);
    }
}
