using System;

namespace NET01.Entities
{
    public class VideoMaterial : TrainingMaterials, IVersionable
    {
        private static readonly string[] FormatTypes = {"unknown", "avi", "mp4", "flv"};
        public string URIVideo { get; set; }
        public string URIPicture { get; set; }
        public string VideoFormat
        {
            get => VideoFormat;
            set
            {
                bool isInitFormat = false;
                foreach (var type in FormatTypes)
                {
                    if (value.ToLower() == type)
                    {
                        VideoFormat = value;
                        isInitFormat = true;
                        break;
                    }
                }

                if (!isInitFormat)
                {
                    throw new ArgumentException("Invalid Video Format");
                }
            }
        }
    }
}