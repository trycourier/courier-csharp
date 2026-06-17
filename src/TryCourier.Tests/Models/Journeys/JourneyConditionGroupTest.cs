using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyConditionGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyConditionGroup
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

        List<List<string>> expectedAnd =
        [
            ["string", "string"],
            ["string", "string"],
        ];
        List<List<string>> expectedOr =
        [
            ["string", "string"],
            ["string", "string"],
        ];

        Assert.NotNull(model.And);
        Assert.Equal(expectedAnd.Count, model.And.Count);
        for (int i = 0; i < expectedAnd.Count; i++)
        {
            Assert.Equal(expectedAnd[i].Count, model.And[i].Count);
            for (int i1 = 0; i1 < expectedAnd[i].Count; i1++)
            {
                Assert.Equal(expectedAnd[i][i1], model.And[i][i1]);
            }
        }
        Assert.NotNull(model.Or);
        Assert.Equal(expectedOr.Count, model.Or.Count);
        for (int i = 0; i < expectedOr.Count; i++)
        {
            Assert.Equal(expectedOr[i].Count, model.Or[i].Count);
            for (int i1 = 0; i1 < expectedOr[i].Count; i1++)
            {
                Assert.Equal(expectedOr[i][i1], model.Or[i][i1]);
            }
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyConditionGroup
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyConditionGroup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyConditionGroup
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyConditionGroup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<List<string>> expectedAnd =
        [
            ["string", "string"],
            ["string", "string"],
        ];
        List<List<string>> expectedOr =
        [
            ["string", "string"],
            ["string", "string"],
        ];

        Assert.NotNull(deserialized.And);
        Assert.Equal(expectedAnd.Count, deserialized.And.Count);
        for (int i = 0; i < expectedAnd.Count; i++)
        {
            Assert.Equal(expectedAnd[i].Count, deserialized.And[i].Count);
            for (int i1 = 0; i1 < expectedAnd[i].Count; i1++)
            {
                Assert.Equal(expectedAnd[i][i1], deserialized.And[i][i1]);
            }
        }
        Assert.NotNull(deserialized.Or);
        Assert.Equal(expectedOr.Count, deserialized.Or.Count);
        for (int i = 0; i < expectedOr.Count; i++)
        {
            Assert.Equal(expectedOr[i].Count, deserialized.Or[i].Count);
            for (int i1 = 0; i1 < expectedOr[i].Count; i1++)
            {
                Assert.Equal(expectedOr[i][i1], deserialized.Or[i][i1]);
            }
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyConditionGroup
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyConditionGroup { };

        Assert.Null(model.And);
        Assert.False(model.RawData.ContainsKey("AND"));
        Assert.Null(model.Or);
        Assert.False(model.RawData.ContainsKey("OR"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyConditionGroup { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyConditionGroup
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
        var model = new JourneyConditionGroup
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
        var model = new JourneyConditionGroup
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

        JourneyConditionGroup copied = new(model);

        Assert.Equal(model, copied);
    }
}
