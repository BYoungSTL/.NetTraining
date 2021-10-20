using System;
using NET01.Entities;

namespace NET01
{
    static class Program
    {
        private static void InitLesson(TrainingLesson lesson)
        {
            Console.WriteLine("Enter lesson name: ");
            lesson.Name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter description: ");
            lesson.Description = Console.ReadLine();
            lesson.MaterialsArray = new TrainingMaterials[]
            {
                new VideoMaterial
                {
                    UriPicture = "Some picture",
                    UriVideo = "Some video",
                    VideoFormat = "AVI",
                    MaterialType = "VideoLesson",
                },
                new TextMaterial
                {
                    Description = "Some description",
                    Text = "Some text",
                    MaterialType = "TextLesson"
                },
                new ReferenceMaterial
                {
                    ReferenceType = "HTML",
                    UriContent = "Some Content",
                    Description = null,
                    MaterialType = "Reference"
                }
            };
            lesson.InitGuid();
            lesson.MaterialType = lesson.MaterialsTypes().ToString();
            lesson.SetVersion(new byte[]{1, 0, 0, 0, 0, 0, 0, 1});
            foreach (var trainingMaterials in lesson.MaterialsArray)
            {
                if (trainingMaterials is VideoMaterial material)
                {
                    material.SetVersion(new byte[]{1, 0, 0, 0, 0, 0, 0, 1});
                }
            }
        }

        static void Main(string[] args)
        {
            TrainingLesson lesson = new TrainingLesson();
            InitLesson(lesson);
            TrainingLesson newLesson = (TrainingLesson) lesson.Clone();
            Console.WriteLine(lesson.Equals(newLesson));
            Console.WriteLine(lesson.Name + " " + newLesson.Name);
            Console.WriteLine(lesson.ID + " " + newLesson.ID);
            Console.WriteLine(lesson.ToString() + " " + newLesson.ToString());
            foreach (var v in lesson.GetVersion())
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
            foreach (var v in newLesson.GetVersion())
            {
                Console.Write(v + " ");
            }
        }
    }
}
