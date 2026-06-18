using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using Templates = TryCourier.Models.Journeys.Templates;

namespace TryCourier.Tests.Models.Journeys.Templates;

public class TemplateCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            TemplateID = "x",
            Channel = "email",
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
                    Version = Templates::Version.V2022_01_01,
                    Scope = Templates::Scope.Default,
                },
                Name = "Welcome email",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            ProviderKey = "x",
            State = "state",
        };

        string expectedTemplateID = "x";
        string expectedChannel = "email";
        Templates::Notification expectedNotification = new()
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
                Version = Templates::Version.V2022_01_01,
                Scope = Templates::Scope.Default,
            },
            Name = "Welcome email",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };
        string expectedProviderKey = "x";
        string expectedState = "state";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedNotification, parameters.Notification);
        Assert.Equal(expectedProviderKey, parameters.ProviderKey);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            TemplateID = "x",
            Channel = "email",
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
                    Version = Templates::Version.V2022_01_01,
                    Scope = Templates::Scope.Default,
                },
                Name = "Welcome email",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
        };

        Assert.Null(parameters.ProviderKey);
        Assert.False(parameters.RawBodyData.ContainsKey("providerKey"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            TemplateID = "x",
            Channel = "email",
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
                    Version = Templates::Version.V2022_01_01,
                    Scope = Templates::Scope.Default,
                },
                Name = "Welcome email",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },

            // Null should be interpreted as omitted for these properties
            ProviderKey = null,
            State = null,
        };

        Assert.Null(parameters.ProviderKey);
        Assert.False(parameters.RawBodyData.ContainsKey("providerKey"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        Templates::TemplateCreateParams parameters = new()
        {
            TemplateID = "x",
            Channel = "email",
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
                    Version = Templates::Version.V2022_01_01,
                    Scope = Templates::Scope.Default,
                },
                Name = "Welcome email",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/x/templates"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            TemplateID = "x",
            Channel = "email",
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
                    Version = Templates::Version.V2022_01_01,
                    Scope = Templates::Scope.Default,
                },
                Name = "Welcome email",
                Subscription = new("topic_id"),
                Tags = ["string"],
            },
            ProviderKey = "x",
            State = "state",
        };

        Templates::TemplateCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class NotificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Templates::Notification
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
                Version = Templates::Version.V2022_01_01,
                Scope = Templates::Scope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        Templates::Brand expectedBrand = new("id");
        Templates::Content expectedContent = new()
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
            Version = Templates::Version.V2022_01_01,
            Scope = Templates::Scope.Default,
        };
        string expectedName = "name";
        Templates::Subscription expectedSubscription = new("topic_id");
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
        var model = new Templates::Notification
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
                Version = Templates::Version.V2022_01_01,
                Scope = Templates::Scope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Templates::Notification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Templates::Notification
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
                Version = Templates::Version.V2022_01_01,
                Scope = Templates::Scope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Templates::Notification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Templates::Brand expectedBrand = new("id");
        Templates::Content expectedContent = new()
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
            Version = Templates::Version.V2022_01_01,
            Scope = Templates::Scope.Default,
        };
        string expectedName = "name";
        Templates::Subscription expectedSubscription = new("topic_id");
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
        var model = new Templates::Notification
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
                Version = Templates::Version.V2022_01_01,
                Scope = Templates::Scope.Default,
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
        var model = new Templates::Notification
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
                Version = Templates::Version.V2022_01_01,
                Scope = Templates::Scope.Default,
            },
            Name = "name",
            Subscription = new("topic_id"),
            Tags = ["string"],
        };

        Templates::Notification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Templates::Brand { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Templates::Brand { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Templates::Brand>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Templates::Brand { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Templates::Brand>(
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
        var model = new Templates::Brand { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Templates::Brand { ID = "id" };

        Templates::Brand copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Templates::Content
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
            Version = Templates::Version.V2022_01_01,
            Scope = Templates::Scope.Default,
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
        ApiEnum<string, Templates::Version> expectedVersion = Templates::Version.V2022_01_01;
        ApiEnum<string, Templates::Scope> expectedScope = Templates::Scope.Default;

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
        var model = new Templates::Content
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
            Version = Templates::Version.V2022_01_01,
            Scope = Templates::Scope.Default,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Templates::Content>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Templates::Content
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
            Version = Templates::Version.V2022_01_01,
            Scope = Templates::Scope.Default,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Templates::Content>(
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
        ApiEnum<string, Templates::Version> expectedVersion = Templates::Version.V2022_01_01;
        ApiEnum<string, Templates::Scope> expectedScope = Templates::Scope.Default;

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
        var model = new Templates::Content
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
            Version = Templates::Version.V2022_01_01,
            Scope = Templates::Scope.Default,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Templates::Content
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
            Version = Templates::Version.V2022_01_01,
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Templates::Content
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
            Version = Templates::Version.V2022_01_01,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Templates::Content
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
            Version = Templates::Version.V2022_01_01,

            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Templates::Content
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
            Version = Templates::Version.V2022_01_01,

            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Templates::Content
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
            Version = Templates::Version.V2022_01_01,
            Scope = Templates::Scope.Default,
        };

        Templates::Content copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionTest : TestBase
{
    [Theory]
    [InlineData(Templates::Version.V2022_01_01)]
    public void Validation_Works(Templates::Version rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::Version> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::Version>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Templates::Version.V2022_01_01)]
    public void SerializationRoundtrip_Works(Templates::Version rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::Version> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::Version>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::Version>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::Version>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ScopeTest : TestBase
{
    [Theory]
    [InlineData(Templates::Scope.Default)]
    [InlineData(Templates::Scope.Strict)]
    public void Validation_Works(Templates::Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::Scope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Templates::Scope.Default)]
    [InlineData(Templates::Scope.Strict)]
    public void SerializationRoundtrip_Works(Templates::Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::Scope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::Scope>>(
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
        var model = new Templates::Subscription { TopicID = "topic_id" };

        string expectedTopicID = "topic_id";

        Assert.Equal(expectedTopicID, model.TopicID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Templates::Subscription { TopicID = "topic_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Templates::Subscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Templates::Subscription { TopicID = "topic_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Templates::Subscription>(
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
        var model = new Templates::Subscription { TopicID = "topic_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Templates::Subscription { TopicID = "topic_id" };

        Templates::Subscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
