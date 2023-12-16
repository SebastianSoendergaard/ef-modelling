namespace Shared
{
    public abstract class FakeRepository<TAggregate, TId> : IRepository<TAggregate, TId> where TAggregate : Aggregate<TId> where TId : IStronglyTypedValue
    {
        private Dictionary<TId, TAggregate> _aggregates = new();

        public void Add(TAggregate aggregate)
        {
            _aggregates.Add(aggregate.Id, aggregate);
        }

        public TAggregate GetById(TId id)
        {
            return _aggregates[id];
        }

        public void Update(TAggregate aggregate)
        {
            _aggregates[aggregate.Id] = aggregate;
        }
    }
}
