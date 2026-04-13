using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationPutLocaleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationPutLocaleParams
        {
            ID = "id",
            LocaleID = "localeId",
            Elements = [new("elem_1"), new("elem_2")],
            State = NotificationTemplateState.Draft,
        };

        string expectedID = "id";
        string expectedLocaleID = "localeId";
        List<Element> expectedElements = [new("elem_1"), new("elem_2")];
        ApiEnum<string, NotificationTemplateState> expectedState = NotificationTemplateState.Draft;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLocaleID, parameters.LocaleID);
        Assert.Equal(expectedElements.Count, parameters.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], parameters.Elements[i]);
        }
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationPutLocaleParams
        {
            ID = "id",
            LocaleID = "localeId",
            Elements = [new("elem_1"), new("elem_2")],
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationPutLocaleParams
        {
            ID = "id",
            LocaleID = "localeId",
            Elements = [new("elem_1"), new("elem_2")],

            // Null should be interpreted as omitted for these properties
            State = null,
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        NotificationPutLocaleParams parameters = new()
        {
            ID = "id",
            LocaleID = "localeId",
            Elements = [new("elem_1"), new("elem_2")],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/notifications/id/locales/localeId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationPutLocaleParams
        {
            ID = "id",
            LocaleID = "localeId",
            Elements = [new("elem_1"), new("elem_2")],
            State = NotificationTemplateState.Draft,
        };

        NotificationPutLocaleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ElementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Element { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Element { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Element>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Element { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Element>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Element { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Element { ID = "id" };

        Element copied = new(model);

        Assert.Equal(model, copied);
    }
}
