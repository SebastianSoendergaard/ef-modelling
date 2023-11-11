using Shared;

namespace DddStuff
{
    public abstract class Entity<TId> where TId : StronglyTypedValue<object>
    {
        public TId Id { get; } = default!;
    }
}