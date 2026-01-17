using System;
using Courier.Models.Translations;

namespace Courier.Tests.Models.Translations;

public class TranslationUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranslationUpdateParams
        {
            Domain = "domain",
            Locale = "locale",
            Body = "body",
        };

        string expectedDomain = "domain";
        string expectedLocale = "locale";
        string expectedBody = "body";

        Assert.Equal(expectedDomain, parameters.Domain);
        Assert.Equal(expectedLocale, parameters.Locale);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        TranslationUpdateParams parameters = new()
        {
            Domain = "domain",
            Locale = "locale",
            Body = "body",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/translations/domain/locale"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TranslationUpdateParams
        {
            Domain = "domain",
            Locale = "locale",
            Body = "body",
        };

        TranslationUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
