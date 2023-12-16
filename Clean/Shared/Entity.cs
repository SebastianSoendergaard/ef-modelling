namespace Shared
{
    public abstract class Entity<TId> where TId : IStronglyTypedValue
    {
        public TId Id { get; } = default!;
    }
}