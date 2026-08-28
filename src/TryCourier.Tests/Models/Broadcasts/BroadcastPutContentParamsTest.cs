using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Broadcasts;
using Notifications = TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastPutContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastPutContentParams
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Elements =
                [
                    new ElementalMetaNodeWithType()
                    {
                        Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                    },
                    new ElementalTextNodeWithType()
                    {
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "2022-01-01",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        string expectedBroadcastID = "broadcastId";
        Content expectedContent = new()
        {
            Elements =
            [
                new ElementalMetaNodeWithType()
                {
                    Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                },
                new ElementalTextNodeWithType()
                {
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Version = "2022-01-01",
        };
        ApiEnum<string, Notifications::NotificationTemplateState> expectedState =
            Notifications::NotificationTemplateState.Draft;

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BroadcastPutContentParams
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Elements =
                [
                    new ElementalMetaNodeWithType()
                    {
                        Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                    },
                    new ElementalTextNodeWithType()
                    {
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "2022-01-01",
            },
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BroadcastPutContentParams
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Elements =
                [
                    new ElementalMetaNodeWithType()
                    {
                        Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                    },
                    new ElementalTextNodeWithType()
                    {
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "2022-01-01",
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
        BroadcastPutContentParams parameters = new()
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Elements =
                [
                    new ElementalMetaNodeWithType()
                    {
                        Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                    },
                    new ElementalTextNodeWithType()
                    {
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "2022-01-01",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/broadcasts/broadcastId/content"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastPutContentParams
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Elements =
                [
                    new ElementalMetaNodeWithType()
                    {
                        Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                    },
                    new ElementalTextNodeWithType()
                    {
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "2022-01-01",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        BroadcastPutContentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Version = "version",
        };

        List<ElementalNode> expectedElements =
        [
            new ElementalTextNodeWithType()
            {
                Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
            },
        ];
        string expectedVersion = "version";

        Assert.Equal(expectedElements.Count, model.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], model.Elements[i]);
        }
        Assert.Equal(expectedVersion, model.Version);
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
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Version = "version",
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
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Version = "version",
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
                Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
            },
        ];
        string expectedVersion = "version";

        Assert.Equal(expectedElements.Count, deserialized.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], deserialized.Elements[i]);
        }
        Assert.Equal(expectedVersion, deserialized.Version);
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
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Version = "version",
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
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
        };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
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
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
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
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
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
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],

            // Null should be interpreted as omitted for these properties
            Version = null,
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
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Version = "version",
        };

        Content copied = new(model);

        Assert.Equal(model, copied);
    }
}
