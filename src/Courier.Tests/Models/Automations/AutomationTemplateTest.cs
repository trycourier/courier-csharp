using System;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Automations;

namespace Courier.Tests.Models.Automations;

public class AutomationTemplateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationTemplate
        {
            ID = "id",
            Name = "name",
            Version = AutomationTemplateVersion.Published,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, AutomationTemplateVersion> expectedVersion =
            AutomationTemplateVersion.Published;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutomationTemplate
        {
            ID = "id",
            Name = "name",
            Version = AutomationTemplateVersion.Published,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationTemplate>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutomationTemplate
        {
            ID = "id",
            Name = "name",
            Version = AutomationTemplateVersion.Published,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationTemplate>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, AutomationTemplateVersion> expectedVersion =
            AutomationTemplateVersion.Published;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutomationTemplate
        {
            ID = "id",
            Name = "name",
            Version = AutomationTemplateVersion.Published,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutomationTemplate
        {
            ID = "id",
            Name = "name",
            Version = AutomationTemplateVersion.Published,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutomationTemplate
        {
            ID = "id",
            Name = "name",
            Version = AutomationTemplateVersion.Published,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AutomationTemplate
        {
            ID = "id",
            Name = "name",
            Version = AutomationTemplateVersion.Published,

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutomationTemplate
        {
            ID = "id",
            Name = "name",
            Version = AutomationTemplateVersion.Published,

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }
}

public class AutomationTemplateVersionTest : TestBase
{
    [Theory]
    [InlineData(AutomationTemplateVersion.Published)]
    [InlineData(AutomationTemplateVersion.Draft)]
    public void Validation_Works(AutomationTemplateVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationTemplateVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationTemplateVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AutomationTemplateVersion.Published)]
    [InlineData(AutomationTemplateVersion.Draft)]
    public void SerializationRoundtrip_Works(AutomationTemplateVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutomationTemplateVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutomationTemplateVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutomationTemplateVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutomationTemplateVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
