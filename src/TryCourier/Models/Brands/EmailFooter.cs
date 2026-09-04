using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<EmailFooter, EmailFooterFromRaw>))]
public sealed record class EmailFooter : JsonModel
{
    public bool? InheritDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inheritDefault");
        }
        init { this._rawData.Set("inheritDefault", value); }
    }

    /// <summary>
    /// The footer body, as markdown. This is the field the API returns and accepts;
    /// it is omitted entirely when no footer body is set. Sending null is accepted
    /// and treated as no footer body.
    /// </summary>
    public string? Markdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("markdown");
        }
        init { this._rawData.Set("markdown", value); }
    }

    /// <summary>
    /// Social links rendered in the email footer.
    /// </summary>
    public Social? Social
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Social>("social");
        }
        init { this._rawData.Set("social", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InheritDefault;
        _ = this.Markdown;
        this.Social?.Validate();
    }

    public EmailFooter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailFooter(EmailFooter emailFooter)
        : base(emailFooter) { }
#pragma warning restore CS8618

    public EmailFooter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailFooter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailFooterFromRaw.FromRawUnchecked"/>
    public static EmailFooter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailFooterFromRaw : IFromRawJson<EmailFooter>
{
    /// <inheritdoc/>
    public EmailFooter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmailFooter.FromRawUnchecked(rawData);
}

/// <summary>
/// Social links rendered in the email footer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Social, SocialFromRaw>))]
public sealed record class Social : JsonModel
{
    public Facebook? Facebook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Facebook>("facebook");
        }
        init { this._rawData.Set("facebook", value); }
    }

    public Instagram? Instagram
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Instagram>("instagram");
        }
        init { this._rawData.Set("instagram", value); }
    }

    public Linkedin? Linkedin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Linkedin>("linkedin");
        }
        init { this._rawData.Set("linkedin", value); }
    }

    public Medium? Medium
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Medium>("medium");
        }
        init { this._rawData.Set("medium", value); }
    }

    public Twitter? Twitter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Twitter>("twitter");
        }
        init { this._rawData.Set("twitter", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Facebook?.Validate();
        this.Instagram?.Validate();
        this.Linkedin?.Validate();
        this.Medium?.Validate();
        this.Twitter?.Validate();
    }

    public Social() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Social(Social social)
        : base(social) { }
#pragma warning restore CS8618

    public Social(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Social(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SocialFromRaw.FromRawUnchecked"/>
    public static Social FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SocialFromRaw : IFromRawJson<Social>
{
    /// <inheritdoc/>
    public Social FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Social.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Facebook, FacebookFromRaw>))]
public sealed record class Facebook : JsonModel
{
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
    }

    public Facebook() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Facebook(Facebook facebook)
        : base(facebook) { }
#pragma warning restore CS8618

    public Facebook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Facebook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FacebookFromRaw.FromRawUnchecked"/>
    public static Facebook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FacebookFromRaw : IFromRawJson<Facebook>
{
    /// <inheritdoc/>
    public Facebook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Facebook.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Instagram, InstagramFromRaw>))]
public sealed record class Instagram : JsonModel
{
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
    }

    public Instagram() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Instagram(Instagram instagram)
        : base(instagram) { }
#pragma warning restore CS8618

    public Instagram(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Instagram(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstagramFromRaw.FromRawUnchecked"/>
    public static Instagram FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstagramFromRaw : IFromRawJson<Instagram>
{
    /// <inheritdoc/>
    public Instagram FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Instagram.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Linkedin, LinkedinFromRaw>))]
public sealed record class Linkedin : JsonModel
{
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
    }

    public Linkedin() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Linkedin(Linkedin linkedin)
        : base(linkedin) { }
#pragma warning restore CS8618

    public Linkedin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Linkedin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedinFromRaw.FromRawUnchecked"/>
    public static Linkedin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedinFromRaw : IFromRawJson<Linkedin>
{
    /// <inheritdoc/>
    public Linkedin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Linkedin.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Medium, MediumFromRaw>))]
public sealed record class Medium : JsonModel
{
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
    }

    public Medium() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Medium(Medium medium)
        : base(medium) { }
#pragma warning restore CS8618

    public Medium(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Medium(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MediumFromRaw.FromRawUnchecked"/>
    public static Medium FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MediumFromRaw : IFromRawJson<Medium>
{
    /// <inheritdoc/>
    public Medium FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Medium.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Twitter, TwitterFromRaw>))]
public sealed record class Twitter : JsonModel
{
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
    }

    public Twitter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Twitter(Twitter twitter)
        : base(twitter) { }
#pragma warning restore CS8618

    public Twitter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Twitter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TwitterFromRaw.FromRawUnchecked"/>
    public static Twitter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TwitterFromRaw : IFromRawJson<Twitter>
{
    /// <inheritdoc/>
    public Twitter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Twitter.FromRawUnchecked(rawData);
}
