using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyTemplateCreateRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyTemplateCreateRequest
        {
            Channel = "x",
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
                    Version = ContentVersion.V2022_01_01,
                    Scope = ContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            ProviderKey = "x",
            State = "state",
        };

        string expectedChannel = "x";
        Notification expectedNotification = new()
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
                Version = ContentVersion.V2022_01_01,
                Scope = ContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };
        string expectedProviderKey = "x";
        string expectedState = "state";

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedNotification, model.Notification);
        Assert.Equal(expectedProviderKey, model.ProviderKey);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyTemplateCreateRequest
        {
            Channel = "x",
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
                    Version = ContentVersion.V2022_01_01,
                    Scope = ContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            ProviderKey = "x",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyTemplateCreateRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyTemplateCreateRequest
        {
            Channel = "x",
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
                    Version = ContentVersion.V2022_01_01,
                    Scope = ContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            ProviderKey = "x",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyTemplateCreateRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannel = "x";
        Notification expectedNotification = new()
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
                Version = ContentVersion.V2022_01_01,
                Scope = ContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };
        string expectedProviderKey = "x";
        string expectedState = "state";

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedNotification, deserialized.Notification);
        Assert.Equal(expectedProviderKey, deserialized.ProviderKey);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyTemplateCreateRequest
        {
            Channel = "x",
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
                    Version = ContentVersion.V2022_01_01,
                    Scope = ContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            ProviderKey = "x",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyTemplateCreateRequest
        {
            Channel = "x",
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
                    Version = ContentVersion.V2022_01_01,
                    Scope = ContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
        };

        Assert.Null(model.ProviderKey);
        Assert.False(model.RawData.ContainsKey("providerKey"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyTemplateCreateRequest
        {
            Channel = "x",
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
                    Version = ContentVersion.V2022_01_01,
                    Scope = ContentScope.Default,
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
        var model = new JourneyTemplateCreateRequest
        {
            Channel = "x",
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
                    Version = ContentVersion.V2022_01_01,
                    Scope = ContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },

            // Null should be interpreted as omitted for these properties
            ProviderKey = null,
            State = null,
        };

        Assert.Null(model.ProviderKey);
        Assert.False(model.RawData.ContainsKey("providerKey"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyTemplateCreateRequest
        {
            Channel = "x",
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
                    Version = ContentVersion.V2022_01_01,
                    Scope = ContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },

            // Null should be interpreted as omitted for these properties
            ProviderKey = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyTemplateCreateRequest
        {
            Channel = "x",
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
                    Version = ContentVersion.V2022_01_01,
                    Scope = ContentScope.Default,
                },
                Name = "name",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            ProviderKey = "x",
            State = "state",
        };

        JourneyTemplateCreateRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notification
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
                Version = ContentVersion.V2022_01_01,
                Scope = ContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        Brand expectedBrand = new("id");
        Content expectedContent = new()
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
            Version = ContentVersion.V2022_01_01,
            Scope = ContentScope.Default,
        };
        string expectedName = "name";
        Subscription expectedSubscription = new("topic_id");
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
        var model = new Notification
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
                Version = ContentVersion.V2022_01_01,
                Scope = ContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notification
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
                Version = ContentVersion.V2022_01_01,
                Scope = ContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Brand expectedBrand = new("id");
        Content expectedContent = new()
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
            Version = ContentVersion.V2022_01_01,
            Scope = ContentScope.Default,
        };
        string expectedName = "name";
        Subscription expectedSubscription = new("topic_id");
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
        var model = new Notification
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
                Version = ContentVersion.V2022_01_01,
                Scope = ContentScope.Default,
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
        var model = new Notification
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
                Version = ContentVersion.V2022_01_01,
                Scope = ContentScope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        Notification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Brand { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Brand { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Brand>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Brand { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Brand>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Brand { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Brand { ID = "id" };

        Brand copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Content
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
            Version = ContentVersion.V2022_01_01,
            Scope = ContentScope.Default,
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
        ApiEnum<string, ContentVersion> expectedVersion = ContentVersion.V2022_01_01;
        ApiEnum<string, ContentScope> expectedScope = ContentScope.Default;

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
        var model = new Content
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
            Version = ContentVersion.V2022_01_01,
            Scope = ContentScope.Default,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Content
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
            Version = ContentVersion.V2022_01_01,
            Scope = ContentScope.Default,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
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
        ApiEnum<string, ContentVersion> expectedVersion = ContentVersion.V2022_01_01;
        ApiEnum<string, ContentScope> expectedScope = ContentScope.Default;

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
        var model = new Content
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
            Version = ContentVersion.V2022_01_01,
            Scope = ContentScope.Default,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Content
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
            Version = ContentVersion.V2022_01_01,
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Content
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
            Version = ContentVersion.V2022_01_01,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Content
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
            Version = ContentVersion.V2022_01_01,

            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Content
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
            Version = ContentVersion.V2022_01_01,

            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Content
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
            Version = ContentVersion.V2022_01_01,
            Scope = ContentScope.Default,
        };

        Content copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentVersionTest : TestBase
{
    [Theory]
    [InlineData(ContentVersion.V2022_01_01)]
    public void Validation_Works(ContentVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContentVersion.V2022_01_01)]
    public void SerializationRoundtrip_Works(ContentVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ContentScopeTest : TestBase
{
    [Theory]
    [InlineData(ContentScope.Default)]
    [InlineData(ContentScope.Strict)]
    public void Validation_Works(ContentScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentScope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentScope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContentScope.Default)]
    [InlineData(ContentScope.Strict)]
    public void SerializationRoundtrip_Works(ContentScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentScope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentScope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentScope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentScope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscription { TopicID = "topic_id" };

        string expectedTopicID = "topic_id";

        Assert.Equal(expectedTopicID, model.TopicID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscription { TopicID = "topic_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscription { TopicID = "topic_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
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
        var model = new Subscription { TopicID = "topic_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscription { TopicID = "topic_id" };

        Subscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
