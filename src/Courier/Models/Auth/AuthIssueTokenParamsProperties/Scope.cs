using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Auth.AuthIssueTokenParamsProperties;

[JsonConverter(typeof(ScopeConverter))]
public enum Scope
{
    ReadPreferences,
    WritePreferences,
    ReadUserTokens,
    WriteUserTokens,
    ReadBrands,
    WriteBrands,
    ReadBrandsID,
    WriteBrandsID,
    WriteTrack,
    InboxReadMessages,
    InboxWriteMessages,
    InboxWriteEvent,
    InboxWriteEvents,
    UserIDYourUserID,
}

sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "read:preferences" => Scope.ReadPreferences,
            "write:preferences" => Scope.WritePreferences,
            "read:user-tokens" => Scope.ReadUserTokens,
            "write:user-tokens" => Scope.WriteUserTokens,
            "read:brands" => Scope.ReadBrands,
            "write:brands" => Scope.WriteBrands,
            "read:brands{:id}" => Scope.ReadBrandsID,
            "write:brands{:id}" => Scope.WriteBrandsID,
            "write:track" => Scope.WriteTrack,
            "inbox:read:messages" => Scope.InboxReadMessages,
            "inbox:write:messages" => Scope.InboxWriteMessages,
            "inbox:write:event" => Scope.InboxWriteEvent,
            "inbox:write:events" => Scope.InboxWriteEvents,
            "user_id:$YOUR_USER_ID" => Scope.UserIDYourUserID,
            _ => (Scope)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Scope.ReadPreferences => "read:preferences",
                Scope.WritePreferences => "write:preferences",
                Scope.ReadUserTokens => "read:user-tokens",
                Scope.WriteUserTokens => "write:user-tokens",
                Scope.ReadBrands => "read:brands",
                Scope.WriteBrands => "write:brands",
                Scope.ReadBrandsID => "read:brands{:id}",
                Scope.WriteBrandsID => "write:brands{:id}",
                Scope.WriteTrack => "write:track",
                Scope.InboxReadMessages => "inbox:read:messages",
                Scope.InboxWriteMessages => "inbox:write:messages",
                Scope.InboxWriteEvent => "inbox:write:event",
                Scope.InboxWriteEvents => "inbox:write:events",
                Scope.UserIDYourUserID => "user_id:$YOUR_USER_ID",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
