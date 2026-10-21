using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationTemplateEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationTemplateEmail
        {
            Bcc = ["string"],
            Cc = ["string"],
            From = "from",
            ReplyTo = "reply_to",
        };

        List<string> expectedBcc = ["string"];
        List<string> expectedCc = ["string"];
        string expectedFrom = "from";
        string expectedReplyTo = "reply_to";

        Assert.NotNull(model.Bcc);
        Assert.Equal(expectedBcc.Count, model.Bcc.Count);
        for (int i = 0; i < expectedBcc.Count; i++)
        {
            Assert.Equal(expectedBcc[i], model.Bcc[i]);
        }
        Assert.NotNull(model.Cc);
        Assert.Equal(expectedCc.Count, model.Cc.Count);
        for (int i = 0; i < expectedCc.Count; i++)
        {
            Assert.Equal(expectedCc[i], model.Cc[i]);
        }
        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedReplyTo, model.ReplyTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationTemplateEmail
        {
            Bcc = ["string"],
            Cc = ["string"],
            From = "from",
            ReplyTo = "reply_to",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateEmail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationTemplateEmail
        {
            Bcc = ["string"],
            Cc = ["string"],
            From = "from",
            ReplyTo = "reply_to",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateEmail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedBcc = ["string"];
        List<string> expectedCc = ["string"];
        string expectedFrom = "from";
        string expectedReplyTo = "reply_to";

        Assert.NotNull(deserialized.Bcc);
        Assert.Equal(expectedBcc.Count, deserialized.Bcc.Count);
        for (int i = 0; i < expectedBcc.Count; i++)
        {
            Assert.Equal(expectedBcc[i], deserialized.Bcc[i]);
        }
        Assert.NotNull(deserialized.Cc);
        Assert.Equal(expectedCc.Count, deserialized.Cc.Count);
        for (int i = 0; i < expectedCc.Count; i++)
        {
            Assert.Equal(expectedCc[i], deserialized.Cc[i]);
        }
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedReplyTo, deserialized.ReplyTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationTemplateEmail
        {
            Bcc = ["string"],
            Cc = ["string"],
            From = "from",
            ReplyTo = "reply_to",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotificationTemplateEmail { };

        Assert.Null(model.Bcc);
        Assert.False(model.RawData.ContainsKey("bcc"));
        Assert.Null(model.Cc);
        Assert.False(model.RawData.ContainsKey("cc"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.ReplyTo);
        Assert.False(model.RawData.ContainsKey("reply_to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotificationTemplateEmail { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotificationTemplateEmail
        {
            // Null should be interpreted as omitted for these properties
            Bcc = null,
            Cc = null,
            From = null,
            ReplyTo = null,
        };

        Assert.Null(model.Bcc);
        Assert.False(model.RawData.ContainsKey("bcc"));
        Assert.Null(model.Cc);
        Assert.False(model.RawData.ContainsKey("cc"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.ReplyTo);
        Assert.False(model.RawData.ContainsKey("reply_to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotificationTemplateEmail
        {
            // Null should be interpreted as omitted for these properties
            Bcc = null,
            Cc = null,
            From = null,
            ReplyTo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationTemplateEmail
        {
            Bcc = ["string"],
            Cc = ["string"],
            From = "from",
            ReplyTo = "reply_to",
        };

        NotificationTemplateEmail copied = new(model);

        Assert.Equal(model, copied);
    }
}
