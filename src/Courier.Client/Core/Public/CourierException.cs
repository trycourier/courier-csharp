using System;

#nullable enable

namespace Courier.Client.Core;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class CourierException(string message, Exception? innerException = null)
    : Exception(message, innerException) { }
