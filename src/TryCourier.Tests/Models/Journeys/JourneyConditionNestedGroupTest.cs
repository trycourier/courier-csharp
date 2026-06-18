using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyConditionNestedGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyConditionNestedGroup
        {
            And =
            [
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
            ],
            Or =
            [
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
            ],
        };

        List<JourneyConditionGroup> expectedAnd =
        [
            new()
            {
                And =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
                Or =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
            },
            new()
            {
                And =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
                Or =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
            },
        ];
        List<JourneyConditionGroup> expectedOr =
        [
            new()
            {
                And =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
                Or =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
            },
            new()
            {
                And =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
                Or =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
            },
        ];

        Assert.NotNull(model.And);
        Assert.Equal(expectedAnd.Count, model.And.Count);
        for (int i = 0; i < expectedAnd.Count; i++)
        {
            Assert.Equal(expectedAnd[i], model.And[i]);
        }
        Assert.NotNull(model.Or);
        Assert.Equal(expectedOr.Count, model.Or.Count);
        for (int i = 0; i < expectedOr.Count; i++)
        {
            Assert.Equal(expectedOr[i], model.Or[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyConditionNestedGroup
        {
            And =
            [
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
            ],
            Or =
            [
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyConditionNestedGroup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyConditionNestedGroup
        {
            And =
            [
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
            ],
            Or =
            [
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyConditionNestedGroup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JourneyConditionGroup> expectedAnd =
        [
            new()
            {
                And =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
                Or =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
            },
            new()
            {
                And =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
                Or =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
            },
        ];
        List<JourneyConditionGroup> expectedOr =
        [
            new()
            {
                And =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
                Or =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
            },
            new()
            {
                And =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
                Or =
                [
                    ["string", "string"],
                    ["string", "string"],
                ],
            },
        ];

        Assert.NotNull(deserialized.And);
        Assert.Equal(expectedAnd.Count, deserialized.And.Count);
        for (int i = 0; i < expectedAnd.Count; i++)
        {
            Assert.Equal(expectedAnd[i], deserialized.And[i]);
        }
        Assert.NotNull(deserialized.Or);
        Assert.Equal(expectedOr.Count, deserialized.Or.Count);
        for (int i = 0; i < expectedOr.Count; i++)
        {
            Assert.Equal(expectedOr[i], deserialized.Or[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyConditionNestedGroup
        {
            And =
            [
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
            ],
            Or =
            [
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyConditionNestedGroup { };

        Assert.Null(model.And);
        Assert.False(model.RawData.ContainsKey("AND"));
        Assert.Null(model.Or);
        Assert.False(model.RawData.ContainsKey("OR"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyConditionNestedGroup { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyConditionNestedGroup
        {
            // Null should be interpreted as omitted for these properties
            And = null,
            Or = null,
        };

        Assert.Null(model.And);
        Assert.False(model.RawData.ContainsKey("AND"));
        Assert.Null(model.Or);
        Assert.False(model.RawData.ContainsKey("OR"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyConditionNestedGroup
        {
            // Null should be interpreted as omitted for these properties
            And = null,
            Or = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyConditionNestedGroup
        {
            And =
            [
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
            ],
            Or =
            [
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
                new()
                {
                    And =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                    Or =
                    [
                        ["string", "string"],
                        ["string", "string"],
                    ],
                },
            ],
        };

        JourneyConditionNestedGroup copied = new(model);

        Assert.Equal(model, copied);
    }
}
