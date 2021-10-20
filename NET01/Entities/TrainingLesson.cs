using System;

namespace NET01.Entities
{
    public class TrainingLesson : EntityID
    {
        public TrainingMaterials[] MaterialsArray { get; set; }
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

        public string MaterialsType()
        {
            bool isVideoLesson = false;
            foreach (var material in MaterialsArray)
            {
                
                if (material.MaterialType == LessonType.VideoLesson.ToString())
                {
                    isVideoLesson = true;
                    break;
                }
            }

            if (isVideoLesson)
            {
                return "VideoLesson";
            }

            return "TextLesson";
        }

        public override string ToString()
        {
            return Description;
        }
    }
}