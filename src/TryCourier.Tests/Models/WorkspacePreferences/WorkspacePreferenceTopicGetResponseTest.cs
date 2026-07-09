using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class WorkspacePreferenceTopicGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspacePreferenceTopicGetResponse
        {
            ID = "id",
            AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
            Created = "created",
            DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
            IncludeUnsubscribeHeader = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Updated = "updated",
            Creator = "creator",
            Description = "description",
            Updater = "updater",
        };

        string expectedID = "id";
        List<
            ApiEnum<string, WorkspacePreferenceTopicGetResponseAllowedPreference>
        > expectedAllowedPreferences =
        [
            WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze,
        ];
        string expectedCreated = "created";
        ApiEnum<string, WorkspacePreferenceTopicGetResponseDefaultStatus> expectedDefaultStatus =
            WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut;
        bool expectedIncludeUnsubscribeHeader = true;
        string expectedName = "name";
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];
        Dictionary<string, JsonElement> expectedTopicData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedUpdated = "updated";
        string expectedCreator = "creator";
        string expectedDescription = "description";
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAllowedPreferences.Count, model.AllowedPreferences.Count);
        for (int i = 0; i < expectedAllowedPreferences.Count; i++)
        {
            Assert.Equal(expectedAllowedPreferences[i], model.AllowedPreferences[i]);
        }
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedDefaultStatus, model.DefaultStatus);
        Assert.Equal(expectedIncludeUnsubscribeHeader, model.IncludeUnsubscribeHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRoutingOptions.Count, model.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], model.RoutingOptions[i]);
        }
        Assert.Equal(expectedTopicData.Count, model.TopicData.Count);
        foreach (var item in expectedTopicData)
        {
            Assert.True(model.TopicData.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.TopicData[item.Key]));
        }
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedUpdater, model.Updater);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspacePreferenceTopicGetResponse
        {
            ID = "id",
            AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
            Created = "created",
            DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
            IncludeUnsubscribeHeader = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Updated = "updated",
            Creator = "creator",
            Description = "description",
            Updater = "updater",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspacePreferenceTopicGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspacePreferenceTopicGetResponse
        {
            ID = "id",
            AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
            Created = "created",
            DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
            IncludeUnsubscribeHeader = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Updated = "updated",
            Creator = "creator",
            Description = "description",
            Updater = "updater",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspacePreferenceTopicGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<
            ApiEnum<string, WorkspacePreferenceTopicGetResponseAllowedPreference>
        > expectedAllowedPreferences =
        [
            WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze,
        ];
        string expectedCreated = "created";
        ApiEnum<string, WorkspacePreferenceTopicGetResponseDefaultStatus> expectedDefaultStatus =
            WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut;
        bool expectedIncludeUnsubscribeHeader = true;
        string expectedName = "name";
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];
        Dictionary<string, JsonElement> expectedTopicData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedUpdated = "updated";
        string expectedCreator = "creator";
        string expectedDescription = "description";
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAllowedPreferences.Count, deserialized.AllowedPreferences.Count);
        for (int i = 0; i < expectedAllowedPreferences.Count; i++)
        {
            Assert.Equal(expectedAllowedPreferences[i], deserialized.AllowedPreferences[i]);
        }
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedDefaultStatus, deserialized.DefaultStatus);
        Assert.Equal(expectedIncludeUnsubscribeHeader, deserialized.IncludeUnsubscribeHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRoutingOptions.Count, deserialized.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], deserialized.RoutingOptions[i]);
        }
        Assert.Equal(expectedTopicData.Count, deserialized.TopicData.Count);
        foreach (var item in expectedTopicData)
        {
            Assert.True(deserialized.TopicData.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.TopicData[item.Key]));
        }
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedUpdater, deserialized.Updater);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkspacePreferenceTopicGetResponse
        {
            ID = "id",
            AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
            Created = "created",
            DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
            IncludeUnsubscribeHeader = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Updated = "updated",
            Creator = "creator",
            Description = "description",
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorkspacePreferenceTopicGetResponse
        {
            ID = "id",
            AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
            Created = "created",
            DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
            IncludeUnsubscribeHeader = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Updated = "updated",
        };

        Assert.Null(model.Creator);
        Assert.False(model.RawData.ContainsKey("creator"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorkspacePreferenceTopicGetResponse
        {
            ID = "id",
            AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
            Created = "created",
            DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
            IncludeUnsubscribeHeader = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Updated = "updated",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WorkspacePreferenceTopicGetResponse
        {
            ID = "id",
            AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
            Created = "created",
            DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
            IncludeUnsubscribeHeader = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Updated = "updated",

            Creator = null,
            Description = null,
            Updater = null,
        };

        Assert.Null(model.Creator);
        Assert.True(model.RawData.ContainsKey("creator"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Updater);
        Assert.True(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorkspacePreferenceTopicGetResponse
        {
            ID = "id",
            AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
            Created = "created",
            DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
            IncludeUnsubscribeHeader = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Updated = "updated",

            Creator = null,
            Description = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspacePreferenceTopicGetResponse
        {
            ID = "id",
            AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
            Created = "created",
            DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
            IncludeUnsubscribeHeader = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Updated = "updated",
            Creator = "creator",
            Description = "description",
            Updater = "updater",
        };

        WorkspacePreferenceTopicGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkspacePreferenceTopicGetResponseAllowedPreferenceTest : TestBase
{
    [Theory]
    [InlineData(WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze)]
    [InlineData(WorkspacePreferenceTopicGetResponseAllowedPreference.ChannelPreferences)]
    public void Validation_Works(WorkspacePreferenceTopicGetResponseAllowedPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkspacePreferenceTopicGetResponseAllowedPreference> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WorkspacePreferenceTopicGetResponseAllowedPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze)]
    [InlineData(WorkspacePreferenceTopicGetResponseAllowedPreference.ChannelPreferences)]
    public void SerializationRoundtrip_Works(
        WorkspacePreferenceTopicGetResponseAllowedPreference rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkspacePreferenceTopicGetResponseAllowedPreference> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WorkspacePreferenceTopicGetResponseAllowedPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WorkspacePreferenceTopicGetResponseAllowedPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WorkspacePreferenceTopicGetResponseAllowedPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WorkspacePreferenceTopicGetResponseDefaultStatusTest : TestBase
{
    [Theory]
    [InlineData(WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut)]
    [InlineData(WorkspacePreferenceTopicGetResponseDefaultStatus.OptedIn)]
    [InlineData(WorkspacePreferenceTopicGetResponseDefaultStatus.Required)]
    public void Validation_Works(WorkspacePreferenceTopicGetResponseDefaultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkspacePreferenceTopicGetResponseDefaultStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WorkspacePreferenceTopicGetResponseDefaultStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut)]
    [InlineData(WorkspacePreferenceTopicGetResponseDefaultStatus.OptedIn)]
    [InlineData(WorkspacePreferenceTopicGetResponseDefaultStatus.Required)]
    public void SerializationRoundtrip_Works(
        WorkspacePreferenceTopicGetResponseDefaultStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkspacePreferenceTopicGetResponseDefaultStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WorkspacePreferenceTopicGetResponseDefaultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WorkspacePreferenceTopicGetResponseDefaultStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WorkspacePreferenceTopicGetResponseDefaultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
