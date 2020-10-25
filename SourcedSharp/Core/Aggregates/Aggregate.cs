using System;
using System.Threading.Tasks;
using SourcedSharp.Core.Aggregates.Projection;
using SourcedSharp.Core.Projections;

namespace SourcedSharp.Core.Aggregates
{
    // ToDo: See if passed generics can be minimized
    public class Aggregate<TProjector, TVerifier> : IAggregate
        where TProjector : IAggregateProjector
        where TVerifier : IAggregateRuleVerifier 
    {
        protected TProjector Projector;
        protected TVerifier Verify;
        protected IAggregateProjection State => Projector.Projection;

        private Guid _aggregateId;
        public Guid AggregateId
        {
            get
            {
                if (_aggregateId == null)
                {
                    throw new AggregateException("AggregateId not set");
                }
                return _aggregateId;
            }
            set
            {
                _aggregateId = value;
            }
        }

        public int AggregateVersion => Projector.Projection.AggregateVersion;


        private async Task InitAggregate()
        {
            await LoadProjection();
            InitVerifier();
        }

        protected async Task HandleCommandFor(Guid aggregateId)
        {
            AggregateId = aggregateId;
            await InitAggregate();
        }

        public async Task LoadProjection()
        {
            Projector = await ProjectorFactory.GetProjector<TProjector>(AggregateId);
        }

        public void InitVerifier()
        {
            Verify = (TVerifier)Activator.CreateInstance(typeof(TVerifier), Projector.Projection);
        }
    }
}