using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
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
                Definition = new InboundBulkTemplateMessage()
                {
                    Template = "template",
                    Brand = "brand",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Event = "event",
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
                },
                Enqueued = 0,
                Failures = 0,
                Received = 0,
                Status = JobStatus.Created,
            },
        };

        Job expectedJob = new()
        {
            Definition = new InboundBulkTemplateMessage()
            {
                Template = "template",
                Brand = "brand",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Event = "event",
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
                Definition = new InboundBulkTemplateMessage()
                {
                    Template = "template",
                    Brand = "brand",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Event = "event",
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
                Definition = new InboundBulkTemplateMessage()
                {
                    Template = "template",
                    Brand = "brand",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Event = "event",
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
                },
                Enqueued = 0,
                Failures = 0,
                Received = 0,
                Status = JobStatus.Created,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkRetrieveJobResponse>(json);
        Assert.NotNull(deserialized);

        Job expectedJob = new()
        {
            Definition = new InboundBulkTemplateMessage()
            {
                Template = "template",
                Brand = "brand",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Event = "event",
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
                Definition = new InboundBulkTemplateMessage()
                {
                    Template = "template",
                    Brand = "brand",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Event = "event",
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
            Definition = new InboundBulkTemplateMessage()
            {
                Template = "template",
                Brand = "brand",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Event = "event",
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
            },
            Enqueued = 0,
            Failures = 0,
            Received = 0,
            Status = JobStatus.Created,
        };

        InboundBulkMessage expectedDefinition = new InboundBulkTemplateMessage()
        {
            Template = "template",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Event = "event",
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
            Definition = new InboundBulkTemplateMessage()
            {
                Template = "template",
                Brand = "brand",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Event = "event",
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
            Definition = new InboundBulkTemplateMessage()
            {
                Template = "template",
                Brand = "brand",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Event = "event",
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
            },
            Enqueued = 0,
            Failures = 0,
            Received = 0,
            Status = JobStatus.Created,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Job>(json);
        Assert.NotNull(deserialized);

        InboundBulkMessage expectedDefinition = new InboundBulkTemplateMessage()
        {
            Template = "template",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Event = "event",
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
            Definition = new InboundBulkTemplateMessage()
            {
                Template = "template",
                Brand = "brand",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Event = "event",
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
            },
            Enqueued = 0,
            Failures = 0,
            Received = 0,
            Status = JobStatus.Created,
        };

        model.Validate();
    }
}
