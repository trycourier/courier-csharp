using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Brands;

namespace TryCourier.Tests.Models.Brands;

public class EmailFooterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailFooter
        {
            InheritDefault = true,
            Markdown = "markdown",
            Social = new()
            {
                Facebook = new() { Url = "url" },
                Instagram = new() { Url = "url" },
                Linkedin = new() { Url = "url" },
                Medium = new() { Url = "url" },
                Twitter = new() { Url = "url" },
            },
        };

        bool expectedInheritDefault = true;
        string expectedMarkdown = "markdown";
        Social expectedSocial = new()
        {
            Facebook = new() { Url = "url" },
            Instagram = new() { Url = "url" },
            Linkedin = new() { Url = "url" },
            Medium = new() { Url = "url" },
            Twitter = new() { Url = "url" },
        };

        Assert.Equal(expectedInheritDefault, model.InheritDefault);
        Assert.Equal(expectedMarkdown, model.Markdown);
        Assert.Equal(expectedSocial, model.Social);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailFooter
        {
            InheritDefault = true,
            Markdown = "markdown",
            Social = new()
            {
                Facebook = new() { Url = "url" },
                Instagram = new() { Url = "url" },
                Linkedin = new() { Url = "url" },
                Medium = new() { Url = "url" },
                Twitter = new() { Url = "url" },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailFooter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailFooter
        {
            InheritDefault = true,
            Markdown = "markdown",
            Social = new()
            {
                Facebook = new() { Url = "url" },
                Instagram = new() { Url = "url" },
                Linkedin = new() { Url = "url" },
                Medium = new() { Url = "url" },
                Twitter = new() { Url = "url" },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailFooter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedInheritDefault = true;
        string expectedMarkdown = "markdown";
        Social expectedSocial = new()
        {
            Facebook = new() { Url = "url" },
            Instagram = new() { Url = "url" },
            Linkedin = new() { Url = "url" },
            Medium = new() { Url = "url" },
            Twitter = new() { Url = "url" },
        };

        Assert.Equal(expectedInheritDefault, deserialized.InheritDefault);
        Assert.Equal(expectedMarkdown, deserialized.Markdown);
        Assert.Equal(expectedSocial, deserialized.Social);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailFooter
        {
            InheritDefault = true,
            Markdown = "markdown",
            Social = new()
            {
                Facebook = new() { Url = "url" },
                Instagram = new() { Url = "url" },
                Linkedin = new() { Url = "url" },
                Medium = new() { Url = "url" },
                Twitter = new() { Url = "url" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EmailFooter { };

        Assert.Null(model.InheritDefault);
        Assert.False(model.RawData.ContainsKey("inheritDefault"));
        Assert.Null(model.Markdown);
        Assert.False(model.RawData.ContainsKey("markdown"));
        Assert.Null(model.Social);
        Assert.False(model.RawData.ContainsKey("social"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EmailFooter { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EmailFooter
        {
            InheritDefault = null,
            Markdown = null,
            Social = null,
        };

        Assert.Null(model.InheritDefault);
        Assert.True(model.RawData.ContainsKey("inheritDefault"));
        Assert.Null(model.Markdown);
        Assert.True(model.RawData.ContainsKey("markdown"));
        Assert.Null(model.Social);
        Assert.True(model.RawData.ContainsKey("social"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EmailFooter
        {
            InheritDefault = null,
            Markdown = null,
            Social = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmailFooter
        {
            InheritDefault = true,
            Markdown = "markdown",
            Social = new()
            {
                Facebook = new() { Url = "url" },
                Instagram = new() { Url = "url" },
                Linkedin = new() { Url = "url" },
                Medium = new() { Url = "url" },
                Twitter = new() { Url = "url" },
            },
        };

        EmailFooter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SocialTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Social
        {
            Facebook = new() { Url = "url" },
            Instagram = new() { Url = "url" },
            Linkedin = new() { Url = "url" },
            Medium = new() { Url = "url" },
            Twitter = new() { Url = "url" },
        };

        Facebook expectedFacebook = new() { Url = "url" };
        Instagram expectedInstagram = new() { Url = "url" };
        Linkedin expectedLinkedin = new() { Url = "url" };
        Medium expectedMedium = new() { Url = "url" };
        Twitter expectedTwitter = new() { Url = "url" };

        Assert.Equal(expectedFacebook, model.Facebook);
        Assert.Equal(expectedInstagram, model.Instagram);
        Assert.Equal(expectedLinkedin, model.Linkedin);
        Assert.Equal(expectedMedium, model.Medium);
        Assert.Equal(expectedTwitter, model.Twitter);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Social
        {
            Facebook = new() { Url = "url" },
            Instagram = new() { Url = "url" },
            Linkedin = new() { Url = "url" },
            Medium = new() { Url = "url" },
            Twitter = new() { Url = "url" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Social>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Social
        {
            Facebook = new() { Url = "url" },
            Instagram = new() { Url = "url" },
            Linkedin = new() { Url = "url" },
            Medium = new() { Url = "url" },
            Twitter = new() { Url = "url" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Social>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Facebook expectedFacebook = new() { Url = "url" };
        Instagram expectedInstagram = new() { Url = "url" };
        Linkedin expectedLinkedin = new() { Url = "url" };
        Medium expectedMedium = new() { Url = "url" };
        Twitter expectedTwitter = new() { Url = "url" };

        Assert.Equal(expectedFacebook, deserialized.Facebook);
        Assert.Equal(expectedInstagram, deserialized.Instagram);
        Assert.Equal(expectedLinkedin, deserialized.Linkedin);
        Assert.Equal(expectedMedium, deserialized.Medium);
        Assert.Equal(expectedTwitter, deserialized.Twitter);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Social
        {
            Facebook = new() { Url = "url" },
            Instagram = new() { Url = "url" },
            Linkedin = new() { Url = "url" },
            Medium = new() { Url = "url" },
            Twitter = new() { Url = "url" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Social { };

        Assert.Null(model.Facebook);
        Assert.False(model.RawData.ContainsKey("facebook"));
        Assert.Null(model.Instagram);
        Assert.False(model.RawData.ContainsKey("instagram"));
        Assert.Null(model.Linkedin);
        Assert.False(model.RawData.ContainsKey("linkedin"));
        Assert.Null(model.Medium);
        Assert.False(model.RawData.ContainsKey("medium"));
        Assert.Null(model.Twitter);
        Assert.False(model.RawData.ContainsKey("twitter"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Social { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Social
        {
            Facebook = null,
            Instagram = null,
            Linkedin = null,
            Medium = null,
            Twitter = null,
        };

        Assert.Null(model.Facebook);
        Assert.True(model.RawData.ContainsKey("facebook"));
        Assert.Null(model.Instagram);
        Assert.True(model.RawData.ContainsKey("instagram"));
        Assert.Null(model.Linkedin);
        Assert.True(model.RawData.ContainsKey("linkedin"));
        Assert.Null(model.Medium);
        Assert.True(model.RawData.ContainsKey("medium"));
        Assert.Null(model.Twitter);
        Assert.True(model.RawData.ContainsKey("twitter"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Social
        {
            Facebook = null,
            Instagram = null,
            Linkedin = null,
            Medium = null,
            Twitter = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Social
        {
            Facebook = new() { Url = "url" },
            Instagram = new() { Url = "url" },
            Linkedin = new() { Url = "url" },
            Medium = new() { Url = "url" },
            Twitter = new() { Url = "url" },
        };

        Social copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FacebookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Facebook { Url = "url" };

        string expectedUrl = "url";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Facebook { Url = "url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Facebook>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Facebook { Url = "url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Facebook>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUrl = "url";

        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Facebook { Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Facebook { };

        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Facebook { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Facebook { Url = null };

        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Facebook { Url = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Facebook { Url = "url" };

        Facebook copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InstagramTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Instagram { Url = "url" };

        string expectedUrl = "url";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Instagram { Url = "url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Instagram>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Instagram { Url = "url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Instagram>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUrl = "url";

        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Instagram { Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Instagram { };

        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Instagram { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Instagram { Url = null };

        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Instagram { Url = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Instagram { Url = "url" };

        Instagram copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LinkedinTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Linkedin { Url = "url" };

        string expectedUrl = "url";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Linkedin { Url = "url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Linkedin>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Linkedin { Url = "url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Linkedin>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUrl = "url";

        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Linkedin { Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Linkedin { };

        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Linkedin { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Linkedin { Url = null };

        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Linkedin { Url = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Linkedin { Url = "url" };

        Linkedin copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MediumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Medium { Url = "url" };

        string expectedUrl = "url";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Medium { Url = "url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Medium>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Medium { Url = "url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Medium>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedUrl = "url";

        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Medium { Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Medium { };

        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Medium { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Medium { Url = null };

        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Medium { Url = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Medium { Url = "url" };

        Medium copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TwitterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Twitter { Url = "url" };

        string expectedUrl = "url";

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Twitter { Url = "url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Twitter>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Twitter { Url = "url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Twitter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUrl = "url";

        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Twitter { Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Twitter { };

        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Twitter { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Twitter { Url = null };

        Assert.Null(model.Url);
        Assert.True(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Twitter { Url = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Twitter { Url = "url" };

        Twitter copied = new(model);

        Assert.Equal(model, copied);
    }
}
