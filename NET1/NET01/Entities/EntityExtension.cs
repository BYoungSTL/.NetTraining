using System;

namespace NET01.Entities
{
    public static class EntityExtension
    {
        public static EntityID InitGuid(this EntityID entity)
        {
            entity.ID = Guid.NewGuid();
            return entity;
        }
    }
}