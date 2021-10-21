#nullable enable
using System;

namespace NET01.Entities
{
    public class TrainingLesson : EntityID, IVersionable, ICloneable
    {
        private byte[] _version = new byte[8];
        private const int DescriptionLength = 256;
        private string? _description;
        public TrainingMaterials[] MaterialsArray { get; set; }
        public string Name { get; set; }
        public string MaterialType { get; set; }

        public string? Description
        {
            get => this._description;
            set
            {
                if (value.Length > DescriptionLength)
                {
                    throw new ArgumentException($"Description is too long! (Max Length = {DescriptionLength})");
                }

                this._description = value;
            }
        }

        //  Type of Lesson: if one of materials is Video, then the Lesson is Video Lesson
        public LessonType MaterialsTypes()
        {
            foreach (var material in MaterialsArray)
            {
                if (material.MaterialType == LessonType.VideoLesson.ToString().Remove(LessonType.VideoLesson.ToString().Length - 6))
                {
                    return LessonType.VideoLesson;
                }
            }

            return LessonType.TextLesson;
        } 

        // IVersionable realization
        public byte[] GetVersion()
        {
            return _version;
        }

        public void SetVersion(byte[] version)
        {
            if (version.Length == _version.Length)
            {
                this._version = version;
            }
            else
            {
                throw new ArgumentException("Invalid version(length mismatch)");
            }
        }

        // ICloneable realization

        public object Clone()
        {
            TrainingLesson newLesson = new()
            {
                Name = this.Name,
                _version = this._version,
                Description = this.Description,
                MaterialsArray = this.MaterialsArray,
                MaterialType = Enum.GetName(MaterialsTypes()) ?? throw new NullReferenceException("Null material type")
            };
            newLesson.InitGuid();
            return newLesson;
        }

        public override string ToString()
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