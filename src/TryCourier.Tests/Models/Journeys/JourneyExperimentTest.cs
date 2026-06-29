using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyExperimentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyExperiment
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],
            ID = "x",
            Name = "name",
        };

        string expectedBucketingKey = "x";
        List<JourneyExperimentVariant> expectedVariants =
        [
            new()
            {
                ID = "x",
                TemplateID = "x",
                Weight = 0,
                Name = "name",
            },
            new()
            {
                ID = "x",
                TemplateID = "x",
                Weight = 0,
                Name = "name",
            },
        ];
        string expectedID = "x";
        string expectedName = "name";

        Assert.Equal(expectedBucketingKey, model.BucketingKey);
        Assert.Equal(expectedVariants.Count, model.Variants.Count);
        for (int i = 0; i < expectedVariants.Count; i++)
        {
            Assert.Equal(expectedVariants[i], model.Variants[i]);
        }
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyExperiment
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],
            ID = "x",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyExperiment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyExperiment
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],
            ID = "x",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyExperiment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucketingKey = "x";
        List<JourneyExperimentVariant> expectedVariants =
        [
            new()
            {
                ID = "x",
                TemplateID = "x",
                Weight = 0,
                Name = "name",
            },
            new()
            {
                ID = "x",
                TemplateID = "x",
                Weight = 0,
                Name = "name",
            },
        ];
        string expectedID = "x";
        string expectedName = "name";

        Assert.Equal(expectedBucketingKey, deserialized.BucketingKey);
        Assert.Equal(expectedVariants.Count, deserialized.Variants.Count);
        for (int i = 0; i < expectedVariants.Count; i++)
        {
            Assert.Equal(expectedVariants[i], deserialized.Variants[i]);
        }
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyExperiment
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],
            ID = "x",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyExperiment
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyExperiment
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyExperiment
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyExperiment
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyExperiment
        {
            BucketingKey = "x",
            Variants =
            [
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
                new()
                {
                    ID = "x",
                    TemplateID = "x",
                    Weight = 0,
                    Name = "name",
                },
            ],
            ID = "x",
            Name = "name",
        };

        JourneyExperiment copied = new(model);

        Assert.Equal(model, copied);
    }
}
