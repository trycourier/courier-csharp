using System.Text.Json;
using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class SubscriptionListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionList
        {
            ID = "id",
            Name = "name",
            Created = "created",
            Updated = "updated",
        };

        string expectedID = "id";
        string expectedName = "name";
        string expectedCreated = "created";
        string expectedUpdated = "updated";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedUpdated, model.Updated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionList
        {
            ID = "id",
            Name = "name",
            Created = "created",
            Updated = "updated",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionList>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionList
        {
            ID = "id",
            Name = "name",
            Created = "created",
            Updated = "updated",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionList>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        string expectedCreated = "created";
        string expectedUpdated = "updated";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedUpdated, deserialized.Updated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionList
        {
            ID = "id",
            Name = "name",
            Created = "created",
            Updated = "updated",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionList { ID = "id", Name = "name" };

        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionList { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionList
        {
            ID = "id",
            Name = "name",

            Created = null,
            Updated = null,
        };

        Assert.Null(model.Created);
        Assert.True(model.RawData.ContainsKey("created"));
        Assert.Null(model.Updated);
        Assert.True(model.RawData.ContainsKey("updated"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionList
        {
            ID = "id",
            Name = "name",

            Created = null,
            Updated = null,
        };

        model.Validate();
    }
}
