using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneySegmentTriggerNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneySegmentTriggerNode
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "x",
        };

        ApiEnum<string, RequestType> expectedRequestType = RequestType.Identify;
        ApiEnum<string, JourneySegmentTriggerNodeTriggerType> expectedTriggerType =
            JourneySegmentTriggerNodeTriggerType.Segment;
        ApiEnum<string, JourneySegmentTriggerNodeType> expectedType =
            JourneySegmentTriggerNodeType.Trigger;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        string expectedEventID = "x";

        Assert.Equal(expectedRequestType, model.RequestType);
        Assert.Equal(expectedTriggerType, model.TriggerType);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConditions, model.Conditions);
        Assert.Equal(expectedEventID, model.EventID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneySegmentTriggerNode
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySegmentTriggerNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneySegmentTriggerNode
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySegmentTriggerNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RequestType> expectedRequestType = RequestType.Identify;
        ApiEnum<string, JourneySegmentTriggerNodeTriggerType> expectedTriggerType =
            JourneySegmentTriggerNodeTriggerType.Segment;
        ApiEnum<string, JourneySegmentTriggerNodeType> expectedType =
            JourneySegmentTriggerNodeType.Trigger;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        string expectedEventID = "x";

        Assert.Equal(expectedRequestType, deserialized.RequestType);
        Assert.Equal(expectedTriggerType, deserialized.TriggerType);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConditions, deserialized.Conditions);
        Assert.Equal(expectedEventID, deserialized.EventID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneySegmentTriggerNode
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneySegmentTriggerNode
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneySegmentTriggerNode
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneySegmentTriggerNode
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
            EventID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneySegmentTriggerNode
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
            EventID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneySegmentTriggerNode
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "x",
        };

        JourneySegmentTriggerNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RequestTypeTest : TestBase
{
    [Theory]
    [InlineData(RequestType.Identify)]
    [InlineData(RequestType.Group)]
    [InlineData(RequestType.Track)]
    public void Validation_Works(RequestType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RequestType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RequestType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RequestType.Identify)]
    [InlineData(RequestType.Group)]
    [InlineData(RequestType.Track)]
    public void SerializationRoundtrip_Works(RequestType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RequestType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RequestType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RequestType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RequestType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JourneySegmentTriggerNodeTriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneySegmentTriggerNodeTriggerType.Segment)]
    public void Validation_Works(JourneySegmentTriggerNodeTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneySegmentTriggerNodeTriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JourneySegmentTriggerNodeTriggerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneySegmentTriggerNodeTriggerType.Segment)]
    public void SerializationRoundtrip_Works(JourneySegmentTriggerNodeTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneySegmentTriggerNodeTriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneySegmentTriggerNodeTriggerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JourneySegmentTriggerNodeTriggerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneySegmentTriggerNodeTriggerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class JourneySegmentTriggerNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneySegmentTriggerNodeType.Trigger)]
    public void Validation_Works(JourneySegmentTriggerNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneySegmentTriggerNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneySegmentTriggerNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneySegmentTriggerNodeType.Trigger)]
    public void SerializationRoundtrip_Works(JourneySegmentTriggerNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneySegmentTriggerNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneySegmentTriggerNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneySegmentTriggerNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneySegmentTriggerNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
