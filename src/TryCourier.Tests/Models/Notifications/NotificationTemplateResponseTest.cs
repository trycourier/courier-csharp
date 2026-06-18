using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationTemplateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationTemplateResponse
        {
            Brand = new("id"),
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
            Updated = 0,
            Updater = "updater",
        };

        Brand expectedBrand = new("id");
        ElementalContent expectedContent = new()
        {
            Elements =
            [
                new ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Version = "version",
        };
        string expectedName = "name";
        Routing expectedRouting = new("strategy_id");
        Subscription expectedSubscription = new("topic_id");
        List<string> expectedTags = ["string"];
        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        ApiEnum<string, NotificationTemplateResponseIntersectionMember1State> expectedState =
            NotificationTemplateResponseIntersectionMember1State.Draft;
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedBrand, model.Brand);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRouting, model.Routing);
        Assert.Equal(expectedSubscription, model.Subscription);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedUpdater, model.Updater);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationTemplateResponse
        {
            Brand = new("id"),
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
            Updated = 0,
            Updater = "updater",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationTemplateResponse
        {
            Brand = new("id"),
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
            Updated = 0,
            Updater = "updater",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Brand expectedBrand = new("id");
        ElementalContent expectedContent = new()
        {
            Elements =
            [
                new ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Version = "version",
        };
        string expectedName = "name";
        Routing expectedRouting = new("strategy_id");
        Subscription expectedSubscription = new("topic_id");
        List<string> expectedTags = ["string"];
        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        ApiEnum<string, NotificationTemplateResponseIntersectionMember1State> expectedState =
            NotificationTemplateResponseIntersectionMember1State.Draft;
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRouting, deserialized.Routing);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedUpdater, deserialized.Updater);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationTemplateResponse
        {
            Brand = new("id"),
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
            Updated = 0,
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotificationTemplateResponse
        {
            Brand = new("id"),
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
        };

        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotificationTemplateResponse
        {
            Brand = new("id"),
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotificationTemplateResponse
        {
            Brand = new("id"),
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,

            // Null should be interpreted as omitted for these properties
            Updated = null,
            Updater = null,
        };

        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotificationTemplateResponse
        {
            Brand = new("id"),
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,

            // Null should be interpreted as omitted for these properties
            Updated = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationTemplateResponse
        {
            Brand = new("id"),
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
            Updated = 0,
            Updater = "updater",
        };

        NotificationTemplateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTemplateResponseIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationTemplateResponseIntersectionMember1
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
            Updated = 0,
            Updater = "updater",
        };

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        ApiEnum<string, NotificationTemplateResponseIntersectionMember1State> expectedState =
            NotificationTemplateResponseIntersectionMember1State.Draft;
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedUpdater, model.Updater);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationTemplateResponseIntersectionMember1
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
            Updated = 0,
            Updater = "updater",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NotificationTemplateResponseIntersectionMember1>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationTemplateResponseIntersectionMember1
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
            Updated = 0,
            Updater = "updater",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NotificationTemplateResponseIntersectionMember1>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        ApiEnum<string, NotificationTemplateResponseIntersectionMember1State> expectedState =
            NotificationTemplateResponseIntersectionMember1State.Draft;
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedUpdater, deserialized.Updater);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationTemplateResponseIntersectionMember1
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
            Updated = 0,
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotificationTemplateResponseIntersectionMember1
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
        };

        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotificationTemplateResponseIntersectionMember1
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotificationTemplateResponseIntersectionMember1
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,

            // Null should be interpreted as omitted for these properties
            Updated = null,
            Updater = null,
        };

        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotificationTemplateResponseIntersectionMember1
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,

            // Null should be interpreted as omitted for these properties
            Updated = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationTemplateResponseIntersectionMember1
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = NotificationTemplateResponseIntersectionMember1State.Draft,
            Updated = 0,
            Updater = "updater",
        };

        NotificationTemplateResponseIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTemplateResponseIntersectionMember1StateTest : TestBase
{
    [Theory]
    [InlineData(NotificationTemplateResponseIntersectionMember1State.Draft)]
    [InlineData(NotificationTemplateResponseIntersectionMember1State.Published)]
    public void Validation_Works(NotificationTemplateResponseIntersectionMember1State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationTemplateResponseIntersectionMember1State> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationTemplateResponseIntersectionMember1State>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NotificationTemplateResponseIntersectionMember1State.Draft)]
    [InlineData(NotificationTemplateResponseIntersectionMember1State.Published)]
    public void SerializationRoundtrip_Works(
        NotificationTemplateResponseIntersectionMember1State rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationTemplateResponseIntersectionMember1State> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationTemplateResponseIntersectionMember1State>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationTemplateResponseIntersectionMember1State>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationTemplateResponseIntersectionMember1State>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
