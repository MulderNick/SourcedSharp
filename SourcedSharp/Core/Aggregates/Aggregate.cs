using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using SourcedSharp.Core.Projections;

namespace SourcedSharp.Core.Aggregates
{
    // ToDo: See if passed generics can be minimized
    public class Aggregate<TProjector, TVerifier> 
        where TProjector : IProjector
        where TVerifier : IAggregateRuleVerifier
    {
        protected TProjector Projector;
        protected TVerifier Verify;

        public Aggregate(Guid id)
        {
            LoadProjection(id);
            InitVerifier();
        }

        public void LoadProjection(Guid aggregateId)
        {
            Projector = (TProjector)Activator.CreateInstance(typeof(TProjector), aggregateId);
        }

        public void InitVerifier()
        {
            Verify = (TVerifier)Activator.CreateInstance(typeof(TVerifier), Projector.Projection);
        }
    }
}