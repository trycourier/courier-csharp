using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ProfilePreferences, ProfilePreferencesFromRaw>))]
public sealed record class ProfilePreferences : ModelBase
{
    public required IReadOnlyDictionary<string, Preference> Notifications
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, Preference>>(
                this.RawData,
                "notifications"
            );
        }
        init { ModelBase.Set(this._rawData, "notifications", value); }
    }

    public IReadOnlyDictionary<string, Preference>? Categories
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, Preference>>(
                this.RawData,
                "categories"
            );
        }
        init { ModelBase.Set(this._rawData, "categories", value); }
    }

    public string? TemplateID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "templateId"); }
        init { ModelBase.Set(this._rawData, "templateId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Notifications.Values)
        {
            item.Validate();
        }
        if (this.Categories != null)
        {
            foreach (var item in this.Categories.Values)
            {
                item.Validate();
            }
        }
        _ = this.TemplateID;
    }

    public ProfilePreferences() { }

    public ProfilePreferences(ProfilePreferences profilePreferences)
        : base(profilePreferences) { }

    public ProfilePreferences(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfilePreferences(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfilePreferencesFromRaw.FromRawUnchecked"/>
    public static ProfilePreferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProfilePreferences(Dictionary<string, Preference> notifications)
        : this()
    {
        this.Notifications = notifications;
    }
}

class ProfilePreferencesFromRaw : IFromRaw<ProfilePreferences>
{
    /// <inheritdoc/>
    public ProfilePreferences FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfilePreferences.FromRawUnchecked(rawData);
}
