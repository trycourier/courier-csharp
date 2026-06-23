using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Journeys.Templates;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Journeys.Templates;

public class TemplatePutContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplatePutContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                    },
                ],
                Version = "2022-01-01",
            },
            State = NotificationTemplateState.Draft,
        };

        string expectedTemplateID = "x";
        string expectedNotificationID = "x";
        TemplatePutContentParamsContent expectedContent = new()
        {
            Elements =
            [
                new ElementalChannelNodeWithType()
                {
                    Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                },
            ],
            Version = "2022-01-01",
        };
        ApiEnum<string, NotificationTemplateState> expectedState = NotificationTemplateState.Draft;

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedNotificationID, parameters.NotificationID);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplatePutContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
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
        var parameters = new TemplatePutContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
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
        TemplatePutContentParams parameters = new()
        {
            TemplateID = "x",
            NotificationID = "x",
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                    },
                ],
                Version = "2022-01-01",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/journeys/x/templates/x/content"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplatePutContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                    },
                ],
                Version = "2022-01-01",
            },
            State = NotificationTemplateState.Draft,
        };

        TemplatePutContentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TemplatePutContentParamsContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplatePutContentParamsContent
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
        var model = new TemplatePutContentParamsContent
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplatePutContentParamsContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplatePutContentParamsContent
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplatePutContentParamsContent>(
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
        var model = new TemplatePutContentParamsContent
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplatePutContentParamsContent
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
        };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplatePutContentParamsContent
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplatePutContentParamsContent
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

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplatePutContentParamsContent
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

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplatePutContentParamsContent
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

        TemplatePutContentParamsContent copied = new(model);

        Assert.Equal(model, copied);
    }
}
