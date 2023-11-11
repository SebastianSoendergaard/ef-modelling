using DddStuff;

namespace Shared
{
    public interface IRepository<TAggregate, TId> where TAggregate : Aggregate<TId> where TId : StronglyTypedValue<object>
    {
        void Add(TAggregate aggregate);
        void Update(TAggregate aggregate);
        TAggregate GetById(TId id);
    }
}
