namespace Courier.Core;

interface IVariant<TVariant, TValue>
    where TVariant : IVariant<TVariant, TValue>
{
    static abstract TVariant From(TValue value);
    TValue Value { get; }
}
