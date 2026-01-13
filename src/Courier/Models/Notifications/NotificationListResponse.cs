using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications;

[JsonConverter(
    typeof(JsonModelConverter<NotificationListResponse, NotificationListResponseFromRaw>)
)]
public sealed record class NotificationListResponse : JsonModel
{
    public required Paging Paging
    {
        get { return this._rawData.GetNotNullClass<Paging>("paging"); }
        init { this._rawData.Set("paging", value); }
    }

    public required IReadOnlyList<Result> Results
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<Result>>("results"); }
        init
        {
            this._rawData.Set<ImmutableArray<Result>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public NotificationListResponse() { }

    public NotificationListResponse(NotificationListResponse notificationListResponse)
        : base(notificationListResponse) { }

    public NotificationListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationListResponseFromRaw.FromRawUnchecked"/>
    public static NotificationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationListResponseFromRaw : IFromRawJson<NotificationListResponse>
{
    /// <inheritdoc/>
    public NotificationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required long CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<long>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Array of event IDs associated with this notification
    /// </summary>
    public required IReadOnlyList<string> EventIds
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<string>>("event_ids"); }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "event_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Note
    {
        get { return this._rawData.GetNotNullClass<string>("note"); }
        init { this._rawData.Set("note", value); }
    }

    public required MessageRouting Routing
    {
        get { return this._rawData.GetNotNullClass<MessageRouting>("routing"); }
        init { this._rawData.Set("routing", value); }
    }

    public required string TopicID
    {
        get { return this._rawData.GetNotNullClass<string>("topic_id"); }
        init { this._rawData.Set("topic_id", value); }
    }

    public required long UpdatedAt
    {
        get { return this._rawData.GetNotNullStruct<long>("updated_at"); }
        init { this._rawData.Set("updated_at", value); }
    }

    public Tags? Tags
    {
        get { return this._rawData.GetNullableClass<Tags>("tags"); }
        init { this._rawData.Set("tags", value); }
    }

    public string? Title
    {
        get { return this._rawData.GetNullableClass<string>("title"); }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.EventIds;
        _ = this.Note;
        this.Routing.Validate();
        _ = this.TopicID;
        _ = this.UpdatedAt;
        this.Tags?.Validate();
        _ = this.Title;
    }

    public Result() { }

    public Result(Result result)
        : base(result) { }

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Tags, TagsFromRaw>))]
public sealed record class Tags : JsonModel
{
    public required IReadOnlyList<Data> Data
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<Data>>("data"); }
        init
        {
            this._rawData.Set<ImmutableArray<Data>>("data", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public Tags() { }

    public Tags(Tags tags)
        : base(tags) { }

    public Tags(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TagsFromRaw.FromRawUnchecked"/>
    public static Tags FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Tags(List<Data> data)
        : this()
    {
        this.Data = data;
    }
}

class TagsFromRaw : IFromRawJson<Tags>
{
    /// <inheritdoc/>
    public Tags FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tags.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public Data() { }

    public Data(Data data)
        : base(data) { }

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
