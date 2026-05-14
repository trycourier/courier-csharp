using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;
using Courier.Models.Journeys.Templates;

namespace Courier.Tests.Models.Journeys.Templates;

public class TemplateReplaceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateReplaceParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Notification = new()
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
                    Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                    Scope = TemplateReplaceParamsNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            State = "state",
        };

        string expectedTemplateID = "x";
        string expectedNotificationID = "x";
        TemplateReplaceParamsNotification expectedNotification = new()
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
                Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                Scope = TemplateReplaceParamsNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };
        string expectedState = "state";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedNotificationID, parameters.NotificationID);
        Assert.Equal(expectedNotification, parameters.Notification);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateReplaceParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Notification = new()
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
                    Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                    Scope = TemplateReplaceParamsNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateReplaceParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Notification = new()
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
                    Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                    Scope = TemplateReplaceParamsNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },

            // Null should be interpreted as omitted for these properties
            State = null,
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateReplaceParams parameters = new()
        {
            TemplateID = "x",
            NotificationID = "x",
            Notification = new()
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
                    Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                    Scope = TemplateReplaceParamsNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/x/templates/x"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateReplaceParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Notification = new()
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
                    Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                    Scope = TemplateReplaceParamsNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            State = "state",
        };

        TemplateReplaceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TemplateReplaceParamsNotificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateReplaceParamsNotification
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
                Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                Scope = TemplateReplaceParamsNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        TemplateReplaceParamsNotificationBrand expectedBrand = new("id");
        TemplateReplaceParamsNotificationContent expectedContent = new()
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
            Scope = TemplateReplaceParamsNotificationContentScope.Default,
        };
        string expectedName = "name";
        TemplateReplaceParamsNotificationSubscription expectedSubscription = new("topic_id");
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedBrand, model.Brand);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSubscription, model.Subscription);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateReplaceParamsNotification
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
                Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                Scope = TemplateReplaceParamsNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateReplaceParamsNotification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateReplaceParamsNotification
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
                Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                Scope = TemplateReplaceParamsNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateReplaceParamsNotification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TemplateReplaceParamsNotificationBrand expectedBrand = new("id");
        TemplateReplaceParamsNotificationContent expectedContent = new()
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
            Scope = TemplateReplaceParamsNotificationContentScope.Default,
        };
        string expectedName = "name";
        TemplateReplaceParamsNotificationSubscription expectedSubscription = new("topic_id");
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateReplaceParamsNotification
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
                Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                Scope = TemplateReplaceParamsNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateReplaceParamsNotification
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
                Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                Scope = TemplateReplaceParamsNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        TemplateReplaceParamsNotification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateReplaceParamsNotificationBrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateReplaceParamsNotificationBrand { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateReplaceParamsNotificationBrand { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateReplaceParamsNotificationBrand>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateReplaceParamsNotificationBrand { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateReplaceParamsNotificationBrand>(
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
        var model = new TemplateReplaceParamsNotificationBrand { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateReplaceParamsNotificationBrand { ID = "id" };

        TemplateReplaceParamsNotificationBrand copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateReplaceParamsNotificationContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateReplaceParamsNotificationContent
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
            Scope = TemplateReplaceParamsNotificationContentScope.Default,
        };

        List<ElementalNode> expectedElements =
        [
            new ElementalTextNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
            },
        ];
        ApiEnum<string, TemplateReplaceParamsNotificationContentVersion> expectedVersion =
            TemplateReplaceParamsNotificationContentVersion.V2022_01_01;
        ApiEnum<string, TemplateReplaceParamsNotificationContentScope> expectedScope =
            TemplateReplaceParamsNotificationContentScope.Default;

        Assert.Equal(expectedElements.Count, model.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], model.Elements[i]);
        }
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedScope, model.Scope);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateReplaceParamsNotificationContent
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
            Scope = TemplateReplaceParamsNotificationContentScope.Default,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateReplaceParamsNotificationContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateReplaceParamsNotificationContent
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
            Scope = TemplateReplaceParamsNotificationContentScope.Default,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateReplaceParamsNotificationContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ElementalNode> expectedElements =
        [
            new ElementalTextNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
            },
        ];
        ApiEnum<string, TemplateReplaceParamsNotificationContentVersion> expectedVersion =
            TemplateReplaceParamsNotificationContentVersion.V2022_01_01;
        ApiEnum<string, TemplateReplaceParamsNotificationContentScope> expectedScope =
            TemplateReplaceParamsNotificationContentScope.Default;

        Assert.Equal(expectedElements.Count, deserialized.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], deserialized.Elements[i]);
        }
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.Equal(expectedScope, deserialized.Scope);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateReplaceParamsNotificationContent
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
            Scope = TemplateReplaceParamsNotificationContentScope.Default,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateReplaceParamsNotificationContent
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateReplaceParamsNotificationContent
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateReplaceParamsNotificationContent
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,

            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateReplaceParamsNotificationContent
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,

            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateReplaceParamsNotificationContent
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
            Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
            Scope = TemplateReplaceParamsNotificationContentScope.Default,
        };

        TemplateReplaceParamsNotificationContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateReplaceParamsNotificationContentVersionTest : TestBase
{
    [Theory]
    [InlineData(TemplateReplaceParamsNotificationContentVersion.V2022_01_01)]
    public void Validation_Works(TemplateReplaceParamsNotificationContentVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TemplateReplaceParamsNotificationContentVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TemplateReplaceParamsNotificationContentVersion>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TemplateReplaceParamsNotificationContentVersion.V2022_01_01)]
    public void SerializationRoundtrip_Works(
        TemplateReplaceParamsNotificationContentVersion rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TemplateReplaceParamsNotificationContentVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TemplateReplaceParamsNotificationContentVersion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TemplateReplaceParamsNotificationContentVersion>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TemplateReplaceParamsNotificationContentVersion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TemplateReplaceParamsNotificationContentScopeTest : TestBase
{
    [Theory]
    [InlineData(TemplateReplaceParamsNotificationContentScope.Default)]
    [InlineData(TemplateReplaceParamsNotificationContentScope.Strict)]
    public void Validation_Works(TemplateReplaceParamsNotificationContentScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TemplateReplaceParamsNotificationContentScope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TemplateReplaceParamsNotificationContentScope>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TemplateReplaceParamsNotificationContentScope.Default)]
    [InlineData(TemplateReplaceParamsNotificationContentScope.Strict)]
    public void SerializationRoundtrip_Works(TemplateReplaceParamsNotificationContentScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TemplateReplaceParamsNotificationContentScope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TemplateReplaceParamsNotificationContentScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TemplateReplaceParamsNotificationContentScope>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TemplateReplaceParamsNotificationContentScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TemplateReplaceParamsNotificationSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateReplaceParamsNotificationSubscription { TopicID = "topic_id" };

        string expectedTopicID = "topic_id";

        Assert.Equal(expectedTopicID, model.TopicID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateReplaceParamsNotificationSubscription { TopicID = "topic_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TemplateReplaceParamsNotificationSubscription>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateReplaceParamsNotificationSubscription { TopicID = "topic_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TemplateReplaceParamsNotificationSubscription>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedTopicID = "topic_id";

        Assert.Equal(expectedTopicID, deserialized.TopicID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateReplaceParamsNotificationSubscription { TopicID = "topic_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateReplaceParamsNotificationSubscription { TopicID = "topic_id" };

        TemplateReplaceParamsNotificationSubscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
