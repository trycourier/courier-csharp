using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Tenants;
using Models = Courier.Models;

namespace Courier.Tests.Models.Tenants;

public class DefaultPreferencesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DefaultPreferences
        {
            Items =
            [
                new()
                {
                    Status = Status.OptedOut,
                    CustomRouting = [Models::ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    ID = "id",
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
            {
                Status = Status.OptedOut,
                CustomRouting = [Models::ChannelClassification.DirectMessage],
                HasCustomRouting = true,
                ID = "id",
            },
        ];

        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DefaultPreferences
        {
            Items =
            [
                new()
                {
                    Status = Status.OptedOut,
                    CustomRouting = [Models::ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    ID = "id",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultPreferences>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DefaultPreferences
        {
            Items =
            [
                new()
                {
                    Status = Status.OptedOut,
                    CustomRouting = [Models::ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    ID = "id",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultPreferences>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                Status = Status.OptedOut,
                CustomRouting = [Models::ChannelClassification.DirectMessage],
                HasCustomRouting = true,
                ID = "id",
            },
        ];

        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DefaultPreferences
        {
            Items =
            [
                new()
                {
                    Status = Status.OptedOut,
                    CustomRouting = [Models::ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    ID = "id",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DefaultPreferences { };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DefaultPreferences { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DefaultPreferences { Items = null };

        Assert.Null(model.Items);
        Assert.True(model.RawData.ContainsKey("items"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DefaultPreferences { Items = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DefaultPreferences
        {
            Items =
            [
                new()
                {
                    Status = Status.OptedOut,
                    CustomRouting = [Models::ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    ID = "id",
                },
            ],
        };

        DefaultPreferences copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            Status = Status.OptedOut,
            CustomRouting = [Models::ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            ID = "id",
        };

        ApiEnum<string, Status> expectedStatus = Status.OptedOut;
        List<ApiEnum<string, Models::ChannelClassification>> expectedCustomRouting =
        [
            Models::ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;
        string expectedID = "id";

        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.CustomRouting);
        Assert.Equal(expectedCustomRouting.Count, model.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], model.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            Status = Status.OptedOut,
            CustomRouting = [Models::ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            ID = "id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            Status = Status.OptedOut,
            CustomRouting = [Models::ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            ID = "id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.OptedOut;
        List<ApiEnum<string, Models::ChannelClassification>> expectedCustomRouting =
        [
            Models::ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;
        string expectedID = "id";

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.CustomRouting);
        Assert.Equal(expectedCustomRouting.Count, deserialized.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], deserialized.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, deserialized.HasCustomRouting);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            Status = Status.OptedOut,
            CustomRouting = [Models::ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            ID = "id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item { Status = Status.OptedOut, ID = "id" };

        Assert.Null(model.CustomRouting);
        Assert.False(model.RawData.ContainsKey("custom_routing"));
        Assert.Null(model.HasCustomRouting);
        Assert.False(model.RawData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item { Status = Status.OptedOut, ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
        {
            Status = Status.OptedOut,
            ID = "id",

            CustomRouting = null,
            HasCustomRouting = null,
        };

        Assert.Null(model.CustomRouting);
        Assert.True(model.RawData.ContainsKey("custom_routing"));
        Assert.Null(model.HasCustomRouting);
        Assert.True(model.RawData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            Status = Status.OptedOut,
            ID = "id",

            CustomRouting = null,
            HasCustomRouting = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
        {
            Status = Status.OptedOut,
            CustomRouting = [Models::ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            ID = "id",
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1 { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1 { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1 { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1 { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntersectionMember1 { ID = "id" };

        IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
