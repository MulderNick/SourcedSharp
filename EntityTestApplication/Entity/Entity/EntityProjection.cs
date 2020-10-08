using System;
using System.Collections.Generic;
using SourcedSharp.Core.Projections;

namespace EntityTestApplication.Entity.Entity
{
    public class EntityProjection : Projection
    {
        public Dictionary<Guid, string> Attributes = new Dictionary<Guid, string>();
    }
}