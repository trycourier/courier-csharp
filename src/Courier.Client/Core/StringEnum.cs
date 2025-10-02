using System.Text.Json.Serialization;

namespace Courier.Client.Core;

public interface IStringEnum : IEquatable<string>
{
    public string Value { get; }
}
