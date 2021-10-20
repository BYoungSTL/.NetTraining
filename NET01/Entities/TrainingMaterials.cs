#nullable enable
using System;

namespace NET01.Entities
{
    public abstract class TrainingMaterials : EntityID
    {
        public string MaterialType { get; set; }
        public string? Description
        {
            get => Description;
            set
            {
                if (value.Length > 256)
                {
                    throw new ArgumentException("Description is too long! (Max Length = 256)");
                }

                Description = value;
            }
        }
        
        public override string? ToString()
        {
            return Description;
        }

        public override bool Equals(object? obj)
        {
            if (obj is EntityID)
            {
                return ID == (obj as EntityID)!.ID;
            }

            throw new InvalidCastException("Invalid type for comparison");
        }
    }
}