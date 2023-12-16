namespace Shared
{
    public interface IRepository<TAggregate, TId> where TAggregate : Aggregate<TId> where TId : IStronglyTypedValue
    {
        void Add(TAggregate aggregate);
        void Update(TAggregate aggregate);
        TAggregate GetById(TId id);
    }
}
