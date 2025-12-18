using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;
using Courier.Models.Bulk;

namespace Courier.Tests.Models.Bulk;

public class BulkRetrieveJobResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkRetrieveJobResponse
        {
            Job = new()
            {
                Definition = new()
                {
                    Event = "event",
                    Brand = "brand",
                    Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                    {
                        {
                            "foo",
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            }
                        },
                    },
                    Override = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Template = "template",
                },
                Enqueued = 0,
                Failures = 0,
                Received = 0,
                Status = JobStatus.Created,
            },
        };

        Job expectedJob = new()
        {
            Definition = new()
            {
                Event = "event",
                Brand = "brand",
                Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                {
                    {
                        "foo",
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    },
                },
                Override = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Template = "template",
            },
            Enqueued = 0,
            Failures = 0,
            Received = 0,
            Status = JobStatus.Created,
        };

        Assert.Equal(expectedJob, model.Job);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BulkRetrieveJobResponse
        {
            Job = new()
            {
                Definition = new()
                {
                    Event = "event",
                    Brand = "brand",
                    Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                    {
                        {
                            "foo",
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            }
                        },
                    },
                    Override = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Template = "template",
                },
                Enqueued = 0,
                Failures = 0,
                Received = 0,
                Status = JobStatus.Created,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkRetrieveJobResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BulkRetrieveJobResponse
        {
            Job = new()
            {
                Definition = new()
                {
                    Event = "event",
                    Brand = "brand",
                    Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                    {
                        {
                            "foo",
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            }
                        },
                    },
                    Override = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Template = "template",
                },
                Enqueued = 0,
                Failures = 0,
                Received = 0,
                Status = JobStatus.Created,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkRetrieveJobResponse>(element);
        Assert.NotNull(deserialized);

        Job expectedJob = new()
        {
            Definition = new()
            {
                Event = "event",
                Brand = "brand",
                Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                {
                    {
                        "foo",
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    },
                },
                Override = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Template = "template",
            },
            Enqueued = 0,
            Failures = 0,
            Received = 0,
            Status = JobStatus.Created,
        };

        Assert.Equal(expectedJob, deserialized.Job);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BulkRetrieveJobResponse
        {
            Job = new()
            {
                Definition = new()
                {
                    Event = "event",
                    Brand = "brand",
                    Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                    {
                        {
                            "foo",
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            }
                        },
                    },
                    Override = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Template = "template",
                },
                Enqueued = 0,
                Failures = 0,
                Received = 0,
                Status = JobStatus.Created,
            },
        };

        model.Validate();
    }
}

public class JobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Job
        {
            Definition = new()
            {
                Event = "event",
                Brand = "brand",
                Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                {
                    {
                        "foo",
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    },
                },
                Override = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Template = "template",
            },
            Enqueued = 0,
            Failures = 0,
            Received = 0,
            Status = JobStatus.Created,
        };

        InboundBulkMessage expectedDefinition = new()
        {
            Event = "event",
            Brand = "brand",
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
            {
                {
                    "foo",
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",
        };
        long expectedEnqueued = 0;
        long expectedFailures = 0;
        long expectedReceived = 0;
        ApiEnum<string, JobStatus> expectedStatus = JobStatus.Created;

        Assert.Equal(expectedDefinition, model.Definition);
        Assert.Equal(expectedEnqueued, model.Enqueued);
        Assert.Equal(expectedFailures, model.Failures);
        Assert.Equal(expectedReceived, model.Received);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Job
        {
            Definition = new()
            {
                Event = "event",
                Brand = "brand",
                Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                {
                    {
                        "foo",
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    },
                },
                Override = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Template = "template",
            },
            Enqueued = 0,
            Failures = 0,
            Received = 0,
            Status = JobStatus.Created,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Job>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Job
        {
            Definition = new()
            {
                Event = "event",
                Brand = "brand",
                Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                {
                    {
                        "foo",
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    },
                },
                Override = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Template = "template",
            },
            Enqueued = 0,
            Failures = 0,
            Received = 0,
            Status = JobStatus.Created,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Job>(element);
        Assert.NotNull(deserialized);

        InboundBulkMessage expectedDefinition = new()
        {
            Event = "event",
            Brand = "brand",
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
            {
                {
                    "foo",
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",
        };
        long expectedEnqueued = 0;
        long expectedFailures = 0;
        long expectedReceived = 0;
        ApiEnum<string, JobStatus> expectedStatus = JobStatus.Created;

        Assert.Equal(expectedDefinition, deserialized.Definition);
        Assert.Equal(expectedEnqueued, deserialized.Enqueued);
        Assert.Equal(expectedFailures, deserialized.Failures);
        Assert.Equal(expectedReceived, deserialized.Received);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Job
        {
            Definition = new()
            {
                Event = "event",
                Brand = "brand",
                Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                {
                    {
                        "foo",
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    },
                },
                Override = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Template = "template",
            },
            Enqueued = 0,
            Failures = 0,
            Received = 0,
            Status = JobStatus.Created,
        };

        model.Validate();
    }
}

public class JobStatusTest : TestBase
{
    [Theory]
    [InlineData(JobStatus.Created)]
    [InlineData(JobStatus.Processing)]
    [InlineData(JobStatus.Completed)]
    [InlineData(JobStatus.Error)]
    public void Validation_Works(JobStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JobStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JobStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JobStatus.Created)]
    [InlineData(JobStatus.Processing)]
    [InlineData(JobStatus.Completed)]
    [InlineData(JobStatus.Error)]
    public void SerializationRoundtrip_Works(JobStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JobStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JobStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JobStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JobStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
