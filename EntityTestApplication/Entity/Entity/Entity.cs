using System;
using System.Collections.Generic;

namespace EntityTestApplication.Entity.Entity
{
    public class Entity
    {
        public Guid Id;
        public Dictionary<Guid, string> Attributes;

        public Entity(Guid id)
        {
            Id = id;
            Attributes = new Dictionary<Guid, string>();
        }
    }
}