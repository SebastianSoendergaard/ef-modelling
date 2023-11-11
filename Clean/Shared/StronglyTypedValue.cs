namespace Shared
{
    public abstract class StronglyTypedValue<T>
    {
        public T Value { get; }

        public StronglyTypedValue(T value)
        {
            Value = value;
        }
    }
}
