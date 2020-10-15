using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using SourcedSharp.Core.Messages.Commands;
using SourcedSharp.Core.Projections;

namespace SourcedSharp.Core.Aggregates
{
    // ToDo: See if passed generics can be minimized
    public class Aggregate<TProjector, TVerifier> : IAggregate
        where TProjector : IProjector
        where TVerifier : IAggregateRuleVerifier 
    {
        protected TProjector Projector;
        protected TVerifier Verify;

        private Guid _aggregateId;
        protected Guid AggregateId
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
                InitAggregate();
            }
        }

        private void InitAggregate()
        {
            LoadProjection();
            InitVerifier();
        }

        protected void HandleCommandFor(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public void LoadProjection()
        {
            Projector = ProjectorFactory.GetProjector<TProjector>(AggregateId);
        }

        public void InitVerifier()
        {
            Verify = (TVerifier)Activator.CreateInstance(typeof(TVerifier), Projector.Projection);
        }
    }
}