using Shared;

namespace DddStuff
{
    public abstract class Aggregate<TId> : Entity<TId> where TId : StronglyTypedValue<object>
    {
    }
}
