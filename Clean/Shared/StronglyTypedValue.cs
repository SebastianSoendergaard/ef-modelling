namespace Shared
{
    public interface IStronglyTypedValue
    {

    }

    public abstract class StronglyTypedValue<T> : IStronglyTypedValue
    {
        public T Value { get; }

        public StronglyTypedValue(T value)
        {
            Value = value;
        }
    }
}
