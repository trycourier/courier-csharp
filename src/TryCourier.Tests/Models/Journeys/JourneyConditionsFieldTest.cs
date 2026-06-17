using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyConditionsFieldTest : TestBase
{
    [Fact]
    public void ConditionAtomValidationWorks()
    {
        JourneyConditionsField value = new(["string", "string"]);
        value.Validate();
    }

    [Fact]
    public void ConditionGroupValidationWorks()
    {
        JourneyConditionsField value = new JourneyConditionGroup()
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
        };
        value.Validate();
    }

    [Fact]
    public void ConditionNestedGroupValidationWorks()
    {
        JourneyConditionsField value = new JourneyConditionNestedGroup()
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
        value.Validate();
    }

    [Fact]
    public void ConditionAtomSerializationRoundtripWorks()
    {
        JourneyConditionsField value = new(["string", "string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyConditionsField>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ConditionGroupSerializationRoundtripWorks()
    {
        JourneyConditionsField value = new JourneyConditionGroup()
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyConditionsField>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ConditionNestedGroupSerializationRoundtripWorks()
    {
        JourneyConditionsField value = new JourneyConditionNestedGroup()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyConditionsField>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
