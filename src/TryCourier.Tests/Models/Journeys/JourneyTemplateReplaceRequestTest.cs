using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyTemplateReplaceRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyTemplateReplaceRequest
        {
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
                    Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                    Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            State = "state",
        };

        JourneyTemplateReplaceRequestNotification expectedNotification = new()
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
                Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };
        string expectedState = "state";

        Assert.Equal(expectedNotification, model.Notification);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyTemplateReplaceRequest
        {
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
                    Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                    Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyTemplateReplaceRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyTemplateReplaceRequest
        {
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
                    Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                    Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyTemplateReplaceRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JourneyTemplateReplaceRequestNotification expectedNotification = new()
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
                Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };
        string expectedState = "state";

        Assert.Equal(expectedNotification, deserialized.Notification);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyTemplateReplaceRequest
        {
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
                    Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                    Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyTemplateReplaceRequest
        {
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
                    Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                    Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
        };

        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyTemplateReplaceRequest
        {
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
                    Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                    Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyTemplateReplaceRequest
        {
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
                    Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                    Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },

            // Null should be interpreted as omitted for these properties
            State = null,
        };

        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyTemplateReplaceRequest
        {
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
                    Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                    Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },

            // Null should be interpreted as omitted for these properties
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyTemplateReplaceRequest
        {
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
                    Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                    Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            State = "state",
        };

        JourneyTemplateReplaceRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyTemplateReplaceRequestNotificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotification
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
                Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        JourneyTemplateReplaceRequestNotificationBrand expectedBrand = new("id");
        JourneyTemplateReplaceRequestNotificationContent expectedContent = new()
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
            Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
        };
        string expectedName = "name";
        JourneyTemplateReplaceRequestNotificationSubscription expectedSubscription = new(
            "topic_id"
        );
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
        var model = new JourneyTemplateReplaceRequestNotification
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
                Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyTemplateReplaceRequestNotification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotification
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
                Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyTemplateReplaceRequestNotification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JourneyTemplateReplaceRequestNotificationBrand expectedBrand = new("id");
        JourneyTemplateReplaceRequestNotificationContent expectedContent = new()
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
            Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
        };
        string expectedName = "name";
        JourneyTemplateReplaceRequestNotificationSubscription expectedSubscription = new(
            "topic_id"
        );
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
        var model = new JourneyTemplateReplaceRequestNotification
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
                Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
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
        var model = new JourneyTemplateReplaceRequestNotification
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
                Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
                Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        JourneyTemplateReplaceRequestNotification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyTemplateReplaceRequestNotificationBrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationBrand { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationBrand { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<JourneyTemplateReplaceRequestNotificationBrand>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationBrand { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<JourneyTemplateReplaceRequestNotificationBrand>(
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
        var model = new JourneyTemplateReplaceRequestNotificationBrand { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationBrand { ID = "id" };

        JourneyTemplateReplaceRequestNotificationBrand copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyTemplateReplaceRequestNotificationContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationContent
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
            Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
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
        ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentVersion> expectedVersion =
            JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01;
        ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentScope> expectedScope =
            JourneyTemplateReplaceRequestNotificationContentScope.Default;

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
        var model = new JourneyTemplateReplaceRequestNotificationContent
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
            Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<JourneyTemplateReplaceRequestNotificationContent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationContent
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
            Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<JourneyTemplateReplaceRequestNotificationContent>(
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
        ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentVersion> expectedVersion =
            JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01;
        ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentScope> expectedScope =
            JourneyTemplateReplaceRequestNotificationContentScope.Default;

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
        var model = new JourneyTemplateReplaceRequestNotificationContent
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
            Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationContent
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationContent
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationContent
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,

            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationContent
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,

            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationContent
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
            Version = JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01,
            Scope = JourneyTemplateReplaceRequestNotificationContentScope.Default,
        };

        JourneyTemplateReplaceRequestNotificationContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyTemplateReplaceRequestNotificationContentVersionTest : TestBase
{
    [Theory]
    [InlineData(JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01)]
    public void Validation_Works(JourneyTemplateReplaceRequestNotificationContentVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentVersion>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyTemplateReplaceRequestNotificationContentVersion.V2022_01_01)]
    public void SerializationRoundtrip_Works(
        JourneyTemplateReplaceRequestNotificationContentVersion rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentVersion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentVersion>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentVersion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class JourneyTemplateReplaceRequestNotificationContentScopeTest : TestBase
{
    [Theory]
    [InlineData(JourneyTemplateReplaceRequestNotificationContentScope.Default)]
    [InlineData(JourneyTemplateReplaceRequestNotificationContentScope.Strict)]
    public void Validation_Works(JourneyTemplateReplaceRequestNotificationContentScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentScope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentScope>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyTemplateReplaceRequestNotificationContentScope.Default)]
    [InlineData(JourneyTemplateReplaceRequestNotificationContentScope.Strict)]
    public void SerializationRoundtrip_Works(
        JourneyTemplateReplaceRequestNotificationContentScope rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentScope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentScope>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyTemplateReplaceRequestNotificationContentScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class JourneyTemplateReplaceRequestNotificationSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationSubscription
        {
            TopicID = "topic_id",
        };

        string expectedTopicID = "topic_id";

        Assert.Equal(expectedTopicID, model.TopicID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationSubscription
        {
            TopicID = "topic_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<JourneyTemplateReplaceRequestNotificationSubscription>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationSubscription
        {
            TopicID = "topic_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<JourneyTemplateReplaceRequestNotificationSubscription>(
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
        var model = new JourneyTemplateReplaceRequestNotificationSubscription
        {
            TopicID = "topic_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyTemplateReplaceRequestNotificationSubscription
        {
            TopicID = "topic_id",
        };

        JourneyTemplateReplaceRequestNotificationSubscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
