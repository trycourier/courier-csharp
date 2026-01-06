using System;
using Courier.Models.Translations;

namespace Courier.Tests.Models.Translations;

public class TranslationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TranslationRetrieveParams { Domain = "domain", Locale = "locale" };

        string expectedDomain = "domain";
        string expectedLocale = "locale";

        Assert.Equal(expectedDomain, parameters.Domain);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void Url_Works()
    {
        TranslationRetrieveParams parameters = new() { Domain = "domain", Locale = "locale" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/translations/domain/locale"), url);
    }
}
