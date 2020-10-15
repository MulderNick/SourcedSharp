using System;

namespace EntityTestApplication.Entity.Entities.State
{
    public class Entity
    {
        public Guid Id;
        public string Name;

        public Entity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}