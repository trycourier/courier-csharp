using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { JsonModel.Set(this._rawData, "paging", value); }
    }

    public required IReadOnlyList<Result> Results
    {
        get { return JsonModel.GetNotNullClass<List<Result>>(this.RawData, "results"); }
        init { JsonModel.Set(this._rawData, "results", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required long CreatedAt
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "created_at"); }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// Array of event IDs associated with this notification
    /// </summary>
    public required IReadOnlyList<string> EventIDs
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "event_ids"); }
        init { JsonModel.Set(this._rawData, "event_ids", value); }
    }

    public required string Note
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "note"); }
        init { JsonModel.Set(this._rawData, "note", value); }
    }

    public required MessageRouting Routing
    {
        get { return JsonModel.GetNotNullClass<MessageRouting>(this.RawData, "routing"); }
        init { JsonModel.Set(this._rawData, "routing", value); }
    }

    public required string TopicID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "topic_id"); }
        init { JsonModel.Set(this._rawData, "topic_id", value); }
    }

    public required long UpdatedAt
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "updated_at"); }
        init { JsonModel.Set(this._rawData, "updated_at", value); }
    }

    public Tags? Tags
    {
        get { return JsonModel.GetNullableClass<Tags>(this.RawData, "tags"); }
        init { JsonModel.Set(this._rawData, "tags", value); }
    }

    public string? Title
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "title"); }
        init { JsonModel.Set(this._rawData, "title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.EventIDs;
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNotNullClass<List<Data>>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
