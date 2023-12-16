namespace Shared
{
    public abstract class Aggregate<TId> : Entity<TId> where TId : IStronglyTypedValue
    {
    }
}
