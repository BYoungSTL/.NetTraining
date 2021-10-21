#nullable enable
using System;

namespace NET01.Entities
{
    public abstract class TrainingMaterials : EntityID
    {
        private string? _description; 
        public string MaterialType { get; set; }
        public string? Description
        {
            get => this._description;
            init
            {
                if (value != null && value.Length > 256)
                {
                    throw new ArgumentException("Description is too long! (Max Length = 256)");
                }

                this._description = value;
            }
        }
        
        public override string? ToString()
        {
            return Description;
        }
        
        public override int GetHashCode()
        {
            return int.Parse(ID.ToString());
        }

        public override bool Equals(object? obj)
        {
            if (obj is EntityID)
            {
                return ID == (obj as EntityID)!.ID;
            }

            return false;
        }
    }
}